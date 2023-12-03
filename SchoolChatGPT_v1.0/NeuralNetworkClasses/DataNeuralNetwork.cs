﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Settings;

namespace SchoolChatGPT_v1._0.NeuralNetworkClasses
{
    /// <summary>
    /// Класс для хранения и управления данными нейронной сети.
    /// </summary>
    public class DataNeuralNetwork
    {
        private Topology topology;
        private string path;
        private string name;
        private string json;
        public List<Layer> Layers { get; set; }



        /// <summary>
        /// Пустой конструктор класса Data.
        /// </summary>
        public DataNeuralNetwork(string name, Topology topology)
        {
            this.topology = topology;
            this.name = name;
            path = Path.Combine(Settings.Settings.AppPath, $"{name}.json");
        }

        /// <summary>
        /// Получить данные из файла JSON.
        /// </summary>
        public NeuralNetwork GetData()
        {
           // try
            {
                json = File.ReadAllText(path);
                DataNeuralNetwork data = JsonConvert.DeserializeObject<DataNeuralNetwork>(json);
                List<Layer> layers = data.Layers;
                NeuralNetwork neuralNetwork = new NeuralNetwork(topology, layers);
                return neuralNetwork;
            }
           /* catch
            {
                NeuralNetwork neuralNetwork = new NeuralNetwork();
                SetData(neuralNetwork);
                return neuralNetwork;
            }*/
        }

        /// <summary>
        /// Установить данные в файл JSON.
        /// </summary>
        public void SetData(List<Layer> layers)
        {
            UpdateData(layers);

            DataNeuralNetwork data = this;
            json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        private void UpdateData(List<Layer> layers)
        {
            Layers = layers;
        }
    }
}