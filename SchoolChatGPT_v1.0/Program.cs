using SchoolChatGPT_v1._0.Set_Words;
using System;

namespace SchoolChatGPT_v1._0
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Words words = new Words();
            words.SetWords(Console.ReadLine());
            Console.ReadLine();
            // Создаем топологию сети
            /*Topology topology = new Topology(inputCount: Vocalulary.Vocabulary.Count, outputCount: 1, learningRate: 0.9, layers: new int[] { 4 });

            // Создаем нейронную сеть
            NeuralNetwork neuralNetwork = new NeuralNetwork(topology);

            // Создаем обучающий набор данных (примеры: ожидаемый результат, входные данные)
            List<Tuple<double, double[]>> trainingData = new List<Tuple<double, double[]>>()
        {
            new Tuple<double, double[]>(0, new double[] { 1, 1 , 1,0,0 }), // Пример "вопрос о правиле"
            new Tuple<double, double[]>(0, new double[] { 1, 0 , 0,0,0 }), // Пример "вопрос о правиле"
            new Tuple<double, double[]>(0, new double[] { 1, 1, 0,0 , 0 }), // Пример "вопрос о правиле"
            new Tuple<double, double[]>(0, new double[] { 1, 0, 1,1,1 }),
            new Tuple<double, double[]>(0, new double[] { 1, 0, 0,1,1 }),
            new Tuple<double, double[]>(0, new double[] { 0, 0, 1,0 ,0}), // Пример "задача"
            new Tuple<double, double[]>(1, new double[] { 0, 0, 0,1,0 }), // Пример "задача"
            new Tuple<double, double[]>(1, new double[] { 0, 0, 0,0,0 }), // Пример "задача"
            new Tuple<double, double[]>(1, new double[] { 1, 0, 0,1,1 }),
            new Tuple<double, double[]>(1, new double[] { 0, 0, 0,1,0 }),
            new Tuple<double, double[]>(1, new double[] { 0, 1, 0,1,1 }),
            new Tuple<double, double[]>(1, new double[] { 0, 1, 0,0,1 }),
            new Tuple<double, double[]>(1, new double[] { 0, 0, 0,0,1 }),
            // Добавьте другие обучающие примеры здесь
        };
            /* Console.WriteLine("Обучение");
             Console.WriteLine("0 - пример о вопросе или 1 - задача");
             for (int i = 0; i < 50; i++)
             {
                 Vocalulary.Learning();
             }
             Vocalulary.SaveJson();*/
            // Обучаем нейронную сеть/*
            /*
            double error = neuralNetwork.Learn(Vocalulary.TrainingData, epoch: 100000);

            Console.WriteLine($"Ошибка после обучения: {error}");

            // Пример классификации новых вопросов
            while (true)
            {
                var text = Console.ReadLine();
                Neuron outputNeuron1 = neuralNetwork.FeedForward(text, Vocalulary.Vocabulary);
                var res = Math.Round(outputNeuron1.Output, 3);
                Console.WriteLine($"Классификация вопроса 1: {(res >= 0.5 ? "задача" : "вопрос о правиле")}");
            }
            */
        }
    }
}