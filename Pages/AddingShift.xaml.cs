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

namespace AppDemExCafe.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddingShift.xaml
    /// </summary>
    public partial class AddingShift : Page
    {
        public AddingShift()
        {
            InitializeComponent();
        }

        private void AddShift_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(AddID.Text))
                errors.AppendLine("Укажите ID пользователя");
            if (string.IsNullOrEmpty(AddDateStart.Text))
                errors.AppendLine("Укажите начальную дату");
            if (string.IsNullOrEmpty(AddDateEnd.Text))
                errors.AppendLine("Укажите конечную дату");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            try
            {
                Shifts NewShift = new Shifts()
                {
                    idUser = int.Parse(AddID.Text),
                    DateStart = DateTime.Parse(AddDateStart.Text),
                    DateEnd = DateTime.Parse(AddDateEnd.Text)
                };
                DemExCafeEntities.GetContext().Shifts.Add(NewShift);
                DemExCafeEntities.GetContext().SaveChanges();
                MessageBox.Show("Смена добавлена!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AddID.Text = "";
                AddDateStart.Text = "";
                AddDateEnd.Text = "";
                Manager.CafeFrame.Navigate(new Pages.ListShiftsPage());
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
