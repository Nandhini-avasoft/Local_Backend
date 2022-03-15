namespace Local_Backend.Helpers
{
    public class ServerConstants
    {
        public static EnvConfigurations EnvConfig { get; set; }
        public static string DBConnectionString { get; set; }
    }
    public  class EnvConfigurations
    {
        public string App_Env { get; set; }
    }
}
