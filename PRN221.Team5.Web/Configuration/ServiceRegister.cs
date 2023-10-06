using Microsoft.EntityFrameworkCore;
using Team5.Application.Repository;
using System.CodeDom;
using Team5.Domain.Common;
using Team5.Infrastructure.DBContext;
using Team5.Infrastructure.Repository;

namespace PRN221.Team5.Web.Configuration
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }


        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseSqlServer(AppConfig.ConnectionStrings.DefaultConnection));
        }
    }
}
