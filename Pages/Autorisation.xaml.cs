﻿using System;
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

namespace AppDemExCafe.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Page
    {
        public Autorisation()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void RepeatCaptcha_Click(object sender, RoutedEventArgs e)
        {
            MainWindow_Loaded(sender, e);
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            var LoginUser = DemExCafeEntities.GetContext().Employees.FirstOrDefault(y => y.Login == TBlogin.Text);
            var PasswordUser = DemExCafeEntities.GetContext().Employees.FirstOrDefault(z => z.Password == TBPassword.Text);

            try
            {
                StringBuilder errors = new StringBuilder();

                if (string.IsNullOrEmpty(TBlogin.Text))
                    errors.AppendLine("Укажите логин");
                if (string.IsNullOrEmpty(TBPassword.Text))
                    errors.AppendLine("Укажите пароль");
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                var UserVhod = DemExCafeEntities.GetContext().Employees.FirstOrDefault(x => x.Login == TBlogin.Text && x.Password == TBPassword.Text);
                if (LoginUser == null)
                {
                    MessageBox.Show("Логин введен с ошибками", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (PasswordUser == null)
                {
                    MessageBox.Show("Пароль введен с ошибками", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (CaptchaInput.Text == "")
                {
                    MessageBox.Show("Введите капчу", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (CaptchaInput.Text != RandomCaptcha.Text)
                {
                    MessageBox.Show("Капча введена неверно", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (CaptchaInput.Text == RandomCaptcha.Text)
                {
                    MessageBox.Show("Капча верна", "Авторизация успешна", MessageBoxButton.OK, MessageBoxImage.Information);
                    switch (UserVhod.idRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуй, Администратор " + UserVhod.NameUser + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.CafeFrame.Navigate(new Pages.PlaceAdministrator());
                            Manager.IsRole = 1;
                            break;
                        case 2:
                            MessageBox.Show("Здравствуй, Официант " + UserVhod.NameUser + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.CafeFrame.Navigate(new Pages.PlaceWaiter());
                            Manager.IsRole = 2;
                            break;
                        case 3:
                            MessageBox.Show("Здравствуй, Повар " + UserVhod.NameUser + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.CafeFrame.Navigate(new Pages.PlaceCook());
                            Manager.IsRole = 3;
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены " + UserVhod.NameUser + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая ошибка приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            RandomCaptcha.Text = "";
            for (int i = 0; i < 5; i++)
            {
                int charType = random.Next(0, 2);
                char randomChar;
                if (charType == 0)
                {
                    randomChar = (char)random.Next(65, 91);
                }
                else
                {
                    randomChar = (char)random.Next(48, 58);
                }
                RandomCaptcha.Text += randomChar;
            }
            TBlogin.Text = "";
            TBPassword.Text = "";
            CaptchaInput.Text = "";
        }
    }
}
