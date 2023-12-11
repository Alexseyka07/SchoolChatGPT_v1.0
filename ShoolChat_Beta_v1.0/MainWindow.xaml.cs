using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ShoolChat_Beta_v1._0.classes;


namespace ShoolChat_Beta_v1._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Magic window
        Style style;
        Chat chat;
        Learning learning;

        
        

        public MainWindow()
        {

            TopologyApp.InitializeNeuralNetwork();
            
            InitializeComponent();
            

            //Magic window
            style = (Style)FindResource("ButtonLeftPanel");
            chat = new Chat(ChatsSp, MainChatSp, MessageBt, MessageTb, style);
            learning = new Learning(FirstStage_Button, Start_Button, Cancellation_Button, LearningRate_TextBox);
        }

        #region Magic_Window   
        private void MagicBt_Click(object sender, RoutedEventArgs e)
        {
            if (AppWindowTabControl.SelectedIndex != 0)
            {
                MagicBt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#878787"));
                Button activeButton = (Button)WindowsBar_Grid.Children[AppWindowTabControl.SelectedIndex];
                activeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#191919"));
                AppWindowTabControl.SelectedIndex = 0;
            }
        }

        private void LearningBt_Click(object sender, RoutedEventArgs e)
        {
            if (AppWindowTabControl.SelectedIndex != 1)
            {
                LearningBt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#878787"));
                Button activeButton = (Button)WindowsBar_Grid.Children[AppWindowTabControl.SelectedIndex]; 
                activeButton.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#191919"));
                AppWindowTabControl.SelectedIndex = 1;
            }
        }

        private void ChatBt_Click(object sender, RoutedEventArgs e)
        {
            chat.ChatBt_Click(sender, e);
        }

        private void NewChatBt_Click(object sender, RoutedEventArgs e)
        {
            chat.NewChatBt_Click(sender, e);
        }

        private void MessageTb_GotFocus(object sender, RoutedEventArgs e)
        {
            chat.MessageTb_GotFocus(sender, e);
        }

        private void MessageTb_KeyDown(object sender, KeyEventArgs e)
        {
            chat.MessageTb_KeyDown(sender, e);
        }

        private void MessageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(chat != null)
            chat.MessageTb_TextChanged(sender, e);
        }
        
        private void MessageBt_Click(object sender, RoutedEventArgs e)
        {
            chat.MessageBt_Click(sender, e);
        }

        #endregion

        private void FirstStage_Button_Click(object sender, RoutedEventArgs e)
        {
            learning.FirstStage_Button_Click(sender, e);
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            learning.Start_Button_Click(sender, e);
        }

        private void Cancellation_Button_Click(object sender, RoutedEventArgs e)
        {
            learning.Cancellation_Button_Click(sender, e);
        }

        private void EpochCount_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            learning.EpochCount_TextBox_TextChanged(sender, e);
        }

        private void LearningRate_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(learning != null)
            learning.LearningRate_TextBox_TextChanged(sender, e) ;
        }

        private void NewData_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            learning.NewData_TextBox_TextChanged(sender , e);
        }
    }
}