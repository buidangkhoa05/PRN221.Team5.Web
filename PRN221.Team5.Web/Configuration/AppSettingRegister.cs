namespace PRN221.Team5.Web.Configuration
{
    public static class AppSettingRegister
    {
        public static void BindingSetting(this IConfiguration configuration)
        {
            do
            {
                AppConfig.ConnectionStrings = new ConnectionStrings();
            } while (AppConfig.ConnectionStrings == null);

            configuration.Bind("ConnectionStrings", AppConfig.ConnectionStrings);
        }
    }
}
