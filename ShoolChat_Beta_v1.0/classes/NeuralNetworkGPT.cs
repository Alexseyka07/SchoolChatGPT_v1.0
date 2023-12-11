using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using SetWordsForNeuralNetwork;
using System;
using System.Collections.Generic;

namespace ShoolChat_Beta_v1._0.classes
{
    public class NeuralNetworkGPT
    {
        private NeuralNetwork neuralNetwork;
        private Dictionary<string, int> wordsData;
        private List<Tuple<double, double[]>> trainingData = new List<Tuple<double, double[]>>();
        private Data data;
        private DataNeuralNetwork dataNeuralNetwork;
        private Topology topology;

        public double LearningRate { get; set; } = 0.2;
        int epochCount = 0;
        private double error;
        private Topology newTopology;

        public NeuralNetworkGPT()
        {
            UpdateData();
            topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: 0.2, layers: new int[] { 30, 4 });
            dataNeuralNetwork = new DataNeuralNetwork("dataNeuralNetwork11", topology);
            neuralNetwork = dataNeuralNetwork.GetData();
        }
        private void UpdateData()
        {
            data = new Data("data");
            data = data.GetData();
            wordsData = data.wordsData;
          
        }
        private string GPTWorkAction(string message)
        {
            string answer = "error";

            Neuron outputNeuron = neuralNetwork.FeedForward(message, wordsData);
            var res = Math.Round(outputNeuron.Output, 3);
            answer = $"{(res >= 0.5 ? "задача" : "вопрос о правиле")}";
            return answer;
        }
        public void Learning(int epoch, string newDataNeuralNetwork)
        {
            if(newDataNeuralNetwork != null) 
            {
                AddDataForNeuralNetwork addData = new AddDataForNeuralNetwork(data, newDataNeuralNetwork);
                addData.AddData();
                UpdateData();
                newTopology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: LearningRate, layers: new int[] { 30, 4 });
                error = 100;
              
               
                while (error > 10)
                {
                    neuralNetwork = new NeuralNetwork(topology);
                    error = neuralNetwork.Learn(trainingData, epoch: AddEpoch(30));
                }
                while (error > 0.05)
                {
                    error = neuralNetwork.Learn(trainingData, epoch: AddEpoch(30));
                }
                UpdateData();
            }
            
            


        }
        public bool IsInitNeuralNetwork()
        {
            if(dataNeuralNetwork.Layers != null)
            {
                return false;
            }
            return true;
        }
        private int AddEpoch(int epoch)
        {
            epochCount += epoch;
            return epoch;
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