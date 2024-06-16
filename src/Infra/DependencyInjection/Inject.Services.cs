using Child.Growth.src.Services.Implementations;
using Child.Growth.src.Services.Interfaces;

namespace Child.Growth.src.Infra.DependencyInjection
{
    public class InjectServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IPeopleService, PeopleService>();
        }
    }
}