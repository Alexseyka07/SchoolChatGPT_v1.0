using Newtonsoft.Json;
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
        private string path;

        /// <summary>
        /// Конструктор класса Data, инициализирующий объект Data с предоставленными данными.
        /// </summary>
        public DataNeuralNetwork(NeuralNetwork neuralNetwork)
        {
            this.neuralNetwork = neuralNetwork;
           // path = Path.Combine(AppPath.GetPath(), "dataNeuralnetwork.json");
        }

        /// <summary>
        /// Пустой конструктор класса Data.
        /// </summary>
        public DataNeuralNetwork()
        {
            this.neuralNetwork = null;
            //path = Path.Combine(AppPath.GetPath(), "dataNeuralnetwork.json");
        }

        /// <summary>
        /// Получить данные из файла JSON.
        /// </summary>
        public DataNeuralNetwork GetData()
        {
            
             try
            {
                json = File.ReadAllText(path);
                DataNeuralNetwork data = JsonConvert.DeserializeObject<DataNeuralNetwork>(json);
                return data;
            }
             catch
             {
                 SetData(new NeuralNetwork(),100);
                 return this;
             }
        }

        /// <summary>
        /// Установить данные в файл JSON.
        /// </summary>
        public void SetData(NeuralNetwork neuralNetwork, double error)
        {
            UpdateData(neuralNetwork, error);
            DataNeuralNetwork data = this;
            json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
        }

        private void UpdateData(NeuralNetwork neuralNetwork, double error)
        {
            this.neuralNetwork = neuralNetwork;
            this.error = error;
        }
    }
}