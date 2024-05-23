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
    /// Логика взаимодействия для PlaceWaiter.xaml
    /// </summary>
    public partial class PlaceWaiter : Page
    {
        public PlaceWaiter()
        {
            InitializeComponent();
            ListOrdersGrid.ItemsSource = DemExCafeEntities.GetContext().Orders.ToList();
            DataContext = DemExCafeEntities.GetContext().Employees.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.CafeFrame.Navigate(new Pages.AddingOrder(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var OrderRemoving = ListOrdersGrid.SelectedItems.Cast<Orders>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {OrderRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DemExCafeEntities.GetContext().Orders.RemoveRange(OrderRemoving);
                    DemExCafeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ListOrdersGrid.ItemsSource = DemExCafeEntities.GetContext().Orders.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
