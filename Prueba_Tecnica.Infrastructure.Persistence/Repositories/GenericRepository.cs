using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Core.Application.Interfaces.Repositories;
using Prueba_Tecnica.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly AppDbContext _db;
        public GenericRepository(AppDbContext db)
        {
            _db = db;
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _db.Set<Entity>().ToListAsync();
        }
        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _db.Set<Entity>().FindAsync(id);
        }
        public virtual async Task<Entity> AddAsync(Entity entity)
        {
            await _db.Set<Entity>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Entity> UpdateAsync(Entity entity, int id)
        {
            Entity entry = await _db.Set<Entity>().FindAsync(id);
            _db.Entry(entry).CurrentValues.SetValues(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(Entity entity)
        {
            _db.Set<Entity>().Remove(entity);
            await _db.SaveChangesAsync();
        }

    }
}
