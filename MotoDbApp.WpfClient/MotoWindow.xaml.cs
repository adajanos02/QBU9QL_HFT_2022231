using Castle.Core.Resource;
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
using System.Windows.Shapes;

namespace MotoDbApp.WpfClient
{
    /// <summary>
    /// Interaction logic for MotoWindow.xaml
    /// </summary>
    public partial class MotoWindow : Window
    {
        public MotoWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            noncrudList.ItemsSource = ((MotoWindowViewMOdel)DataContext).Query1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            noncrudList.ItemsSource = ((MotoWindowViewMOdel)DataContext).Query2;
        }

        
    }
}
