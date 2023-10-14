using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolChatGPT_v1._0.NeuralNetworkClasses
{
    public class Data
    {
        public Dictionary<string, int> wordsData;
        public List<Tuple<double, double[]>> trainingData;
        private string json;

        // public Dictionary<string, int> WordsData { get { return wordsData; } }
        // public List<Tuple<double, double[]>> TrainingData { get { return trainingData; } }
        public Data(Dictionary<string, int> wordsData, List<Tuple<double, double[]>> trainingData)
        {
            this.wordsData = wordsData;
            this.trainingData = trainingData;
        }

        public Data()
        {
            this.wordsData = null;
        }

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
                SetData(new Dictionary<string, int>(), new List<Tuple<double, double[]>>()); return new Data();
            }
        }

        public void SetData(Dictionary<string, int> wordsData, List<Tuple<double, double[]>> trainingData)
        {
            UpdateData(wordsData, trainingData);
            Data data = this;
            json = JsonConvert.SerializeObject(data);
            File.WriteAllText(@"E:\Yandex Disk\YandexDisk\prodaction\GitHub\SchoolChatGPT_v1.0\SchoolChatGPT_v1.0\data.json", json);
        }

        public void SetData()
        {
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