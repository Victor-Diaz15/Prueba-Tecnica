using Microsoft.EntityFrameworkCore;
using Prueba_Tecnica.Core.Application.Interfaces.Repositories;
using Prueba_Tecnica.Core.Domain.Entities;
using Prueba_Tecnica.Infrastructure.Persistence.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Infrastructure.Persistence.Repositories
{
    public class CandidatoRepository : GenericRepository<Candidato>, ICandidatoRepository
    {
        private readonly AppDbContext _db;
        public CandidatoRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
    