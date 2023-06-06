using Escolar.Application.Interfaces;
using Escolar.Application.Mappings;
using Escolar.Application.Services;
using Escolar.Domain.Interfaces;
using Escolar.Infrastructure.Context;
using Escolar.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Escolar.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(8, 0, 11))));

            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IEscolaService, EscolaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }

    
}
