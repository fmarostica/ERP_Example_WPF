using CareFusion.Lib.StorageSystem.Input;
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
using System.Windows.Shapes;

namespace ERP_Example_WPF.Modules.stock
{
    /// <summary>
    /// Lógica de interacción para frmAddStock.xaml
    /// </summary>
    public partial class frmAddStock : Window
    {
        string articleName = "";
        string dossageForm = "";
        string packageUnits = "";

        public frmAddStock()
        {
            InitializeComponent();
            App.storageSystem.PackInputRequested += StorageSystem_PackInputRequested;

            //Creamos una lista con Tipos de dosages para almacenarlos en el Combo
            List<DossageForm> dossageForms = new List<DossageForm>();
            dossageForms.Add(new DossageForm("TAB", "Blister"));
            dossageForms.Add(new DossageForm("AMP", "Ampollas"));
            txtDossageForm.ItemsSource = dossageForms;
            txtDossageForm.SelectedValuePath = "Id";
            txtDossageForm.DisplayMemberPath = "Name";

            txtDossageForm.SelectedIndex = 0;
        }

        private void StorageSystem_PackInputRequested(CareFusion.Lib.StorageSystem.IStorageSystem sender, IInputRequest request)
        {
            foreach (var pack in request.Packs)
            {
                string articleId = pack.ScanCode;
                pack.SetArticleInformation(articleId, articleName, dossageForm, packageUnits);
                pack.SetHandling(InputHandling.Allowed);
            }

            request.Finish();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            articleName = txtProductName.Text;
            dossageForm = (string)txtDossageForm.SelectedValue;
            packageUnits = txtPackageUnit.Text;
        }
    }
}
