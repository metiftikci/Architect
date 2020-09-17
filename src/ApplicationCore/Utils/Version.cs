using System.Reflection;

namespace Architect.ApplicationCore.Utils
{
    public static class Version
    {
        public static string GetVersion()
        {
            var gitVersionInformationType = Assembly.GetExecutingAssembly().GetType("GitVersionInformation");

            return gitVersionInformationType.GetField("InformationalVersion").GetValue(null).ToString();
        }
    }
}
