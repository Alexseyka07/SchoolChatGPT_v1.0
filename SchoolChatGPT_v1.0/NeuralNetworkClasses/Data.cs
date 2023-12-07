using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Settings;


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
        private string name;
       

        /// <summary>
        /// Пустой конструктор класса Data.
        /// </summary>
        [JsonConstructor]
        public Data(string name)
        {
            this.wordsData = null;
            this.name = name;
            path = Path.Combine(Settings.Settings.AppPath, "data.json");
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
                return new Data("data");
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