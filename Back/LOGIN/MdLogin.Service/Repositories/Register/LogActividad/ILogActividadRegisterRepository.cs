using MdLogin.Model.Const;
using MdLogin.Model.Models;


namespace MdLogin.Service.Repositories.Register.LogActividad
{
    public interface ILogActividadRegisterRepository
    {
       ResponseModel AddLogActivity(int userId, string enumActivity, string description = null );
    }
}
