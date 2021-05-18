using System.Configuration;

namespace Cmd.Helpers
{
    public static class AppSettings
    {
        static AppSettings()
        {
            TelegramToken = ConfigurationManager.AppSettings.Get("token");
        }

        public static string TelegramToken { get; }
    }
}
