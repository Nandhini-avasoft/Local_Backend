using System.ComponentModel;
using System.Reflection;

namespace Local_Backend.Helpers
{
    public class Utilities
    {
        public static string PostgresConnectionStringBuilder(string postgres_url)
        {
            try
            {
               
                var password = postgres_url.Split("://")[1].Split(":")[1].Split("@")[0];
                var host = postgres_url.Split("://")[1].Split(":")[1].Split("@")[1].Split("/")[0];
                var database = postgres_url.Split("://")[1].Split(":")[1].Split("@")[1].Split("/")[1];
                var port = 5432;

                if (ServerConstants.EnvConfig.App_Env == "Local")
                {
                    return "Password=N@ndhu@2;Host=localhost;Port=5432;Database=main;";
                }

                return $"Password={password};Host={host};Port={port};Database={database};";
            }
            catch (Exception ex)
            {
               
                return string.Empty;
            }
        }

        public static string ToStringEnums(Enum en)
        {
            System.Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
    }
}
