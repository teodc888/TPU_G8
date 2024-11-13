using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumnos.Service.Validation
{
    public class AlumnoValidation
    {
        public AlumnoValidation() { }

        public bool Validate(Data.Data.Alumno alumno)
        {
            if (alumno == null)
            {
                return false;
            }

            if (alumno.FechaBaja != null)
            {
                return false;
            }

            return true;
        }
    }
}
