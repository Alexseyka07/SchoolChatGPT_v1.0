using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetWordsForNeuralNetwork
{
    public class AddDataForNeuralNetwork
    {
        private Data data;
        private string newDataForNN;

        public AddDataForNeuralNetwork(Data data, string newDataForNN)
        {
            this.data = data;
            this.newDataForNN = newDataForNN;
        }

        public void AddData()
        {
            Sentences sentences = new Sentences(newDataForNN, data);
            sentences.SetTrainingData();
        }
    }
}
