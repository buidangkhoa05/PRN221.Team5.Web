

namespace PRN221.Team5.Web.Configuration
{
    public static class DbRegister
    {
        /// <summary>
        /// add db config
        /// </summary>
        /// <param name="services"></param>
        public static void AddDbConfig(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(AppConfig.ConnectionStrings.DefaultConnection);
            });
        }
    }
}
