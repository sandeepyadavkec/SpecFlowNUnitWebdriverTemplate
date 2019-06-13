using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PlanITFacebookProj.Utils
{
    class Helper
    {
        public String GetConfigByKey(String keyString)
        {
            return ConfigurationManager.AppSettings[keyString];
        }

        public String GetCurrentDir()
        {
            var path = System.IO.Path.GetDirectoryName(
            System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = path.Substring(6);
            return path;

        }
    }
}
