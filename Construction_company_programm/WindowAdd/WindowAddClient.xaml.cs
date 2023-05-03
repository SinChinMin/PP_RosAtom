using Microsoft.Win32;
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
    /// Логика взаимодействия для WindowAddClient.xaml
    /// </summary>
    public partial class WindowAddClient : Window
    {
        Entities entities = new Entities();
        private Client clients = new Client();
        public string ImageSour { get; set; }
        public WindowAddClient(Client client)
        {
            InitializeComponent();
            clients = client;
            DataContext = clients;
        }

        private void buttonAddClientAdmin_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (TextBoxLastName.Text == "")
                errors.AppendLine("Введите фамилию");
            if (TextBoxName.Text == "")
                errors.AppendLine("Введите имя");
            if (TextBoxPatronymic.Text == "")
                errors.AppendLine("Введите отчество");
            if (TextBoxNumber.Text == "")
                errors.AppendLine("Введите номер");
            if (ImageSour == "")
                errors.AppendLine("Выбирите изображение");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (clients.C_Id == 0)
            {
                entities.Client.Add(clients);
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

        private void buttonBackAddClientAdmin_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonClearAddClientAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonOpenImageAddOrderAdmin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png|Все файлы (*.*)|*.*";

            file.ShowDialog();

            try
            {
                ImageSour = file.FileName;
                ImageClient.Source = new BitmapImage(new Uri(ImageSour));

            }
            catch
            {
                MessageBox.Show("Выран неизвестный формат", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
