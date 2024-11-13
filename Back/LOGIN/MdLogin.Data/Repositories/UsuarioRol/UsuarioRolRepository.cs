using MdLogin.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdLogin.Data.Repositories.UsuarioRol
{
    public class UsuarioRolRepository : IUsuarioRolRepository
    {
        private readonly MdLoginContext _contex;
        public UsuarioRolRepository(MdLoginContext context) {
            _contex = context;
        }
        public bool Add(Data.UsuarioRol usuarioRol)
        {
            _contex.UsuarioRols.Add(usuarioRol);
            return _contex.SaveChanges() > 0;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Data.UsuarioRol> GetAll()
        {
            throw new NotImplementedException();
        }

        public Data.UsuarioRol GetByUserId(int Userid)
        {
            return _contex.UsuarioRols.Where(x => x.UsuarioId == Userid).FirstOrDefault();
        }

        public void Update(Data.UsuarioRol usuarioRol)
        {
            throw new NotImplementedException();
        }
    }
}
