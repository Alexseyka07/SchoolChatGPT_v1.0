using Newtonsoft.Json;
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
        public double Error { get; set; }
        public double LearningRate { get; set; }
        public int EpochCount { get; set; }



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
            try
            {
                json = File.ReadAllText(path);
                DataNeuralNetwork data = JsonConvert.DeserializeObject<DataNeuralNetwork>(json);
                List<Layer> layers = data.Layers;
                NeuralNetwork neuralNetwork = new NeuralNetwork(topology, layers);
                Error = data.Error;
                LearningRate = data.LearningRate;
                EpochCount = data.EpochCount;
                return neuralNetwork;
            }
            catch
            {
                NeuralNetwork neuralNetwork = new NeuralNetwork(topology);
                SetData(neuralNetwork.Layers,100,0,0);
                return neuralNetwork;
            }
        }

        /// <summary>
        /// Установить данные в файл JSON.
        /// </summary>
        public void SetData(List<Layer> layers, double error, double learningRate, int epochCount)
        {
            UpdateData(layers, error, learningRate, epochCount);

            DataNeuralNetwork data = this;
            json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        private void UpdateData(List<Layer> layers, double error, double learningRate, int epochCount)
        {
            Layers = layers;
            Error = error;
            LearningRate = learningRate;
            EpochCount = epochCount;
        }
    }
}