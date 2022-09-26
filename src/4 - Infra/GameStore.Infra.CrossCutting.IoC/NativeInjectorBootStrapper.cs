using AutoMapper;
using GameStore.Application.Interfaces;
using GameStore.Application.Services;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace GameStore.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IGameServices, GameServices>();
            services.AddTransient<ICompanyServices, CompanyServices>();
            services.AddTransient<IGenreServices, GenreServices>();
            services.AddTransient<IOrderServices, OrderServices>();
            services.AddTransient<IPlatformServices, PlatformServices>();
            services.AddTransient<IReviewServices, ReviewServices>();
            services.AddTransient<ICartServices, CartServices>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddScoped<RoleManager<IdentityRole>>();
            services.AddScoped<UserManager<IdentityUser>>();
        }
    }
}