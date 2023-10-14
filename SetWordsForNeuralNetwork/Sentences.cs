using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SetWordsForNeuralNetwork
{
    public class Sentences
    {
        // Создаем обучающий набор данных (примеры: ожидаемый результат, входные данные)
        private List<Tuple<double, double[]>> trainingData = new List<Tuple<double, double[]>>()
        {
        };

        private Data data;
        private Dictionary<string, int> wordsData;
        private List<Tuple<double, string>> sentencesAndValue;
        private string sentences;
        public Sentences(string sentences)
        {
            data = new Data();
            data = data.GetData();
        }
        private List<Tuple<double,string>> SetSentences(string sentences) 
        {
            List < Tuple<double, string> > result = new List<Tuple<double, string>>();
            string[] arraySentensesAndValue = sentences.Split(':');
            for (int i = 0; i < arraySentensesAndValue.Length; i++)
            {
                try
                {
                    string[] array = arraySentensesAndValue[i].Split('$');
                    double value = int.Parse(array[0]);
                    result.Add(new Tuple<double, string>(value, RemovePunctuation(array[i])));
                }
                catch 
                {
                
                }
            }
            return result;
        }
        public void SetQuetions()
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
        private string RemovePunctuation(string input)
        {
            // Используем регулярное выражение для удаления знаков препинания
            input = Regex.Replace(input, @"[\p{P}-[.]]", string.Empty);

            return input;
        }
    }
}
