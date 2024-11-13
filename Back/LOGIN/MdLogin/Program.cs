using MdLogin.Data.Data;
using MdLogin.Data.Repositories.Compania;
using MdLogin.Data.Repositories.LogActividad;
using MdLogin.Data.Repositories.Rol;
using MdLogin.Data.Repositories.Sesion;
using MdLogin.Data.Repositories.Usuario;
using MdLogin.Data.Repositories.UsuarioRol;
using MdLogin.Service.Repositories.Login;
using MdLogin.Service.Repositories.Register.Company;
using MdLogin.Service.Repositories.Register.LogActividad;
using MdLogin.Service.Repositories.Register.Session;
using MdLogin.Service.Repositories.Register.User;
using MdLogin.Service.Repositories.Register.UserRol;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull; // Opcional, si quieres ignorar valores nulos
    });

// Definir la política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.AllowAnyOrigin() // Permite cualquier origen
              .AllowAnyHeader() // Permite cualquier encabezado
              .AllowAnyMethod(); // Permite cualquier método HTTP
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MdLoginContext>(optionsAction => optionsAction.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ISessionRegisterRepository, SessionRegisterRepository>();
builder.Services.AddScoped<ISesionRepository, SesionRepository>();
builder.Services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
builder.Services.AddScoped<ILogActividadRegisterRepository, LogActividadRegisterRepository>();
builder.Services.AddScoped<ILogActividadRepository, LogActividadRepository>();
builder.Services.AddScoped<IUsuarioRolRepository, UsuarioRolRepository>();
builder.Services.AddScoped<IUserRolRegisterRepository, UserRolRegisterRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<ICompaniaRepository, CompaniaRepository>();
builder.Services.AddScoped<ICompanyRegisterRepository, CompanyRegisterRepository>();


var app = builder.Build();

// Habilitar CORS antes de los middlewares
app.UseCors("AllowAnyOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
