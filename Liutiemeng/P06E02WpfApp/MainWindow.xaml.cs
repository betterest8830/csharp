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

namespace P06E02WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Window> newList;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 15000; i++)
            {
                Window win= new Window();
                newList.Add(win);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            newList.Clear();
        }
    }
}
