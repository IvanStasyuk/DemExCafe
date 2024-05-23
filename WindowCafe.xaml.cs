using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace AppDemExCafe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var uriMain = new Uri("pack://application:,,,/Resources/Cafe_fon.png");
            var bitmapMain = new BitmapImage(uriMain);
            FonBackground.Background = new ImageBrush(bitmapMain);
            Manager.CafeFrame = CafeFrame;
            Manager.CafeFrame.Navigate(new Pages.Autorisation());
            Manager.FonBackground = FindName("FonBackground") as Grid;   
        }

        private void CanToGo_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.CafeFrame.CanGoBack)
            {
                CafeFrame.GoBack();
            }
            else
            {
                CafeFrame = null;
            }
        }
    }
}
