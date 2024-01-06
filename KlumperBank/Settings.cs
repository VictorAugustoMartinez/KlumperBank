namespace KlumperBank
{
    public static class Settings
    {
        public static string JwtKey { get; set; } = "fedaf7d8863b48e197b9287d492b708e";

        public static SmtpConfiguration Smtp = new();
        
        public class SmtpConfiguration
        {
            public string Host { get; set; } 
            public int Port { get; set; } 
            public string UserName { get; set; } 
            public string Password { get; set; } 
        }
    }
}
