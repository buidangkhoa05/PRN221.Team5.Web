using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
using System.CodeDom;
using Team5.Domain.Common;
using Team5.Infrastructure.DBContext;
using Team5.Infrastructure.Repository;
using PRN221.Team5.Domain.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Application.Service.Interface;

namespace PRN221.Team5.Web.Configuration
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            //services.AddIdentity<User, IdentityRole>()
            //    .AddEntityFrameworkStores<IdsDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAnimalService, AnimalService>();
        }


        public static void AddDbContext(this IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //               options.UseSqlServer(AppConfig.ConnectionStrings.DefaultConnection));

            //services.AddDbContext<IdsDbContext>(options => options.UseSqlServer(AppConfig.ConnectionStrings.DefaultConnection));
        }
    }
}
