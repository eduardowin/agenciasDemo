using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AgenciaService.Interfaces;
using AgenciaRepository.Repositories;
using AgenciaRepository.Interfaces;
using AgenciaService.Implementations;

namespace apiAgenciasBackend.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterRepositorios(services);
            AddRegisterServices(services);

            return services;
        }
        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IAgenciaService, AgenciasService>();

            return services;
        }

        private static IServiceCollection AddRegisterRepositorios(IServiceCollection services)
        {
            services.AddTransient<ILoginRepositorio, LoginRepositorio>();

            return services;
        }

        public static void AddAutoMapperSetup(ref IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            AutoMapperConfig.RegisterMappings();
        }

    }
}
