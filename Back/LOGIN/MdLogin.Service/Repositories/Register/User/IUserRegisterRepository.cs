
using MdLogin.Data.Data;
using MdLogin.Model.Models;

namespace MdLogin.Service.Repositories.Register.User
{
    public interface IUserRegisterRepository
    {
        Usuario GetUser(LoginModel user);
        ResponseModel CreateUser(UserModel usuario);
        ResponseModel GetAll();
        
    }
}
