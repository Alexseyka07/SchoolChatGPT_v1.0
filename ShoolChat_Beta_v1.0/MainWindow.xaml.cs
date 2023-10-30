using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            ChatBt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#53614E"));
            
            
            
          
        }
    }
}
