using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Core.Application.ViewModels
{
    public class SaveCandidatoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiene que indicar su cedula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Tiene que indicar sus nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Tiene que indicar sus apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Tiene que indicar su fecha de nacimiento")]
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;
        public string TrabajoActual { get; set; }
        public int? ExpectativaSalarial { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
