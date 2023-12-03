using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;

namespace ShoolChat_Beta_v1._0.classes
{
    public class NeuralNetworkGPT
    {
        private NeuralNetwork neuralNetwork;
        private Dictionary<string, int> wordsData;
        private Data data;
        private DataNeuralNetwork dataNeuralNetwork;
        private Topology topology; 

        public NeuralNetworkGPT()
        {
            data = new Data("data");
            data = data.GetData();
            wordsData = data.wordsData;
            topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: 0.2, layers: new int[] { 30, 4 });
            dataNeuralNetwork = new DataNeuralNetwork("dataNeuralNetwork11", topology);
            neuralNetwork = dataNeuralNetwork.GetData();
        }

        private string GPTWorkAction(string message)
        {
            string answer = "error";

            Neuron outputNeuron = neuralNetwork.FeedForward(message, wordsData);
            var res = Math.Round(outputNeuron.Output, 3);
            answer = $"{(res >= 0.5 ? "задача" : "вопрос о правиле")}";
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