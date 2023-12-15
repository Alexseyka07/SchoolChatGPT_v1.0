using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Input;
using SchoolChatGPT_v1._0.NeuralNetworkClasses;

namespace ShoolChat_Beta_v1._0.classes
{
    public class Learning
    {
        private Button firstStage_Button;
        public Button start_button;
        public Button cancellation_Button;
        public TextBox learningRate_TextBox;
        public TextBox newData_TextBox;
        public TextBox epochCount_TextBox;
        public Label progress_Label;
        public Label learningRate_Label, error_Label, epochCount_Label;
        private NeuralNetworkGPT NetworkGPT;
        private string newDataNeuralNetwork;
        private int epoch;
        private double learningRate;
        private event Action EndLean;
        public Learning(Button firstStage_Button, Button start_button, Button cancellation_Button,TextBox learningRate_TextBox, 
            TextBox newData_TextBox, Label progress_Label, TextBox epochCount_TextBox,
            Label learningRate_Label, Label error_Label, Label epochCount_Label) 
        { 
            this.firstStage_Button = firstStage_Button;
            this.start_button = start_button;
            this.cancellation_Button = cancellation_Button;
            this.learningRate_TextBox = learningRate_TextBox;
            this.newData_TextBox = newData_TextBox;
            this.epochCount_TextBox = epochCount_TextBox;
            this.progress_Label = progress_Label;
            this.learningRate_Label = learningRate_Label;
            this.progress_Label = progress_Label;
            this.error_Label = error_Label;
            this.epochCount_Label = epochCount_Label;
            NetworkGPT = TopologyApp.NetworkGPT1;
            if (NetworkGPT.IsInitNeuralNetwork())
            {
                cancellation_Button.IsEnabled = true;
                learningRate = NetworkGPT.LearningRate;
                learningRate_TextBox.Text = learningRate.ToString();
                learningRate_TextBox.IsEnabled = false;

                EndLean += EndLeaning;
            }
        }
        private void UpdateInformation()
        {
            learningRate_Label.Content = "Темп обучения(learning rate):" + NetworkGPT.LearningRate;
            error_Label.Content = "Коэффициент ошибки: " + NetworkGPT.Error;
            epochCount_Label.Content = "Эпох обучения пройдено: " + NetworkGPT.EpochCount;
            newData_TextBox.Text = null;
            epochCount_TextBox.Text = null;
        }
        public void CheckStart()
        {
            if(learningRate != null && epoch != null)
            {
                start_button.IsEnabled = true;
            }

        }

        public void FirstStage_Button_Click(object sender, RoutedEventArgs e)
        {
            NetworkGPT = TopologyApp.NetworkGPT1;
            UpdateInformation();
        }
        public void SecondStage_Button_Click(object sender, RoutedEventArgs e)
        {
            NetworkGPT = TopologyApp.NetworkGPT2;
            UpdateInformation();
        }
        public void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            start_button.IsEnabled = false;
            progress_Label.Content = "Колдуем в моменте!";
            Thread thread = new Thread(Work); thread.Start();
        }
      
        
        public void Work()
        { 

            NetworkGPT.Learning(epoch, newDataNeuralNetwork, progress_Label);
            Application.Current.Dispatcher.Invoke(EndLeaning);
        }

        public void Cancellation_Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
        public void EndLeaning()
        {
            progress_Label.Content = "Готово";
            UpdateInformation();
        }
        public void EpochCount_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            try
            {
                epoch = int.Parse(textBox.Text);
            }
           catch { }
            CheckStart();
        }

        public void LearningRate_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            try
            {
                learningRate = double.Parse(textBox.Text);
            }
            catch { }
      
            CheckStart();
        }
    
        public void NewData_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            try
            {
                newDataNeuralNetwork = textBox.Text;
            }
            catch { }
            
            CheckStart();
        }


    }
}
