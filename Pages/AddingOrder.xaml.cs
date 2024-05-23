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
    /// Логика взаимодействия для AddingOrder.xaml
    /// </summary>
    public partial class AddingOrder : Page
    {
        private Orders _currentOrder = new Orders();
        private List<string> statuses = new List<string> { "Принят", "Готовится", "Оплачен" };
        public AddingOrder(Orders selectedOrder)
        {
            InitializeComponent();
            AddStatus.ItemsSource = statuses;
            if (selectedOrder != null)
                _currentOrder = selectedOrder;
            DataContext = _currentOrder;
        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(AddID.Text))
                errors.AppendLine("Укажите ID пользователя");
            if (string.IsNullOrEmpty(AddStatus.Text))
                errors.AppendLine("Укажите статус заказа");
            if (string.IsNullOrEmpty(AddName.Text))
                errors.AppendLine("Укажите название заказа");
            if (string.IsNullOrEmpty(AddNumberTable.Text))
                errors.AppendLine("Укажите номер столика");
            if (string.IsNullOrEmpty(AddCountClients.Text))
                errors.AppendLine("Укажите количество клиентов");
            if (string.IsNullOrEmpty(AddOrderDish.Text))
                errors.AppendLine("Укажите заказанную еду");
            if (string.IsNullOrEmpty(AddOrderDrink.Text))
                errors.AppendLine("Укажите заказанную выпивку");
            if (string.IsNullOrEmpty(AddDateStart.Text))
                errors.AppendLine("Укажите дату начала");
            if (string.IsNullOrEmpty(AddDateEnd.Text))
                errors.AppendLine("Укажите дату окончания");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            var existingOrder = DemExCafeEntities.GetContext().Orders.FirstOrDefault(y => y.NameOrder == AddName.Text);
            if (existingOrder != null)
            {
                existingOrder.idUser = int.Parse(AddID.Text);
                existingOrder.NameOrder = AddName.Text;
                existingOrder.NumberTable = int.Parse(AddNumberTable.Text);
                existingOrder.CountClients = int.Parse(AddCountClients.Text);
                existingOrder.OrderDish = AddOrderDish.Text;
                existingOrder.OrderDrink = AddOrderDrink.Text;
                existingOrder.Status = AddStatus.Text;

                DemExCafeEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные заказа обновлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.CafeFrame.Navigate(new Pages.PlaceCook());
            }
            else
            {
                try
                {
                    Orders NewOrder = new Orders()
                    {
                        idUser = int.Parse(AddID.Text),
                        NameOrder = AddName.Text,
                        NumberTable = int.Parse(AddNumberTable.Text),
                        CountClients = int.Parse(AddCountClients.Text),
                        OrderDish = AddOrderDish.Text,
                        OrderDrink = AddOrderDrink.Text,
                        Status = AddStatus.Text,
                        DateStart = DateTime.Parse(AddDateStart.Text),
                        DateEnd = DateTime.Parse(AddDateEnd.Text),
                    };
                    DemExCafeEntities.GetContext().Orders.Add(NewOrder);
                    DemExCafeEntities.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь добавлен!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    AddID.Text = "";
                    AddName.Text = "";
                    AddNumberTable.Text = "";
                    AddCountClients.Text = "";
                    AddOrderDish.Text = "";
                    AddOrderDrink.Text = "";
                    AddStatus.Text = "";
                    AddDateStart.Text = "";
                    AddDateEnd.Text = "";
                    Manager.CafeFrame.Navigate(new Pages.PlaceWaiter());
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
