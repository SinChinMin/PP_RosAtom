using Construction_company_programm.WindowAdd;
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

namespace Construction_company_programm.FramePage
{
    /// <summary>
    /// Логика взаимодействия для PageRepairOrder.xaml
    /// </summary>
    public partial class PageRepairOrder : Page
    {
        Entities entities = new Entities();
        public PageRepairOrder()
        {
            InitializeComponent();
            dataGridRepairOrder.ItemsSource = entities.Application_Сonstruction.ToList();
            FilterOrder.Items.Add("Все");

            foreach (var i in entities.Type_Reactor)
            {
                FilterOrder.Items.Add(i);
            }
            FilterOrder.SelectedIndex = 0;
        }

        private void buttonEditDrinkDataGrid_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddRepairOrder((sender as Button).DataContext as Application_Сonstruction);//transmission of porameters
            window.ShowDialog();//opening a window
            dataGridRepairOrder.ItemsSource = entities.Application_Сonstruction.ToList();//filling in the DataGrid
        }

        private void buttonSaveDrinkAdmin_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddRepairOrder(null);
            window.ShowDialog();
            dataGridRepairOrder.ItemsSource = entities.Application_Сonstruction.ToList();
        }

        private void buttonRemoveDrinkAdmin_Click(object sender, RoutedEventArgs e)
        {
            var deleteteOrder = dataGridRepairOrder.SelectedItem as Application_Сonstruction;
            if (MessageBox.Show("Вы действительно хотите удалить запись", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    entities.Application_Сonstruction.Remove(deleteteOrder);
                    entities.SaveChanges();
                    dataGridRepairOrder.Items.Refresh();
                    MessageBox.Show("Запись Удалена!", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            Update();
        }
        private void Update()
        {
            var order = entities.Application_Сonstruction.ToList();
            order = order.Where(p => p.Type_Reactor.Contains(FilterOrder.SelectedItem)).ToList();
            if (FilterOrder.SelectedIndex == 0)
            {
                order = entities.Application_Сonstruction.ToList();
            }
            order = order.Where(p => p.Ac_Start_date.ToString().Contains(textBoxSearchOrderAmin.Text.ToLower())).ToList();
            dataGridRepairOrder.ItemsSource = order;
        }

        private void textBoxSearchDrinkAmin_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void FilterDrink_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}