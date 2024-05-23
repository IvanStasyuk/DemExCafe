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
    /// Логика взаимодействия для ListShiftsPage.xaml
    /// </summary>
    public partial class ListShiftsPage : Page
    {
        public ListShiftsPage()
        {
            InitializeComponent();
            ListShiftsGrid.ItemsSource = DemExCafeEntities.GetContext().Shifts.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.CafeFrame.Navigate(new Pages.AddingShift());
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var ShiftRemoving = ListShiftsGrid.SelectedItems.Cast<Shifts>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {ShiftRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DemExCafeEntities.GetContext().Shifts.RemoveRange(ShiftRemoving);
                    DemExCafeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    ListShiftsGrid.ItemsSource = DemExCafeEntities.GetContext().Shifts.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DemExCafeEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                ListShiftsGrid.ItemsSource = DemExCafeEntities.GetContext().Shifts.ToList();
            }
        }
    }
}
