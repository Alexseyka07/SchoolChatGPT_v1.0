using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using SchoolChatGPT_v1._0.Training;
using System;

namespace SchoolChatGPT_v1._0
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {
            

            Training.Training training = new Training.Training();
            training.WorkNeuralNetwork();

            
            Console.ReadLine();
            
        }
    }
}