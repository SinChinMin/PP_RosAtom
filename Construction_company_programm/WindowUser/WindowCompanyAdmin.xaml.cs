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

namespace Construction_company_programm
{
    /// <summary>
    /// Логика взаимодействия для WindowCompanyAdmin.xaml
    /// </summary>
    public partial class WindowCompanyAdmin : Window
    {
        private bool provMenu = false;
        public WindowCompanyAdmin()
        {
            InitializeComponent();
        }
        private void buttonZakaz_Click(object sender, RoutedEventArgs e)
        {
            frameAdmin.Navigate(new FramePage.PageRepairOrder());
        }

        private void buttonClient_Click(object sender, RoutedEventArgs e)
        {
            frameAdmin.Navigate(new FramePage.PageClient());
        }

        private void buttonWorkerAdmin_Click(object sender, RoutedEventArgs e)
        {
            frameAdmin.Navigate(new FramePage.PageWorker());
        }

        private void buttonTRepairAdmin_Click(object sender, RoutedEventArgs e)
        {
            frameAdmin.Navigate(new FramePage.PageTypeRepair());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(provMenu == false)
            {
                ListMenu.Visibility = Visibility.Visible;
                provMenu = true;
                return;
            }
            if (provMenu == true)
            {
                ListMenu.Visibility = Visibility.Collapsed;       
                provMenu = false;
                return;
            }
        }
    }
}