using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SetWordsForNeuralNetwork
{
    public class Words
    {
        private Data data = new Data("data");
        private Dictionary<string, int> wordsData;

        public Words()
        {
            data = data.GetData();
        }

        public void SetWords(string sentences)
        {
            wordsData = data.wordsData;
            string[] wordsSentence;

            wordsSentence = RemovePunctuationAndSplit(sentences);
            for (int j = 0; j < wordsSentence.Length; j++)
            {
                if (!wordsData.ContainsKey(wordsSentence[j]))
                {
                    if (wordsSentence[j].Length > 1)
                        wordsData.Add(wordsSentence[j], wordsData.Count + 1);
                }
            }

            data.SetData(wordsData, data.trainingData);
            Console.WriteLine("Data Set");
        }

        private string[] RemovePunctuationAndSplit(string input)
        {
            // Используем регулярное выражение для удаления знаков препинания
            input = Regex.Replace(input, @"[\p{P}-[.]]", string.Empty);
            input = Regex.Replace(input,@"[$]",string.Empty);
            return input.Split();
        }
    }
}