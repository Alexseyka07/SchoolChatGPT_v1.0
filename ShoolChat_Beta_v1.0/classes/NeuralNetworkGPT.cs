using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace ShoolChat_Beta_v1._0.classes
{
    public class NeuralNetworkGPT
    {
        private NeuralNetwork neuralNetwork;
        private Dictionary<string, int> wordsData;
        private Data data;
        private DataNeuralNetwork dataNeuralNetwork;

        public NeuralNetworkGPT() 
        {
            dataNeuralNetwork = new DataNeuralNetwork();
            data = new Data();
            data = data.GetData();
            wordsData = data.wordsData;
            neuralNetwork = dataNeuralNetwork.neuralNetwork;
        }

        private string GPTWorkAction(string message)
        {

            string answer = "null";
            if (TopologyApp.PathApp != null)
            {
                Neuron outputNeuron1 = neuralNetwork.FeedForward(message, wordsData);
                var res = Math.Round(outputNeuron1.Output, 3);
                answer += $"       \n {(res >= 0.5 ? "задача" : "вопрос о правиле")}";
                return answer;
            }
            return answer;
        }
        public string GPTWork(string message)
        {
            Func<string, string> func = GPTWorkAction;
            IAsyncResult result = func.BeginInvoke(message, null, null);
            string gptAnswer = func.EndInvoke(result);
            return gptAnswer;
        }
    }
}
