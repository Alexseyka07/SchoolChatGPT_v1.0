using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SetWordsForNeuralNetwork
{
    public class Sentences
    {
        // Создаем обучающий набор данных (примеры: ожидаемый результат, входные данные)
        private List<Tuple<double, double[]>> trainingData = new List<Tuple<double, double[]>>()
        {
        };

        private Data data; // Создаем экземпляр класса Data
        private Dictionary<string, int> wordsData; // Создаем словарь для хранения слов и их значений
        private string newData;

        public Sentences(string newData, Data data)
        {            
            this.data = data;
            wordsData = data.wordsData;
            trainingData = data.trainingData;
            this.newData = newData;
        }

        public List<Tuple<double, string>> SetSentences(string sentences)
        {
            List<Tuple<double, string>> result = new List<Tuple<double, string>>();

            // Разбиваем входные предложения на части, разделенные символом ":"
            string[] arraySentensesAndValue = sentences.Split(':');

            for (int i = 0; i < arraySentensesAndValue.Length; i++)
            {
                try
                {
                    // Разбиваем каждую часть на две части, разделенные символом "$"
                    string[] array = arraySentensesAndValue[i].Split('$');
                    double value = int.Parse(array[1]); // Преобразуем вторую часть в число
                    string sentense = RemovePunctuation(array[0]); // Удаляем пунктуацию из первой части
                    
                    result.Add(new Tuple<double, string>(value, sentense)); // Добавляем результат в список
                    
                }
                catch
                {
                    // Обработка исключения, если произошла ошибка при парсинге или других операциях
                }
            }

            return result; // Возвращаем список результатов
        }

        public void SetTrainingData()
        {
            string inputWords = Regex.Replace(newData, "1", " ");
            inputWords = Regex.Replace(newData, "0", " ");
            SetWords(inputWords);
            List<Tuple<double, string>> sentenses = SetSentences(newData);
           
            
            for (int i = 0; i < sentenses.Count; i++)
            {
                var vector = new double[wordsData.Count];
                for (int x = 0; x < vector.Length; x++)
                {
                    vector[x] = 0;
                }
                var wordsOfQuetion = sentenses[i].Item2.Split(); // Читаем входные слова из консоли и разделяем их на части

                for (int j = 0; j < wordsOfQuetion.Length; j++)
                {
                    if (wordsData.ContainsKey(wordsOfQuetion[j]))
                    {
                        var num = wordsData[wordsOfQuetion[j]]; // Получаем номер слова
                        vector[num - 1] = 1.0;
                    }
                }

                bool a = false;

                for (int j = 0; j < trainingData.Count; j++)
                {
                    if (vector == trainingData[j].Item2) a = true; // Проверяем, существует ли вектор в обучающем наборе
                }

                if (!a)
                {
                    trainingData.Add(new Tuple<double, double[]>(sentenses[i].Item1, vector)); // Добавляем в обучающий набор
                }
            }
            data.SetData(wordsData, trainingData);
        }
        private void SetWords(string input)
        {
            Console.WriteLine("Введите слова:");
            Words words = new Words();
            words.SetWords(newData);
        }
        private string RemovePunctuation(string input)
        {
            // Используем регулярное выражение для удаления знаков препинания
            input = Regex.Replace(input, @"[\p{P}-[.]]", string.Empty);

            return input;
        }
    }
}