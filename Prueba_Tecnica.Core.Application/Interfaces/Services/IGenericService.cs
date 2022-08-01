using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel, Entity>
        where SaveViewModel : class
        where ViewModel : class
        where Entity : class
    {
        Task<List<ViewModel>> GetAllAsync();
        Task<SaveViewModel> GetById(int id);
        Task<SaveViewModel> AddAsync(SaveViewModel viewModel);
        Task<SaveViewModel> UpdateAsync(SaveViewModel vm, int id);
        Task DeleteAsync(int id);
    }
}
