namespace APIDemo.DAL
{
    public class DAL_Helpers
    {
        public static string myConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");
    }
}
