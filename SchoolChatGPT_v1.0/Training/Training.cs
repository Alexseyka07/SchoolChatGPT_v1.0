using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace SchoolChatGPT_v1._0.Training
{
    public class Training
    {
        private List<Tuple<double, double[]>> trainingData;
        private Dictionary<string, int> wordsData;
        private Data data;
        private NeuralNetwork neuralNetwork;

        public Training()
        {
            data = new Data();
            data = data.GetData();
            trainingData = data.trainingData;
            wordsData = data.wordsData;
        }

        public void TrainingNeuralNetwork()
        {
            Topology topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: 0.4, layers: new int[] { 30, 4 });

            double error = FirstLearning(topology);
            Console.WriteLine($"Ошибка после обучения: {error}");

            while (true)
            {
                var text = Console.ReadLine();
                if (text == "1")
                {
                    error = neuralNetwork.Learn(trainingData, epoch: 10);

                    Console.WriteLine($"Ошибка после обучения: {error}");
                }
                else if (text == "stop") break;
                else if(text == "s")
                {
                    DataNeuralNetwork dataNeuralNetwork = new DataNeuralNetwork();
                    dataNeuralNetwork.SetData(neuralNetwork, error);
                }
                else
                {
                    Neuron outputNeuron1 = neuralNetwork.FeedForward(text, wordsData);
                    var res = Math.Round(outputNeuron1.Output, 3);
                    Console.WriteLine($"Классификация вопроса 1: {(res >= 0.5 ? "задача" : "вопрос о правиле")}");
                }
            }
        }
        public void WorkNeuralNetwork()
        {
            DataNeuralNetwork dataNeuralNetwork = new DataNeuralNetwork();
            dataNeuralNetwork = dataNeuralNetwork.GetData();
            neuralNetwork = dataNeuralNetwork.neuralNetwork;
            double error = dataNeuralNetwork.error;
            Console.WriteLine($"Ошибка: {error}");

            while (true)
            {
                var text = Console.ReadLine();
                if (text == "1")
                {
                    error = neuralNetwork.Learn(trainingData, epoch: 10);

                    Console.WriteLine($"Ошибка после обучения: {error}");
                }
                else if (text == "stop") break;
                else if (text == "s")
                {
                    dataNeuralNetwork.SetData(neuralNetwork, error);
                    Console.WriteLine("Save finish");
                }
                else
                {
                    Neuron outputNeuron1 = neuralNetwork.FeedForward(text, wordsData);
                    var res = Math.Round(outputNeuron1.Output, 3);
                    Console.WriteLine($"Классификация вопроса 1: {(res >= 0.5 ? "задача" : "вопрос о правиле")}");
                }
            }
        }
        private double FirstLearning(Topology topology)
        {
            double error = 100;
            while (error > 10)
            {
                neuralNetwork = new NeuralNetwork(topology);
                error = neuralNetwork.Learn(trainingData, epoch: 10);
            }
            while (error > 0.005)
            {
                error = neuralNetwork.Learn(trainingData, epoch: 10);
            }
            return error;
        }

        private double FirstLearning()
        {
            double error = 100;
            while (error > 10)
            {
                neuralNetwork = new NeuralNetwork();
                error = neuralNetwork.Learn(trainingData, epoch: 10);
            }
            while (error > 0.005)
            {
                error = neuralNetwork.Learn(trainingData, epoch: 10);
            }
            return error;
        }
    }
}