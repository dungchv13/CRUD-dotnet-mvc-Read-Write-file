using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace product_management_application.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Pride { get; set; }
        public string Provider { get; set; }

        public Product() { }
        public Product(int id,string name,double pride,string provider)
        {
            this.Id = id;
            this.Name = name;
            this.Pride = pride;
            this.Provider = provider;
        }

    }
}