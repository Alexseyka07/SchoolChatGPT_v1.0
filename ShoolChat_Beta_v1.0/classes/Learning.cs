using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ShoolChat_Beta_v1._0.classes
{
    public class Learning
    {
        private Button firstStage_Button;
        public Button start_button;
        public Button cancellation_Button;
        public TextBox learningRate_TextBox;

        private string newDataNeuralNetwork;
        private int epoch;
        private double learningRate;
        public Learning(Button firstStage_Button, Button start_button, Button cancellation_Button,TextBox learningRate_TextBox) 
        { 
            this.firstStage_Button = firstStage_Button;
            this.start_button = start_button;
            this.cancellation_Button = cancellation_Button;
            this.learningRate_TextBox = learningRate_TextBox;

            if (TopologyApp.NetworkGPT.IsInitNeuralNetwork())
            {
                cancellation_Button.IsEnabled = true;
                learningRate = TopologyApp.NetworkGPT.LearningRate;
                learningRate_TextBox.Text = learningRate.ToString();
                learningRate_TextBox.IsEnabled = false;
                
            }
        }

        public void CheckStart()
        {
            if(learningRate != null && epoch != null && newDataNeuralNetwork != null)
            {
                start_button.IsEnabled = true;
            }
        }

        public void FirstStage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Start_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Cancellation_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void EpochCount_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            epoch = int.Parse(textBox.Text);
            CheckStart();
        }

        public void LearningRate_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            learningRate = double.Parse(textBox.Text);
            CheckStart();
        }
    
        public void NewData_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            newDataNeuralNetwork = textBox.Text;
            CheckStart();
        }


    }
}
