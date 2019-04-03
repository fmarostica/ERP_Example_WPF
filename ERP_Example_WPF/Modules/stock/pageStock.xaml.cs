using CareFusion.Lib.StorageSystem.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERP_Example_WPF.Modules.stock
{
    /// <summary>
    /// Lógica de interacción para pageStock.xaml
    /// </summary>
    public partial class pageStock : Page
    {
        public pageStock()
        {
            InitializeComponent();
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            frmAddStock frmAddStock = new frmAddStock();
            frmAddStock.ShowDialog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(App.storageSystem.State != CareFusion.Lib.StorageSystem.State.ComponentState.NotConnected)
            {
                List<IArticle> articles = App.storageSystem.GetStock();
                lstStock.ItemsSource = articles;
            }
            else
            {
                MessageBox.Show("El robot no está conectado", "Automatiza S.A.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
