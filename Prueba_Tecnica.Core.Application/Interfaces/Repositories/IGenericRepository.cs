using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        Task<Entity> AddAsync(Entity entity);
        Task<Entity> UpdateAsync(Entity entity, int id);
        Task DeleteAsync(Entity entity);
    }
}
