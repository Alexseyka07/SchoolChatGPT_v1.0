using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SchoolChatGPT_v1._0;
using SchoolChatGPT_v1._0.NeuralNetworkClasses;


namespace ShoolChat_Beta_v1._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private event Action<object,EventArgs> SendMessageChanged;
        private NeuralNetwork neuralNetwork;
        Dictionary<string, int> wordsData;
        private List<StackPanel> chats = new List<StackPanel>();
        private StackPanel actualChat;

        public MainWindow()
        {
            InitializeComponent();
            InitNeuralNetwork();
            SendMessageChanged += SendMessage;
            
        }

        private void MagicBt_Click(object sender, RoutedEventArgs e)
        {
            MagicBt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#878787"));
        }

        private void ChatBt_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button buttonChildren in ChatsSp.Children)
            {
                buttonChildren.IsEnabled = true;
                buttonChildren.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C2C2C"));
            }
            Button button = sender as Button;
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#53614E"));
            button.IsEnabled = false;
        }

        private void NewChatBt_Click(object sender, RoutedEventArgs e)
        {
           Button chatBt = InitChatButton();
            foreach (Button buttonChildren in ChatsSp.Children)
            {
                buttonChildren.IsEnabled = true;
                buttonChildren.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C2C2C"));
            }            
            chatBt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#53614E"));
            chatBt.IsEnabled = false;
            StackPanel chat = new StackPanel();
            actualChat = chat;
            ChatsSp.Children.Add(chatBt);
            actualChat.Background = Brushes.Red;
          



        }

        private Button InitChatButton()
        {
            Button ChatBt = new Button();

            ChatBt.Foreground = Brushes.White;
            ChatBt.Style = (Style)FindResource("ButtonLeftPanel");
            ChatBt.Height = 40;
            ChatBt.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x2C, 0x2C, 0x2C));
            ChatBt.Margin = new Thickness(0, 0, 0, 10);
            ChatBt.FontSize = 15;
            ChatBt.Padding = new Thickness(10, 0, 0, 0);
            ChatBt.Click += ChatBt_Click;

            Grid grid = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(70, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("/🦆 icon _message_ (1).png", UriKind.Relative));
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.Margin = new Thickness(10);
            Grid.SetColumn(image, 0);

            Label label = new Label();
            label.Content = "Чат" + ChatsSp.Children.Count;
            label.Foreground = Brushes.White;
            label.Margin = new Thickness(15, 0, 0, 0);
            label.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(label, 1);

            grid.Children.Add(image);
            grid.Children.Add(label);

            ChatBt.Content = grid;

            ChatBt.HorizontalContentAlignment = HorizontalAlignment.Left;
            return ChatBt;
        }

        

        private void MessageTb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите сообщение...")
            {
                textBox.Text = string.Empty;
            }
        }

        private void MessageTb_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.Key == Key.Enter && textBox.Text != "")
            {
                // Выполните здесь ваше событие
                SendMessageChanged(sender,null);
                e.Handled = true; // Чтобы предотвратить добавление новой строки
                
            }
        }

        private void MessageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "" && textBox.Text != "Введите сообщение...")
            {
                MessageBt.IsEnabled = true;
            }
            else { if (MessageBt != null) MessageBt.IsEnabled = false; }
        }
        
        

        private void MessageBt_Click(object sender, RoutedEventArgs e)
        {
            SendMessageChanged(MessageTb,null);
        }
        private void SendMessage(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            
            string message = textBox.Text;
            textBox.Text = string.Empty;
            Grid grid = InitUserMessage(message);
            actualChat.Children.Add(grid);
            Grid grid1 = InitGPTMessage(message);
            actualChat.Children.Add(grid1);
            Grid gr3 = actualChat.Children[0] as Grid;
            MainChatSp.Children.Add(grid1);
        }
        private Grid InitUserMessage(string message)
        {
            Grid grid = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(70, GridUnitType.Star);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(30, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);
            Border border = new Border
            {
                CornerRadius = new CornerRadius(15),
                Height = 70,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#616D51")),
                Margin = new Thickness(20, 20, 20, 10)
            };

            TextBlock label = new TextBlock
            {
                Text = message, // Замените это на ваш текст
                Foreground = Brushes.White, // Цвет текста
                Padding = new Thickness(10),
                FontSize = 15,
                TextWrapping = TextWrapping.Wrap
            };

            border.Child = label;
            grid.Children.Add(border);
               Grid.SetColumn(border, 0); // Укажите столбец, в котором разместить Border
           

            return grid;
        }
        private Grid InitGPTMessage(string message)
        {
            
            Grid grid = new Grid();
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(30, GridUnitType.Star);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(70, GridUnitType.Star);
            grid.ColumnDefinitions.Add(col1);
            grid.ColumnDefinitions.Add(col2);
            Border border = new Border
            {
                CornerRadius = new CornerRadius(15),
                Height = 70,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5E4747")),
                Margin = new Thickness(20, 20, 20, 10)
            };

            Func<string, string> func = GPTWork;
            IAsyncResult result = func.BeginInvoke(message,null,null);
            string mes = func.EndInvoke(result);
            TextBlock label = new TextBlock
            {
               Text  = mes, // Замените это на ваш текст
               Foreground = Brushes.White, // Цвет текста
                Padding = new Thickness(10),
                FontSize = 15,
                TextWrapping = TextWrapping.Wrap
            };

            border.Child = label;
            grid.Children.Add(border);
            Grid.SetColumn(border, 1); // Укажите столбец, в котором разместить Border


            return grid;
        }
        private void InitNeuralNetwork()
        {
            DataNeuralNetwork dataNeuralNetwork = new DataNeuralNetwork();
            Data data;
            data = new Data();
            data = data.GetData();
            wordsData = data.wordsData;
            dataNeuralNetwork = dataNeuralNetwork.GetData();
            neuralNetwork = dataNeuralNetwork.neuralNetwork;
        }
        private string GPTWork(string message)
        {
            
            string answer = string.Empty;            
            Neuron outputNeuron1 = neuralNetwork.FeedForward(message, wordsData);
            var res = Math.Round(outputNeuron1.Output, 3);
            answer += $"       \n {(res >= 0.5 ? "задача" : "вопрос о правиле")}";
            return answer;
        }
    }
}