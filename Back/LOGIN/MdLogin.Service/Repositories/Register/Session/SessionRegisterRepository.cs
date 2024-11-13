using Azure;
using MdLogin.Data.Data;
using MdLogin.Data.Repositories.Sesion;
using MdLogin.Model.Models;

namespace MdLogin.Service.Repositories.Register.Session
{
    public class SessionRegisterRepository : ISessionRegisterRepository
    {
        private readonly ISesionRepository _sessionRepository;
        public SessionRegisterRepository(ISesionRepository sesionRepository) { 
            _sessionRepository = sesionRepository;
        }

        public Sesion InitialSession(int UsuarioId, DateTime FinishDate, string Token)
        {
            try
            {
                Sesion sesion = _sessionRepository.GetByUser(UsuarioId);

                if(sesion == null)
                {
                    sesion = new Sesion();
                    sesion.UsuarioId = UsuarioId;
                    sesion.FechaInicio = DateTime.Now;
                    sesion.FechaFin = FinishDate;
                    sesion.TokenSesion = Token;
                    sesion.EstadoSesion = true;

                    if (!_sessionRepository.Add(sesion))
                    {
                        throw new Exception("Ocurrio un error al querer registrar una session");
                    }

                }
                else
                {
                    sesion.FechaInicio = DateTime.Now;
                    sesion.FechaFin = FinishDate;
                    sesion.TokenSesion = Token;
                    sesion.EstadoSesion = true;

                    if (!_sessionRepository.Update(sesion))
                    {
                        throw new Exception("Ocurrio un error al querer registrar una session");
                    }
                }

                return sesion;
            }
            catch (Exception ex) {
                throw new Exception(ex.ToString());
            }
        }

        public bool LogoutSession(Sesion sesion)
        {
            try
            {
                bool response = _sessionRepository.Update(sesion);
                if (!response)
                {
                    throw new Exception("Ocurrio un error en el Logout");
                }
                return response;
            }
            catch (Exception ex) {
                throw new Exception(ex.ToString());
            }
        }

        public bool ValidateSessionUser(int userId, out Sesion session)
        {
            try
            {
                session = _sessionRepository.GetByUser(userId);

                if (session == null) {
                    return false;
                }

                if (!(bool)session.EstadoSesion) {
                    return false;
                }

                DateTime datenow = DateTime.Now;
                if(session.FechaFin < datenow)
                {
                    return false;
                }

                return true;         
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool ValidateSessionUserAndToken(int userId, string token)
        {
            try
            {
                Sesion session = _sessionRepository.GetByTokenAndUser(token, userId);

                if (session == null)
                {
                    throw new Exception("Usuario no valido");
                }


                if (!(bool)session.EstadoSesion)
                {
                    return false;
                }

                DateTime datenow = DateTime.Now;
                if (session.FechaFin < datenow)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex) { 
                throw new Exception(ex.ToString());
            }
        }
    }
}
