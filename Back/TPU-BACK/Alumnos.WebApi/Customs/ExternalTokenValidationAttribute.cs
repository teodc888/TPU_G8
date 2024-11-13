using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ExternalTokenValidationAttribute : Attribute, IAsyncActionFilter
{
    private readonly string _validationUrl = "https://localhost:7258/api/v1/Login/Validate";  

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var tokenSesion = context.HttpContext.Request.Headers["Authorization"].ToString();
        var usuarioId = context.HttpContext.Request.Headers["UsuarioId"].ToString();


        if (string.IsNullOrEmpty(tokenSesion) || string.IsNullOrEmpty(usuarioId))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        using (var httpClient = new HttpClient())
        {
            var data = new
            {
                TokenSesion = tokenSesion,
                UsuarioId = usuarioId
            };

            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(_validationUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
        }

        await next();
    }
}
