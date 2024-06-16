using Child.Growth.src.Infra.Data;
using Child.Growth.src.Infra.Data.UnitOfWork;
using Child.Growth.src.Infra.DependencyInjection;
using Child.Growth.src.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Child.Growth
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Adicione serviços do ASP.NET Core MVC
            services.AddControllersWithViews()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

            // Adiciona filtro de exceção
            services.AddControllers(options =>
            {
                options.Filters.Add(new CustomExceptionFilterAttribute());
            });

            // Registra o repositório no Container de Injeção de Dependência
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Registra o Unit of Work no Container de Injeção de Dependência
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Injeta os serviços
            InjectServices.AddServices(services);

            // Configuração do banco de dados
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options
                    .UseLazyLoadingProxies() // Adiciona para carregar automaticamente entidades associadas ao acessar por uma consulta Linq por exemplo
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            // Configurações de autenticação e autorização
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}