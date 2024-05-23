using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    /// Логика взаимодействия для ListEmployeesPage.xaml
    /// </summary>
    public partial class ListEmployeesPage : Page
    {
        public ListEmployeesPage()
        {
            InitializeComponent();
            ListEmployeesGrid.ItemsSource = DemExCafeEntities.GetContext().Employees.ToList();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var EmployeerRemoving = ListEmployeesGrid.SelectedItems.Cast<Employees>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {EmployeerRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DemExCafeEntities.GetContext().Employees.RemoveRange(EmployeerRemoving);
                    DemExCafeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ListEmployeesGrid.ItemsSource = DemExCafeEntities.GetContext().Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.CafeFrame.Navigate(new Pages.AddingUser((sender as Button).DataContext as Employees));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.CafeFrame.Navigate(new Pages.AddingUser(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DemExCafeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListEmployeesGrid.ItemsSource = DemExCafeEntities.GetContext().Employees.ToList();
            }
        }
    }
}
