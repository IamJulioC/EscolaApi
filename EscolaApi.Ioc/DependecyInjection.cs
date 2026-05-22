using EscolaApi.Application.Interfaces;
using EscolaApi.Application.Services;
using EscolaApi.Domain.Interfaces;
using EscolaApi.Infra.Data.Context;
using EscolaApi.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(Options =>
            {
                Options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<INotaService, NotaService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();


            return services;
        }
    }
}
