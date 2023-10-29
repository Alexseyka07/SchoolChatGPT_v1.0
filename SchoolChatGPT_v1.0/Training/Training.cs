using Newtonsoft.Json.Serialization;
using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SchoolChatGPT_v1._0.Training
{
    public class Training
    {
        // Создаем обучающий набор данных (примеры: ожидаемый результат, входные данные)
        private List<Tuple<double, double[]>> trainingData;
        

        private Dictionary<string, int> wordsData;
        private Data data;

        public Training()
        {
            data = new Data();
            data = data.GetData();
            trainingData = data.trainingData;
            wordsData = data.wordsData;
        }

        public void TrainingNeuralNetwork()
        {

           
            Topology topology = new Topology(inputCount: wordsData.Count, outputCount: 1, learningRate: 0.4, layers: new int[] { 30, 4});

            // Создаем нейронную сеть
            NeuralNetwork neuralNetwork = new NeuralNetwork(topology);
            double error = 100;
            // Обучаем нейронную сеть
            while (error > 10)
            {
                neuralNetwork = new NeuralNetwork(topology);
                error = neuralNetwork.Learn(trainingData, epoch: 10);
            }
            while(error > 0.005)
            {
               
                error = neuralNetwork.Learn(trainingData,epoch: 10);

            }

            Console.WriteLine($"Ошибка после обучения: {error}");

            while (true)
            {
                var text = Console.ReadLine();
                if (text == "1")
                {
                    double error1 = neuralNetwork.Learn(trainingData, epoch: 10);

                    Console.WriteLine($"Ошибка после обучения: {error1}");
                }
                else if (text == "stop") break;
                else
                {
                    Neuron outputNeuron1 = neuralNetwork.FeedForward(text, wordsData);
                    var res = Math.Round(outputNeuron1.Output, 3);
                    Console.WriteLine($"Классификация вопроса 1: {(res >= 0.5 ? "задача" : "вопрос о правиле")}");
                }
            }
        }
    }
}