using AutoMapper;
using Prueba_Tecnica.Core.Application.ViewModels;
using Prueba_Tecnica.Core.Domain.Entities;

namespace Prueba_Tecnica.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //Configuration Mappings
            #region mappings

            CreateMap<Candidato, CandidatoViewModel>()
                .ReverseMap();

            CreateMap<Candidato, SaveCandidatoViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            #endregion
        }
    }
}
