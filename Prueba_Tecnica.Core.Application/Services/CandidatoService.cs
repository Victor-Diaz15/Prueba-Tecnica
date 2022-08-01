using AutoMapper;
using Prueba_Tecnica.Core.Application.Interfaces.Repositories;
using Prueba_Tecnica.Core.Application.Interfaces.Services;
using Prueba_Tecnica.Core.Application.ViewModels;
using Prueba_Tecnica.Core.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Core.Application.Services
{
    public class CandidatoService : GenericService<SaveCandidatoViewModel, CandidatoViewModel, Candidato>, ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepo;
        private readonly IMapper _mapper;
        public CandidatoService(ICandidatoRepository candidatoRepo, IMapper mapper) : base(candidatoRepo, mapper)
        {
            _candidatoRepo = candidatoRepo;
            _mapper = mapper;
        }

        //method override for create a new candidate
        public async override Task<SaveCandidatoViewModel> AddAsync(SaveCandidatoViewModel vm)
        {
            SaveCandidatoViewModel res = new();
            res.HasError = false;

            List<Candidato> userList = await _candidatoRepo.GetAllAsync();
            //Checking if vm.Cedula is already exists int the Db
            bool cedulaRepetion = userList.Any(user => user.Cedula == vm.Cedula);
            if (cedulaRepetion)
            {
                res.HasError = true;
                res.Error = $"Este numero de cedula {vm.Cedula} ya existe.";
                return res;
            }

            //Calling method add in class base/father.
            await base.AddAsync(vm);

            return res;
        }

        //method override for update a candidate
        public async override Task<SaveCandidatoViewModel> UpdateAsync(SaveCandidatoViewModel vm, int id)
        {
            SaveCandidatoViewModel res = new();
            res.HasError = false;

            List<Candidato> userList = await _candidatoRepo.GetAllAsync();
            //Checking if vm.Cedula is already exists in the Db and if is different
            // from the candidate by editing at the momment.
            bool cedulaRepetion = userList.Any(user => user.Cedula == vm.Cedula && user.Id != id);
            if (cedulaRepetion)
            {
                res.HasError = true;
                res.Error = $"Este numero de cedula {vm.Cedula} ya existe.";
                return res;
            }

            //Calling method add in class base/father.
            await base.UpdateAsync(vm, id);

            return res;
        }
    }
}
