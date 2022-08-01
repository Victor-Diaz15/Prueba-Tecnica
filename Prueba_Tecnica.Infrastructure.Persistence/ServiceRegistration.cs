using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prueba_Tecnica.Core.Application.Interfaces.Repositories;
using Prueba_Tecnica.Infrastructure.Persistence.Contexts;
using Prueba_Tecnica.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Infrastructure.Persistence
{
    //Main reason for creating this class is to follow the Single responsability
    public static class ServiceRegistration
    {
        // Extension methods | "Decorator"
        // This allows us to extend and create new functionallity following "Open-Closed Principle"
        public static void AddPersistanceInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                service.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                service.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            }

            //Transient to dependency injection for repositories
            #region 'repositories'

            service.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddTransient<ICandidatoRepository, CandidatoRepository>();
          
            #endregion
        }
    }
}
