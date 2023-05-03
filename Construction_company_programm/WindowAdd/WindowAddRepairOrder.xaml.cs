using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Construction_company_programm.WindowAdd
{
    /// <summary>
    /// Логика взаимодействия для WindowAddRepairOrder.xaml
    /// </summary>
    public partial class WindowAddRepairOrder : Window
    {
        Entities entities = new Entities();
        private Application_Сonstruction aConstructions = new Application_Сonstruction();
        public WindowAddRepairOrder(Application_Сonstruction aConstruction)
        {
            InitializeComponent();
            comboBoxClient.ItemsSource = entities.Client.ToList();
            comboBoxWorker.ItemsSource = entities.Сontractors.ToList();
            comboBoxTRepair.ItemsSource = entities.Type__Reactor.ToList();

            if (aConstruction != null)
            {
                foreach (var i in aConstruction.Type__Reactor)
                {
                    ListRemont.Items.Add(i);
                }
                foreach (var i in aConstruction.Client)
                {
                    ListClient.Items.Add(i);
                }
                foreach (var i in aConstruction.Сontractors)
                {
                    ListWorker.Items.Add(i);
                }
                aConstructions = aConstruction;
            }
            DataContext = aConstructions;
        }

        private void buttonClearAddOrderAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonBackAddOrderAdmin_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonAddOrderAdmin_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (ListClient.Items.Count == 0)
                errors.AppendLine("Добавте клиента");
            if (ListWorker.Items.Count == 0)
                errors.AppendLine("Добавте работника");
            if (ListRemont.Items.Count == 0)
                errors.AppendLine("Добавте вид ремонта");
            if (textBoxAddOrderDate.Text == "")
                errors.AppendLine("Введите дату");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (aConstructions.Ac_Id == 0)
            {
                entities.Application_Сonstruction.Add(aConstructions);
            }
            try
            {
                Application_Сonstruction ordersitems = new Application_Сonstruction();
                foreach (Client i in ListClient.Items)
                {
                    ordersitems.Client.Add(i);
                }
                aConstructions.Client = ordersitems.Client;

                foreach (Сontractors i in ListWorker.Items)
                {
                    ordersitems.Сontractors.Add(i);
                }
                aConstructions.Сontractors = ordersitems.Сontractors;

                foreach (Type__Reactor i in ListRemont.Items)
                {
                    ordersitems.Type__Reactor.Add(i);
                }
                aConstructions.Type__Reactor = ordersitems.Type__Reactor;

                entities.SaveChanges();
                MessageBox.Show("Запись успешно сохранена", "Успех!");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }

        private void ButtonListAddClient_Click(object sender, RoutedEventArgs e)
        {
            ListClient.Items.Add(comboBoxClient.SelectedItem);
            ListClient.Items.Refresh();
        }

        private void ButtonListAddWorker_Click(object sender, RoutedEventArgs e)
        {
            ListWorker.Items.Add(comboBoxWorker.SelectedItem);
            ListWorker.Items.Refresh();
        }

        private void ButtonListAddRemont_Click(object sender, RoutedEventArgs e)
        {
            ListRemont.Items.Add(comboBoxTRepair.SelectedItem);
            ListRemont.Items.Refresh();
        }

        private void ButtonListRemoveClient_Click(object sender, RoutedEventArgs e)
        {
            aConstructions.Client.Remove(ListClient.SelectedItem as Client);
            entities.SaveChanges();
            ListClient.Items.Remove(ListClient.SelectedItem);
            ListClient.Items.Refresh();
        }

        private void ButtonListRemoveWorker_Click(object sender, RoutedEventArgs e)
        {
            aConstructions.Сontractors.Remove(ListWorker.SelectedItem as Сontractors);
            entities.SaveChanges();
            ListWorker.Items.Remove(ListWorker.SelectedItem);
            ListWorker.Items.Refresh();
        }

        private void ButtonListRemoveRemont_Click(object sender, RoutedEventArgs e)
        {
            aConstructions.Type__Reactor.Remove(ListRemont.SelectedItem as Type__Reactor);
            entities.SaveChanges();
            ListRemont.Items.Remove(ListRemont.SelectedItem);
            ListRemont.Items.Refresh();
        }
    }
}

