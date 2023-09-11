
namespace PRN221.Team5.Web.Configuration
{
    public static class ServicesRegister
    {
        /// <summary>
        /// Extension method to register services to DI Container 
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection service)
        {


            return service;
        }
        /// <summary>
        /// Extension method to register repositories to DI Container
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            return service;
        }
    }
}
