using Microsoft.Extensions.DependencyInjection;
using Prueba_Tecnica.Core.Application.Interfaces.Services;
using Prueba_Tecnica.Core.Application.Services;
using System.Reflection;

namespace Prueba_Tecnica.Core.Application
{
    // Extension methods | "Decorator"
    // This allows us to extend and create new functionallity following "Open-Closed Principle"
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());

            //Transient to dependency injection for services
            #region Services

            service.AddTransient<ICandidatoService, CandidatoService>();

            #endregion
        }
    }
}
