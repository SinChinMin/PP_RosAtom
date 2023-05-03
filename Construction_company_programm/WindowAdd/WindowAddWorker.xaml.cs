using Construction_company_programm.FramePage;
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
    /// Логика взаимодействия для WindowAddWorker.xaml
    /// </summary>
    public partial class WindowAddWorker : Window
    {
        Entities entities = new Entities();
        private Сontractors contractors = new Сontractors();
        public string ImageSour { get; set; }
        public WindowAddWorker(Сontractors Contractor)
        {
            InitializeComponent();
            contractors = Contractor;
            DataContext = contractors;
        }

        private void buttonAddWorkerAdmin_Click(object sender, RoutedEventArgs e)
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
            if (TextBoxCitizenship.Text == "")
                errors.AppendLine("Введите гражданство");
            if (ImageSour == "")
                errors.AppendLine("Выбирите изображение");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (contractors.Co_Id== 0)
            {
                entities.Сontractors.Add(contractors);
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

        private void buttonBackAddWorkerAdmin_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonClearAddWorkerAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonOpenImageAddWorkerAdmin_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png|Все файлы (*.*)|*.*";

            file.ShowDialog();

            try
            {
                ImageSour = file.FileName;
                ImageWorker.Source = new BitmapImage(new Uri(ImageSour));

            }
            catch
            {
                MessageBox.Show("Выран неизвестный формат", "Ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
