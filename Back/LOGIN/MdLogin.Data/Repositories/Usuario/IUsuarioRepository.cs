
namespace MdLogin.Data.Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        List<Data.Usuario> GetAllUsuarios();
        int? CreateUser(Data.Usuario user);
        bool UpdateUser(Data.Usuario user);
        bool DeleteUser(Data.Usuario user);
        Data.Usuario GetUsuario(string user);

    }
}
