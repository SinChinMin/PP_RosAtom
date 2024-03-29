﻿using Construction_company_programm.WindowAdd;
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
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        Entities entities = new Entities();
        public PageClient()
        {
            InitializeComponent();
            dataGridClient.ItemsSource = entities.Client.ToList();
            FilterClient.Items.Add("Все");
        }

        private void buttonEditDrinkDataGrid_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddClient((sender as Button).DataContext as Client);
            window.ShowDialog();
            dataGridClient.ItemsSource = entities.Client.ToList();
        }

        private void buttonSaveDrinkAdmin_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAddClient(null);
            window.ShowDialog();
            dataGridClient.ItemsSource = entities.Client.ToList();
        }

        private void buttonRemoveDrinkAdmin_Click(object sender, RoutedEventArgs e)
        {
            var deleteteClient = dataGridClient.SelectedItem as Client;
            if (MessageBox.Show("Вы действительно хотите удалить запись", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    entities.Client.Remove(deleteteClient);
                    entities.SaveChanges();
                    dataGridClient.Items.Refresh();
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
            var drink = entities.Client.ToList();

            drink = drink.Where(p => p.C_Name.ToString().Contains(textBoxSearchClientAmin.Text.ToLower())).ToList();
            dataGridClient.ItemsSource = drink;
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
