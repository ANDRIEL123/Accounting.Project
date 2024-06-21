using Accounting.Project.src.Services.Implementations;
using Accounting.Project.src.Services.Interfaces;

namespace Accounting.Project.src.Infra.DependencyInjection
{
    public class InjectServices
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAssetsService, AssetsService>();
            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<IAccountsService, AccountsService>();
            services.AddScoped<IReleasesService, ReleasesService>();
            services.AddScoped<INotesService, NotesService>();
        }
    }
}