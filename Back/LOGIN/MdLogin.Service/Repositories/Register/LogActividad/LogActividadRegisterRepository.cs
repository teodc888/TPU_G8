using MdLogin.Data.Repositories.LogActividad;
using MdLogin.Model.Const;
using MdLogin.Model.Models;



namespace MdLogin.Service.Repositories.Register.LogActividad
{
    public class LogActividadRegisterRepository : ILogActividadRegisterRepository
    {
        private readonly ILogActividadRepository _logActividadRepository;
        public LogActividadRegisterRepository(ILogActividadRepository logActividadRepository) {
            _logActividadRepository = logActividadRepository;
        }
        public ResponseModel AddLogActivity(int userId, string typeActivityConst, string description = null)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                Data.Data.LogActividad log = new Data.Data.LogActividad();
                log.UsuarioId = userId;
                log.TipoActividad = typeActivityConst;
                log.DescripciónActividad = description;
                log.FechaActividad = DateTime.Now;

                bool result = _logActividadRepository.Add(log);

                if (!result)
                {
                    throw new Exception("Error al registrar log actividad");
                }

                responseModel.Result = result;
                responseModel.Response = result;
            }
            catch (Exception ex)
            {
                responseModel.Error = ex.ToString();
                responseModel.Result = false;
                throw new Exception(ex.ToString());
            }

            return responseModel;
        }
    }
}
