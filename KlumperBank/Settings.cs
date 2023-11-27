namespace KlumperBank
{
    public static class Settings
    {
        public static string JwtKey = "fedaf7d8863b48e197b9287d492b708e";

        public static string ApiKeyName = "api_key";
        public static string ApiKey = "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";
        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; } // = "smtp.sendgrid.net";
            public int Port { get; set; } //= 465;
            public string UserName { get; set; } //= "apikey";
            public string Password { get; set; } //= "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";
        }
    }
}
