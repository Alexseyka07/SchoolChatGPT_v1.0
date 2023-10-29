using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolChatGPT_v1._0.NeuralNetworkClasses
{
    /// <summary>
    /// Класс для хранения и управления данными нейронной сети.
    /// </summary>
    public class DataNeuralNetwork
    {
        public NeuralNetwork neuralNetwork;
        public double error;
        private string json;

        /// <summary>
        /// Конструктор класса Data, инициализирующий объект Data с предоставленными данными.
        /// </summary>
        public DataNeuralNetwork(NeuralNetwork neuralNetwork)
        {
            this.neuralNetwork = neuralNetwork;
        }

        /// <summary>
        /// Пустой конструктор класса Data.
        /// </summary>
        public DataNeuralNetwork()
        {
            this.neuralNetwork = null;
        }

        /// <summary>
        /// Получить данные из файла JSON.
        /// </summary>
        public DataNeuralNetwork GetData()
        {
           // try
            {
                json = File.ReadAllText(@"E:\Yandex Disk\YandexDisk\prodaction\GitHub\SchoolChatGPT_v1.0\SchoolChatGPT_v1.0\dataNeuralnetwork.json");
                DataNeuralNetwork data = JsonConvert.DeserializeObject<DataNeuralNetwork>(json);
                return data;
            }
           /* catch
            {
                SetData(new NeuralNetwork());
                return new DataNeuralNetwork();
            }*/
        }

        /// <summary>
        /// Установить данные в файл JSON.
        /// </summary>
        public void SetData(NeuralNetwork neuralNetwork,double error)
        {
            UpdateData(neuralNetwork,error);
            DataNeuralNetwork data = this;
            json = JsonConvert.SerializeObject(data);
            File.WriteAllText(@"E:\Yandex Disk\YandexDisk\prodaction\GitHub\SchoolChatGPT_v1.0\SchoolChatGPT_v1.0\dataNeuralnetwork.json", json);
        }

        private void UpdateData(NeuralNetwork neuralNetwork,double error)
        {
            this.neuralNetwork = neuralNetwork;
            this.error = error;
        }


    }
}
