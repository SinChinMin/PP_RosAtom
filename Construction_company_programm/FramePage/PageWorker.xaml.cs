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
    /// Логика взаимодействия для PageWorker.xaml
    /// </summary>
    public partial class PageWorker : Page
    {
        Entities entities = new Entities();
        public PageWorker()
        {
            InitializeComponent();
            dataGridWorker.ItemsSource = entities.Сontractors.ToList();
        }

        private void buttonEditDrinkDataGrid_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddWorker((sender as Button).DataContext as Сontractors);
            window.ShowDialog();
            dataGridWorker.ItemsSource = entities.Сontractors.ToList();
        }

        private void buttonSaveDrinkAdmin_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddWorker(null);
            window.ShowDialog();
            dataGridWorker.ItemsSource = entities.Сontractors.ToList();
        }

        private void buttonRemoveDrinkAdmin_Click(object sender, RoutedEventArgs e)
        {
            var deleteteWorker = dataGridWorker.SelectedItem as Сontractors;
            if (MessageBox.Show("Вы действительно хотите удалить запись", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    entities.Сontractors.Remove(deleteteWorker);
                    entities.SaveChanges();
                    dataGridWorker.Items.Refresh();
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
            var worker = entities.Сontractors.ToList();
            worker = worker.Where(p => p.Co_Name.ToString().Contains(textBoxSearchWorkerAmin.Text.ToLower())).ToList();
            dataGridWorker.ItemsSource = worker;
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
