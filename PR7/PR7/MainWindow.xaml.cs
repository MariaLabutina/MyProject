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

namespace PR7
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

        
        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            tx1.Clear();
            tx2.Clear();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Fontcolor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tx1 == null)
            {
                return;
            }
            if (fontcolor.SelectedIndex == 0)
            {
                tx1.Foreground = Brushes.Black;
            }
            else if(fontcolor.SelectedIndex == 1)
            {
                tx1.Foreground = Brushes.Blue;
            }
            else if (fontcolor.SelectedIndex == 2)
            {
                tx1.Foreground = Brushes.Green;
            }
            else if (fontcolor.SelectedIndex == 3)
            {
                tx1.Foreground = Brushes.Red;
            }
        }


        private void Fontview_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (tx1 == null)
            {
                return;
            }
            if (fontview.SelectedIndex == 0)
            {
                tx1.FontWeight = FontWeights.Normal;
            }
            else if (fontview.SelectedIndex == 1)
            {
                tx1.FontWeight = FontWeights.Bold;
            }
        }
    }
    
}
