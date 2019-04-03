using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ERP_Example_WPF.Modules.stock
{
    public class Products
    {
        private List<Product> products = new List<Product>();

        public static Product Obtener(string Id)
        {
            Product product = null;

            using (var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "bd.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    if (values[5] == Id)
                    {
                        product = new Product();
                        product.Id = Id;
                        product.Name = values[2].ToLower() + " " + values[3];
                        product.Name = product.Name.First().ToString().ToUpper() + product.Name.Substring(1);
                        product.DossageForm = new DossageForm("COM", "Comprimidos");
                        product.PackageUnit = "21";
                        break;
                    }
                }
            }

            return product;
        }
    }
}
