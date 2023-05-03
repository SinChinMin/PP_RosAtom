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

namespace Construction_company_programm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities entities = new Entities();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonRegestration_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowAutoriz.WindowRegistration();
            window.ShowDialog();
        }

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            string m_aut = "Аутентификация";
            string m_errorincor = "Ошибка! Проверьте правильность данных!";

            if (TextBoxLogin.Text != "" && TextBoxLogin.Text == null ||
                PasswordBoxPass.Password != "" && PasswordBoxPass.Password != null)
            {
                bool flag = false;

                foreach (var login in entities.Users)
                {
                    if (TextBoxLogin.Text == login.U_Login)
                    {
                        if (PasswordBoxPass.Password == login.U_Password)
                        {
                            flag = true;
                            if (TextBoxLogin.Text == "admin")
                            {
                                var window = new WindowCompanyAdmin();
                                window.ShowDialog();
                                Close();
                            }
                            else
                            {
                                var window = new WindowCompanyWorker();
                                window.ShowDialog();
                                Close();
                            }
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    MessageBox.Show(m_errorincor, m_aut, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(m_errorincor, m_aut, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxLogin.Text = "";
            PasswordBoxPass.Password = "";
        }
    }
}

