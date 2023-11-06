using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolChatGPT_v1._0.NeuralNetworkClasses
{
    public static class AppPath
    {
        public static string PathApp { get; private set; }

        public static void SetPath(string path)
        {
            PathApp = path;
        }
        
    }
}
