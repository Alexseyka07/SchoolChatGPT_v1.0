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
        private Dictionary<string, int> wordsData;

       
        private List<List<string>> chatsList;
        private int actualIndexChat = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitNeuralNetwork();
            SendMessageChanged += SendMessage;

            
            Grid startMessage = getGPTMessage("Привет, друг! Рад тебя видеть в этом приложении. Чтобы я начал творить магию, нажми на кнопку <<НОВЫЙ ЧАТ>>\n<---------------");
            MainChatSp.Children.Add(startMessage);
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
            actualIndexChat = int.Parse(button.Name.Split('_')[1]);
            MainChatSp.Children.Clear();
            for (int i = 0; i < chatsList[actualIndexChat].Count; i++)
            {
                if(i%2 == 0)
                {
                    Grid userWindow = GetUserMessage(chatsList[actualIndexChat][i]);
                    MainChatSp.Children.Add(userWindow);
                }
                else
                {
                    Grid gptAnswer = getGPTMessage(chatsList[actualIndexChat][i]);
                    MainChatSp.Children.Add(gptAnswer);
                }
            }
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
            ChatsSp.Children.Add(chatBt);
            List<string> chat = new List<string>();
            chatsList.Add(chat);
            chatBt.Name = $"chatBt_{chatsList.Count - 1}";
            actualIndexChat = int.Parse(chatBt.Name.Split('_')[1]);
            MainChatSp.Children.Clear();
            MessageTb_TextChanged(MessageTb, null);

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
            if (e.Key == Key.Enter && textBox.Text != "" && ChatsSp.Children.Count != 0)
            {
               
                // Выполните здесь ваше событие
                SendMessageChanged(sender,null);
                
                e.Handled = true; // Чтобы предотвратить добавление новой строки
                
            }
        }

        private void MessageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "" && textBox.Text != "Введите сообщение..." && ChatsSp.Children.Count != 0)
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
            Grid userWindow = InitUserMessage(message);
            MainChatSp.Children.Add(userWindow);
            Grid gptWindow = InitGPTMessage(message);
            MainChatSp.Children.Add(gptWindow);
           
        }
        private Grid InitUserMessage(string message)
        {
            chatsList[actualIndexChat].Add(message);
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
        private Grid GetUserMessage(string message)
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
            string gptAnswer = func.EndInvoke(result);
            chatsList[actualIndexChat].Add(gptAnswer);
            TextBlock label = new TextBlock
            {
               Text  = gptAnswer, // Замените это на ваш текст
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
        private Grid getGPTMessage(string message)
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