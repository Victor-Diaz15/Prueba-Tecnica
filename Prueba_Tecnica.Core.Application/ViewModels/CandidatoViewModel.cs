using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Core.Application.ViewModels
{
    public class CandidatoViewModel
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string TrabajoActual { get; set; }
        public int? ExpectativaSalarial { get; set; }
    }
}
