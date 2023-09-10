namespace PRN221.Team5.Domain.Common
{
    public class AppConfig
    {
        public static ConnectionStrings ConnectionStrings { get; set; }
    }

    public class  ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
