using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace ShoolChat_Beta_v1._0.classes
{
    public class Chat
    {
        private StackPanel chatsSp;
        private StackPanel mainChatSp;
        private Button MessageBt;
        private TextBox MessageTb;

        private event Action<object, EventArgs> SendMessageChanged;

        private Style style;
        private int actualIndexChat = 0;
        private List<List<string>> chatsList = new List<List<string>>();

        public Chat(StackPanel chatsSp, StackPanel mainChatSp, Button MessageBt, TextBox MessageTb, Style style)
        {
            Thread.Sleep(1000);
            this.chatsSp = chatsSp;
            this.mainChatSp = mainChatSp;
            this.MessageBt = MessageBt; 
            this.MessageTb = MessageTb;
            this.style = style;


            SendMessageChanged += SendMessage;
            Grid startMessage = getGPTMessage("Привет, друг! Рад тебя видеть в этом приложении. Чтобы я начал творить магию, нажми на кнопку <<НОВЫЙ ЧАТ>>\n<---------------");
            mainChatSp.Children.Add(startMessage);
        }

        #region Methods
        private Button InitChatButton()
        {
            Button ChatBt = new Button();

            ChatBt.Foreground = Brushes.White;
            ChatBt.Style = style;
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
            label.Content = "Чат" + chatsSp.Children.Count;
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
        // Создание сообщений
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

            
           
             string gptAnswer = TopologyApp.NetworkGPT1.GPTWork(message);
            
            chatsList[actualIndexChat].Add(gptAnswer);
            TextBlock label = new TextBlock
            {
                Text = gptAnswer, // Замените это на ваш текст
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
        #endregion

        #region Events
        public void MessageTb_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Введите сообщение...")
            {
                textBox.Text = string.Empty;
            }
        }

        public void ChatBt_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button buttonChildren in chatsSp.Children)
            {
                buttonChildren.IsEnabled = true;
                buttonChildren.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C2C2C"));
            }
            Button button = sender as Button;
            button.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#53614E"));
            button.IsEnabled = false;
            actualIndexChat = int.Parse(button.Name.Split('_')[1]);
            mainChatSp.Children.Clear();
            for (int i = 0; i < chatsList[actualIndexChat].Count; i++)
            {
                if (i % 2 == 0)
                {
                    Grid userWindow = GetUserMessage(chatsList[actualIndexChat][i]);
                    mainChatSp.Children.Add(userWindow);
                }
                else
                {
                    Grid gptAnswer = getGPTMessage(chatsList[actualIndexChat][i]);
                    mainChatSp.Children.Add(gptAnswer);
                }
            }
        }

        public void NewChatBt_Click(object sender, RoutedEventArgs e)
        {
            Button chatBt = InitChatButton();

            foreach (Button buttonChildren in chatsSp.Children)
            {
                buttonChildren.IsEnabled = true;
                buttonChildren.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2C2C2C"));
            }
            chatBt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#53614E"));
            chatBt.IsEnabled = false;
            chatsSp.Children.Add(chatBt);
            List<string> chat = new List<string>();
            chatsList.Add(chat);
            chatBt.Name = $"chatBt_{chatsList.Count - 1}";
            actualIndexChat = int.Parse(chatBt.Name.Split('_')[1]);
            mainChatSp.Children.Clear();
            MessageTb_TextChanged(MessageTb, null);

        }

        public void MessageTb_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (e.Key == Key.Enter && textBox.Text != "" && chatsSp.Children.Count != 0)
            {

                // Выполните здесь ваше событие
                SendMessageChanged(sender, null);

                e.Handled = true; // Чтобы предотвратить добавление новой строки

            }
        }

        public void MessageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "" && textBox.Text != "Введите сообщение..." && chatsSp.Children.Count != 0)
            {
                MessageBt.IsEnabled = true;
            }
            else { if (MessageBt != null) MessageBt.IsEnabled = false; }
        }

        public void SendMessage(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string message = textBox.Text;
            textBox.Text = string.Empty;
            Grid userWindow = InitUserMessage(message);
            mainChatSp.Children.Add(userWindow);
            Grid gptWindow = InitGPTMessage(message);
            mainChatSp.Children.Add(gptWindow);

        }

        public void MessageBt_Click(object sender, RoutedEventArgs e)
        {
            SendMessageChanged(MessageTb, null);
        }
        #endregion
    }
}
