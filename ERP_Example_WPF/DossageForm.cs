using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP_Example_WPF
{
    public class DossageForm
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public DossageForm(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
