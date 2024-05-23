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
    /// Логика взаимодействия для PlaceAdministrator.xaml
    /// </summary>
    public partial class PlaceAdministrator : Page
    {
        public PlaceAdministrator()
        {
            InitializeComponent();
            DataContext = DemExCafeEntities.GetContext().Employees.ToList();
        }

        private void ToListEmployees_Click(object sender, RoutedEventArgs e)
        {
            Manager.CafeFrame.Navigate(new Pages.ListEmployeesPage());
        }

        private void ToListOrders_Click(object sender, RoutedEventArgs e)
        {
            Manager.CafeFrame.Navigate(new Pages.ListOrdersPage());
        }

        private void ToListShifts_Click(object sender, RoutedEventArgs e)
        {
            Manager.CafeFrame.Navigate(new Pages.ListShiftsPage());
        }
    }
}
