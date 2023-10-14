using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SchoolChatGPT_v1._0.Training
{
    public class Training
    {
        // Создаем обучающий набор данных (примеры: ожидаемый результат, входные данные)
        private List<Tuple<double, double[]>> trainingData = new List<Tuple<double, double[]>>()
        {

           
        };
        private Data data;
        private Dictionary<string, int> wordsData;
        public Training()
        {
            data = new Data(); 
            data = data.GetData();
        }
        public void TrainingNeuralNetwork()
        {
            Topology topology = new Topology(inputCount: Vocalulary.Vocabulary.Count, outputCount: 1, learningRate: 0.9, layers: new int[] { 4 });

            // Создаем нейронную сеть
            NeuralNetwork neuralNetwork = new NeuralNetwork(topology);

         
            Console.WriteLine("Обучение");
            Console.WriteLine("0 - пример о вопросе или 1 - задача");
            for (int i = 0; i < 50; i++)
            {
                Vocalulary.Learning();
            }

            // Обучаем нейронную сеть

            double error = neuralNetwork.Learn(Vocalulary.TrainingData, epoch: 100000);

            Console.WriteLine($"Ошибка после обучения: {error}");
        }
        private List<Tuple<double, double[]>> SetQuetions()
        {
            
            var wordsOfQuetion = Console.ReadLine().Split();                    
           var vector = new double[wordsData.Count];
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = 0;
                }
            for (int i = 0; i < wordsOfQuetion.Length; i++)
            {
                if (wordsData.ContainsKey(wordsOfQuetion[i]))
                {
                    var num = wordsData[wordsOfQuetion[i]];
                    vector[num - 1] = 1.0;
                }
            }
            bool a = false;

                for (int i = 0; i < trainingData.Count; i++)
                {
                    if (vector == trainingData[i].Item2) a = true;
                }
                if (!a)
                {
                    var input = double.Parse(Console.ReadLine());
                    trainingData.Add(new Tuple<double, double[]>(input, vector));
                }
        }
    }
}