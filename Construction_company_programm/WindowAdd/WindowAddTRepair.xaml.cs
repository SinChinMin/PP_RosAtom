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

namespace Construction_company_programm.WindowAdd
{
    /// <summary>
    /// Логика взаимодействия для WindowAddTRepair.xaml
    /// </summary>
    public partial class WindowAddTRepair : Window
    {
        Entities entities = new Entities();
        private Type__Reactor types = new Type__Reactor();
        public string ImageSour { get; set; }
        public WindowAddTRepair(Type__Reactor type)
        {
            InitializeComponent();
            types = type;
            DataContext = types;
        }

        private void buttonAddTRepairAdmin_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (TextBoxCost.Text == "")
                errors.AppendLine("Введите стоимость");
            if (TextBoxName.Text == "")
                errors.AppendLine("Введите наименование");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (types.Tr_Id == 0)
            {
                entities.Type__Reactor.Add(types);
            }
            try
            {
                entities.SaveChanges();
                MessageBox.Show("Запись успешно сохранена", "Успех!");

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }

        private void buttonBackAddTRepairAdmin_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonClearAddTRepairAdmin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
