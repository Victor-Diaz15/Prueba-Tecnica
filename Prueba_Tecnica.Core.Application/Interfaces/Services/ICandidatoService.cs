using Prueba_Tecnica.Core.Application.ViewModels;
using Prueba_Tecnica.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Core.Application.Interfaces.Services
{
    public interface ICandidatoService : IGenericService<SaveCandidatoViewModel, CandidatoViewModel, Candidato>
    {}
}
