using CareFusion.Lib.StorageSystem;
using CareFusion.Lib.StorageSystem.Input;
using CareFusion.Lib.StorageSystem.State;
using ERP_Example_WPF.Modules.stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ERP_Example_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            
            
        }

        private void StorageSystem_PackInputRequested(IStorageSystem sender, CareFusion.Lib.StorageSystem.Input.IInputRequest request)
        {
            foreach (var pack in request.Packs)
            {
                string articleId = pack.ScanCode;
                Product product = Products.Obtener(articleId);
                if (product == null)
                {
                    frmAddStock frmAddStock = new frmAddStock();
                    frmAddStock.ShowDialog();
                }
                else
                {
                    pack.SetArticleInformation(articleId, product.Name, product.DossageForm.Name, product.PackageUnit);
                    pack.SetHandling(InputHandling.Allowed);
                }
            }

            request.Finish();
        }

        private void BtnConfiguracion_Click(object sender, RoutedEventArgs e)
        {
            frmConfiguracion frmConfiguracion = new frmConfiguracion();
            frmConfiguracion.ShowDialog();
        }

        private void StorageSystem_StateChanged(IStorageSystem sender, ComponentState state)
        {
            switch (state)
            {
                case ComponentState.NotConnected:
                    Dispatcher.BeginInvoke(new ThreadStart(() => lblState.Content = "Estado: Desconectado"));
                    break;
                case ComponentState.Ready:
                    Dispatcher.BeginInvoke(new ThreadStart(() => lblState.Content = "Estado: Listo"));
                    break;
                case ComponentState.NotReady:
                    Dispatcher.BeginInvoke(new ThreadStart(() => lblState.Content = "Estado: Ocupado"));
                    break;
                default:
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Se liberan los procesos para cerrar el programa completamente
            App.storageSystem.Disconnect();
            App.storageSystem.Dispose();
        }

        private void BtnStock_Click(object sender, RoutedEventArgs e)
        {
            Modules.stock.pageStock pageStock = new Modules.stock.pageStock();
            mainFrame.Navigate(pageStock);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                App.storageSystem.StateChanged += StorageSystem_StateChanged;
                App.storageSystem.PackInputRequested += StorageSystem_PackInputRequested;
                App.storageSystem.Connect(App.IPHost);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Automatiza S.A.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
