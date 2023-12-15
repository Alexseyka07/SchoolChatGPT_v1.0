using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using SetWordsForNeuralNetwork;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

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
        private string dataNum;

        public double LearningRate { get; set; } = 0.2;
        public int EpochCount { get; set; } = 0;
        public double Error { get; set; } = 0;

        private int num = 0;
        private int epoch;
        System.Windows.Controls.Label label;

        public NeuralNetworkGPT(int dataNum)
        {
           
            this.dataNum = dataNum.ToString();
            UpdateData();
            if(dataNum == 1)
                topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: 0.2, layers: new int[] { 30, 4 });
            if (dataNum == 2)
                topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: 0.4, layers: new int[] { 30, 15, 5 });
            dataNeuralNetwork = new DataNeuralNetwork($"dataNeuralNetwork{dataNum}", topology);
            neuralNetwork = dataNeuralNetwork.GetData();
            Error = dataNeuralNetwork.Error;
            EpochCount = dataNeuralNetwork.EpochCount;
            UpdateData();

        }
        private void UpdateData()
        {
            data = new Data($"data{dataNum}");
            data = data.GetData();
            wordsData = data.wordsData;
            trainingData = data.trainingData;
            
        }
        private string GPTWorkAction(string message)
        {
            string answer = "error";

            Neuron outputNeuron = neuralNetwork.FeedForward(message, wordsData);
            var res = Math.Round(outputNeuron.Output, 3);
            answer = $"{(res >= 0.5 ? "задача" : "вопрос о правиле")}";
            return answer;
        }
        public void DeLiteNN()
        {
            EpochCount = 0;
            Error = 100;
            neuralNetwork = new NeuralNetwork(topology);
        }
        public void Learning(int epo, string newDataNeuralNetwork, System.Windows.Controls.Label lbl)
        {
            epoch = epo;
            label = lbl;
            if (newDataNeuralNetwork != null && newDataNeuralNetwork != "") 
            {
                AddDataForNeuralNetwork addData = new AddDataForNeuralNetwork(data, newDataNeuralNetwork);
                addData.AddData();
                UpdateData();
                topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: LearningRate, layers: new int[] { 30, 4 });
                Error = 100;
               

                while (Error > 10)
                {
                    neuralNetwork = new NeuralNetwork(topology);
                    for (int i = 0; i < AddEpoch(30); i++)
                    {
                        Error = neuralNetwork.Learn(trainingData, epoch: 30);
                        num++;
                        Application.Current.Dispatcher.Invoke(UpdateLabel);
                    }
                }
                while (Error > 0.05)
                {
                    for (int i = 0; i < AddEpoch(epoch); i++)
                    {
                        Error = neuralNetwork.Learn(trainingData, epoch: epoch);
                        num++;
                        Application.Current.Dispatcher.Invoke(UpdateLabel);
                    }
                   
                }
                dataNeuralNetwork.SetData(neuralNetwork.Layers, Error, LearningRate, EpochCount);
                UpdateData();

            }
            else
            {
                Error = dataNeuralNetwork.Error;
                topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: LearningRate, layers: new int[] { 30, 4 });

                for (int i = 0; i < AddEpoch(epoch); i++)
                {
                    Error = neuralNetwork.Learn(trainingData, epoch: epoch);
                    num++;
                    Application.Current.Dispatcher.Invoke(UpdateLabel);
                }

                dataNeuralNetwork.SetData(neuralNetwork.Layers, Error, LearningRate, EpochCount);
                UpdateData();
            }




        }
        public void UpdateLabel()
        {
            label.Content = CalculatePercentage(num, epoch);
        }
        private double CalculatePercentage(double number, double total)
        {

            return (number / total) * 100;

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
            EpochCount += epoch;
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