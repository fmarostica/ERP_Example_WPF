using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP_Example_WPF.Modules.stock
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DossageForm DossageForm { get; set; }
        public string PackageUnit { get; set; }

    }
}
