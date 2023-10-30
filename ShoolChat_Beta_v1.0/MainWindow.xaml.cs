using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ShoolChat_Beta_v1._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            ChatsSp.Children.Add(ChatBt);
        }
    }
}