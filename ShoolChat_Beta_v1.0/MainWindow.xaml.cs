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

        
        

        public MainWindow()
        {
            if (TopologyApp.PathApp != null)
            {
                TopologyApp.InitializeNeuralNetwork();
            }
            InitializeComponent();

            //Magic window
            style = (Style)FindResource("ButtonLeftPanel");
            chat = new Chat(ChatsSp, MainChatSp, MessageBt, MessageTb, style);
        }

        #region Magic_Window   
        private void MagicBt_Click(object sender, RoutedEventArgs e)
        {
            MagicBt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#878787"));
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
    }
}