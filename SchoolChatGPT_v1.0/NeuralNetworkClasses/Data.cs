using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolChatGPT_v1._0.NeuralNetworkClasses
{
    /// <summary>
    /// Класс для хранения и управления данными нейронной сети.
    /// </summary>
    public class Data
    {
        public Dictionary<string, int> wordsData;
        public List<Tuple<double, double[]>> trainingData;
        private string json;
        private string path;
        /// <summary>
        /// Конструктор класса Data, инициализирующий объект Data с предоставленными данными.
        /// </summary>
        public Data(Dictionary<string, int> wordsData, List<Tuple<double, double[]>> trainingData)
        {
            this.wordsData = wordsData;
            this.trainingData = trainingData;
            //path = Path.Combine(AppPath.GetPath(), "data.json");
        }

        /// <summary>
        /// Пустой конструктор класса Data.
        /// </summary>
        public Data()
        {
            this.wordsData = null;
           // path = Path.Combine(AppPath.GetPath(), "data.json");
        }

        /// <summary>
        /// Получить данные из файла JSON.
        /// </summary>
        public Data GetData()
        {
            try
            {
                json = File.ReadAllText(path);
                Data data = JsonConvert.DeserializeObject<Data>(json);
                return data;
            }
            catch
            {
                SetData(new Dictionary<string, int>() { { "Что", 1 } }, new List<Tuple<double, double[]>>());
                return new Data();
            }
        }

        /// <summary>
        /// Установить данные в файл JSON.
        /// </summary>
        public void SetData(Dictionary<string, int> wordsData, List<Tuple<double, double[]>> trainingData)
        {
            UpdateData(wordsData, trainingData);
            Data data = this;
            json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        private void UpdateData(Dictionary<string, int> wordsData, List<Tuple<double, double[]>> trainingData)
        {
            this.wordsData = wordsData;
            this.trainingData = trainingData;
        }
    }
}