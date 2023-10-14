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

        /// <summary>
        /// Конструктор класса Data, инициализирующий объект Data с предоставленными данными.
        /// </summary>
        public Data(Dictionary<string, int> wordsData, List<Tuple<double, double[]>> trainingData)
        {
            this.wordsData = wordsData;
            this.trainingData = trainingData;
        }

        /// <summary>
        /// Пустой конструктор класса Data.
        /// </summary>
        public Data()
        {
            this.wordsData = null;
        }

        /// <summary>
        /// Получить данные из файла JSON.
        /// </summary>
        public Data GetData()
        {
            try
            {
                json = File.ReadAllText(@"E:\Yandex Disk\YandexDisk\prodaction\GitHub\SchoolChatGPT_v1.0\SchoolChatGPT_v1.0\data.json");
                Data data = JsonConvert.DeserializeObject<Data>(json);
                return data;
            }
            catch (Exception)
            {
                SetData(new Dictionary<string, int>(), new List<Tuple<double, double[]>>());
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
            File.WriteAllText(@"E:\Yandex Disk\YandexDisk\prodaction\GitHub\SchoolChatGPT_v1.0\SchoolChatGPT_v1.0\data.json", json);
        }

        private void UpdateData(Dictionary<string, int> wordsData, List<Tuple<double, double[]>> trainingData)
        {
            this.wordsData = wordsData;
            this.trainingData = trainingData;
        }
    }
}
