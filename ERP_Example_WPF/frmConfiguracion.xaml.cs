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
using System.Windows.Shapes;

namespace ERP_Example_WPF
{
    /// <summary>
    /// Lógica de interacción para frmConfiguracion.xaml
    /// </summary>
    public partial class frmConfiguracion : Window
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            App.storageSystem.Connect(txtHost.Text);
            if(App.storageSystem.State == CareFusion.Lib.StorageSystem.State.ComponentState.Ready)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("La conexión ha sido exitosa", "Automatiza S.A.", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
                if(messageBoxResult == MessageBoxResult.OK) Close();
            }
        }
    }
}
