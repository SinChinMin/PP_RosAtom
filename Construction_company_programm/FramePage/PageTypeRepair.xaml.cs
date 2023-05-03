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
    /// Логика взаимодействия для PageTypeRepair.xaml
    /// </summary>
    public partial class PageTypeRepair : Page
    {
        Entities entities = new Entities();
        public PageTypeRepair()
        {
            InitializeComponent();
            dataGridTRepair.ItemsSource = entities.Type_Reactor.ToList();
            FilterTRepair.Items.Add("Все");
        }

        private void buttonEditDrinkDataGrid_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddTRepair((sender as Button).DataContext as Type_Reactor);
            window.ShowDialog();
            dataGridTRepair.ItemsSource = entities.Type_Reactor.ToList();
        }

        private void buttonSaveDrinkAdmin_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddTRepair(null);
            window.ShowDialog();
            dataGridTRepair.ItemsSource = entities.Type_Reactor.ToList();
        }

        private void buttonRemoveDrinkAdmin_Click(object sender, RoutedEventArgs e)
        {
            var deleteteTRepair = dataGridTRepair.SelectedItem as Type_Reactor;
            if (MessageBox.Show("Вы действительно хотите удалить запись", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    entities.Type_Reactor.Remove(deleteteTRepair);
                    entities.SaveChanges();
                    dataGridTRepair.Items.Refresh();
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
            var trepair = entities.Type_Reactor.ToList();

            trepair = trepair.Where(p => p.Tr_Name.ToString().Contains(textBoxSearchTRepairAmin.Text.ToLower())).ToList();
            dataGridTRepair.ItemsSource = trepair;
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
