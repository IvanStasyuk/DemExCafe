using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    /// Логика взаимодействия для AddingUser.xaml
    /// </summary>
    public partial class AddingUser : Page
    {
        private Employees _currentUser = new Employees();
        private List<int> roles = new List<int> { 1, 2, 3 };
        private List<string> statuses = new List<string> { "Работает", "Уволен(а)" };
        public AddingUser(Employees selectedUser)
        {
            InitializeComponent();
            RolesList.ItemsSource = roles;
            StatusList.ItemsSource = statuses;
            if (selectedUser != null)
                _currentUser = selectedUser;
            DataContext = _currentUser;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(AddName.Text))
                errors.AppendLine("Укажите имя пользователя");
            if (string.IsNullOrEmpty(AddFamilia.Text))
                errors.AppendLine("Укажите Фамилию пользователя");
            if (string.IsNullOrEmpty(AddPatronymic.Text))
                errors.AppendLine("Укажите отчество пользователя");
            if (string.IsNullOrEmpty(AddLogin.Text))
                errors.AppendLine("Укажите логин пользователя");
            if (string.IsNullOrEmpty(AddPassword.Text))
                errors.AppendLine("Укажите пароль пользователя");
            if (string.IsNullOrEmpty(RolesList.Text))
                errors.AppendLine("Укажите должность пользователя");
            if (string.IsNullOrEmpty(StatusList.Text))
                errors.AppendLine("Укажите статус пользователя");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var existingUser = DemExCafeEntities.GetContext().Employees.FirstOrDefault(y => y.Login == AddLogin.Text);
            if (existingUser != null)
            {
                existingUser.NameUser = AddName.Text;
                existingUser.FamiliaUser = AddFamilia.Text;
                existingUser.PatronymicUser = AddPatronymic.Text;
                existingUser.Password = AddPassword.Text;
                existingUser.idRole = int.Parse(RolesList.Text);
                existingUser.Status = StatusList.Text;

                DemExCafeEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные пользователя обновлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.CafeFrame.Navigate(new Pages.ListEmployeesPage());
            }
            else
            {
                try
                {
                    Employees NewUser = new Employees()
                    {
                        NameUser = AddName.Text,
                        FamiliaUser = AddFamilia.Text,
                        PatronymicUser = AddPatronymic.Text,
                        Login = AddLogin.Text,
                        Password = AddPassword.Text,
                        idRole = int.Parse(RolesList.Text),
                        Status = StatusList.Text,
                    };
                    DemExCafeEntities.GetContext().Employees.Add(NewUser);
                    DemExCafeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    AddName.Text = "";
                    AddFamilia.Text = "";
                    AddPatronymic.Text = "";
                    AddLogin.Text = "";
                    AddPassword.Text = "";
                    RolesList.Text = "";
                    StatusList.Text = "";
                    Manager.CafeFrame.Navigate(new Pages.ListEmployeesPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
    }
}
