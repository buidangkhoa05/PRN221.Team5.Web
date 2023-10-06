using Team5.Domain.Common;

namespace PRN221.Team5.Web.Configuration
{
    public static class AppSettingsRegister
    {
        public static void BindingAppSetting(this IConfiguration configuration)
        {
            do
            {
                AppConfig.ConnectionStrings = new ConnectionStrings();
            }
            while (AppConfig.ConnectionStrings == null);

            configuration.Bind("ConnectionStrings", AppConfig.ConnectionStrings);
        }
    }
}
