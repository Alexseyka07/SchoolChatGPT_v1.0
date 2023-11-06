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
        static string path = AppDomain.CurrentDomain.BaseDirectory;
        public static string GetPath()
        {
            return path;
        }
    }
}
