using System.Configuration;

namespace Untils_Config
{
    public class UIConfig
    {
        public static readonly string WebDAL = ConfigurationManager.AppSettings["FRMDAL"];
    }
}
