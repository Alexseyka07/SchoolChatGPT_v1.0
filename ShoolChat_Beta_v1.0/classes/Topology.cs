using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoolChat_Beta_v1._0.classes
{
    public static class TopologyApp
    {
        public static NeuralNetworkGPT NetworkGPT1 { get; private set; }

        public static NeuralNetworkGPT NetworkGPT2 { get; private set; }
        public static string PathApp { get; private set; }

        public static void InitializeNeuralNetwork()
        {
            NetworkGPT1 = new NeuralNetworkGPT(1);
            NetworkGPT2 = new NeuralNetworkGPT(2);
        }
    }
}
