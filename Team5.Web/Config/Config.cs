//using PRN221.Team5.Application.Service.Implement;
//using PRN221.Team5.Application.Service.Interface;
//using Team5.Application.Repository;
//using Team5.Infrastructure.Repository;

using PRN221.Team5.Application.Service.Implement;
using PRN221.Team5.Application.Service.Interface;
using Team5.Application.Repository;
using Team5.Infrastructure.Repository;

namespace Team5.Web.Config
{
    public static class Config
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
            services.AddScoped<ICageService, CageService>();
            services.AddScoped<ITrainerService, TrainerService>();
        }


        public static void AddDbContext(this IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //               options.UseSqlServer(AppConfig.ConnectionStrings.DefaultConnection));

            //services.AddDbContext<IdsDbContext>(options => options.UseSqlServer(AppConfig.ConnectionStrings.DefaultConnection));
        }
    }
}
