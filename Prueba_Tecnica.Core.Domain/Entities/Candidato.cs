using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba_Tecnica.Core.Domain.Entities
{
    public partial class Candidato
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
