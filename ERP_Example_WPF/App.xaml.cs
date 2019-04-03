using CareFusion.Lib.StorageSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ERP_Example_WPF
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RowaStorageSystem storageSystem = new RowaStorageSystem();
        public static string IPHost = "127.0.0.1";
    }
}
