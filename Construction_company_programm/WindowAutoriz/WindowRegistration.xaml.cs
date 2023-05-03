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

namespace Construction_company_programm.WindowAutoriz
{
    /// <summary>
    /// Логика взаимодействия для WindowRegistration.xaml
    /// </summary>
    public partial class WindowRegistration : Window
    {
        Entities entities = new Entities();
        public WindowRegistration()
        {
            InitializeComponent();
        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            TextBoxLogin.Text = "";
            PasswordBoxPass.Password = "";
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            bool prov = false;

            foreach (var login in entities.Users)
            {
                if (TextBoxLogin.Text == login.U_Login)
                {
                    MessageBox.Show("Такой логин уже есть!", "Уведомление",
                    MessageBoxButton.OK);
                    prov = false;
                    break;
                }
                else
                {
                    prov = true;
                }
            }
            if (prov == true)
            {
                if (TextBoxLogin.Text == "" && PasswordBoxPass.Password == "")
                    MessageBox.Show("Заполните поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    Users user = new Users
                    {
                        U_Login = TextBoxLogin.Text,
                        U_Password = PasswordBoxPass.Password,
                    };
                    entities.Users.Add(user);
                    entities.SaveChanges();
                    MessageBox.Show("Вы успешно зарегестрировались!", "Уведомление",
                        MessageBoxButton.OK);
                    prov = false;
                    Close();
                }
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

