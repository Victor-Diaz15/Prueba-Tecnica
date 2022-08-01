using AutoMapper;
using Prueba_Tecnica.Core.Application.Interfaces.Repositories;
using Prueba_Tecnica.Core.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Core.Application.Services
{
    public class GenericService<SaveViewModel, ViewModel, Entity> : IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        private readonly IGenericRepository<Entity> _genericRepo;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<Entity> genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        public virtual async Task<List<ViewModel>> GetAllAsync()
        {
            var entityList = await _genericRepo.GetAllAsync();
            return _mapper.Map<List<ViewModel>>(entityList);
        }
        public virtual async Task<SaveViewModel> GetById(int id)
        {
            Entity entity = await _genericRepo.GetByIdAsync(id);
            SaveViewModel vm = _mapper.Map<SaveViewModel>(entity);
            return vm;
        }
        public virtual async Task<SaveViewModel> AddAsync(SaveViewModel vm)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            entity = await _genericRepo.AddAsync(entity);
            SaveViewModel viewModel = _mapper.Map<SaveViewModel>(entity);
            return viewModel;
        }
        public virtual async Task<SaveViewModel> UpdateAsync(SaveViewModel vm, int id)
        {
            Entity entity = _mapper.Map<Entity>(vm);
            entity = await _genericRepo.UpdateAsync(entity, id);
            SaveViewModel viewModel = _mapper.Map<SaveViewModel>(entity);
            return viewModel;
        }
        public virtual async Task DeleteAsync(int id)
        {
            Entity entity = await _genericRepo.GetByIdAsync(id);
            await _genericRepo.DeleteAsync(entity);
        }
    }
}
