using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace SchoolChatGPT_v1._0.Training
{
    public class Training
    {
        private List<Tuple<double, double[]>> trainingData;
        private Dictionary<string, int> wordsData;
        private Data data;
        private NeuralNetwork neuralNetwork;
        Topology topology;
        DataNeuralNetwork dataNeuralNetwork;
        double error;
        double learningRate = 0.2;
        int epochCount = 0;

        public Training()
        {
            data = new Data("data");
            data = data.GetData();
            trainingData = data.trainingData;
            wordsData = data.wordsData;
            topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: learningRate, layers: new int[] { 30, 4 });
            dataNeuralNetwork = new DataNeuralNetwork("dataNeuralnetwork11", topology);
        }

        public void TrainingNeuralNetwork()
        {           
            error = FirstLearning(topology);
            Console.WriteLine($"Ошибка после обучения: {error}");

            Thread thread = new Thread(Working);
            thread.Start();


        }
        private void Working()
        {
            while (true)
            {
                var text = Console.ReadLine();
                if (text == "l")
                {
                    error = neuralNetwork.Learn(trainingData, epoch: AddEpoch(30));

                    Console.WriteLine($"Ошибка после обучения: {error}");
                }
                else if (text == "stop") break;
                else if (text == "s")
                {
                    dataNeuralNetwork.SetData(neuralNetwork.Layers, error, learningRate, epochCount);
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
        public void WorkNeuralNetwork()
        {
            neuralNetwork = dataNeuralNetwork.GetData();
            error = dataNeuralNetwork.Error;
            learningRate = dataNeuralNetwork.LearningRate;

            while (true)
            {
                var text = Console.ReadLine();
                if (text == "l")
                {
                    
                    error = neuralNetwork.Learn(trainingData, epoch: AddEpoch(int.Parse(Console.ReadLine())));

                    Console.WriteLine($"Ошибка после обучения: {error}");
                }
                else if (text == "stop") break;
                else if (text == "s")
                {
                    dataNeuralNetwork.SetData(neuralNetwork.Layers, error, learningRate, epochCount);
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
            error = 100;
            Console.WriteLine("Этап 1");
            while (error > 10)
            {
                Console.WriteLine("restart");
                neuralNetwork = new NeuralNetwork(topology);
                error = neuralNetwork.Learn(trainingData, epoch: AddEpoch(30));               
            }
            Console.WriteLine(error);
            Console.WriteLine("Этап 2");
            while (error > 0.05)
            {
                error = neuralNetwork.Learn(trainingData, epoch: AddEpoch(30));
            }
            return error;
        }

        private double FirstLearning()
        {
            error = 100;
            //while (error > 10)
            {
               // neuralNetwork = new NeuralNetwork(null);
                error = neuralNetwork.Learn(trainingData, epoch: AddEpoch(10));
            }
           // while (error > 0.005)
            {
                error = neuralNetwork.Learn(trainingData, epoch: AddEpoch(10));
            }
            return error;
        }

        private int AddEpoch(int epoch)
        {
            epochCount += epoch;
            return epoch;
        }
    }
}