namespace Architect.Web
{
    public class Settings
    {
        public static Settings Instance = new Settings();

        public string JwtSecret { get; set; }
        public string JwtAudience { get; set; }
        public string JwtIssuer { get; set; }
        public int JwtExpiresMinutes { get; set; }

        public Settings()
        {
            JwtSecret = string.Empty;
            JwtAudience = string.Empty;
            JwtIssuer = string.Empty;
        }
    }
}
