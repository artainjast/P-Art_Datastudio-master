using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayeshEngine
{
    public class GlobalSetting
    {
        public static string ConnectionServerPanel = ConfigurationManager.AppSettings["ConnectionServerPanel"];
        public static string ConnectionServerReader = ConfigurationManager.AppSettings["ConnectionServerReader"];
        public static string ConnectionServer3 = ConfigurationManager.AppSettings["ConnectionServer3"];
        public static string ConnectionServer4 = ConfigurationManager.AppSettings["ConnectionServer4"];
    }
}
