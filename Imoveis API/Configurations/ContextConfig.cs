using Imoveis_Infraestrutura.Entities;
using Microsoft.EntityFrameworkCore;

namespace Imoveis_API
{
    public static class ContextConfig
    {
        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LOCADORA_IMOVEISContext>(options => options
            .UseMySql(configuration.GetConnectionString("Imoveis"),
            new MySqlServerVersion(new Version(8, 0, 28))));
        }
    }
}
