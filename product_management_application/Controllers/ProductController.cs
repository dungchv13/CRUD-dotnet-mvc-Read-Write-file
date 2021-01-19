using product_management_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace product_management_application.Controllers
{
    public class ProductController : Controller
    {
        private static FileManagement fileManagement = new FileManagement();
        private List<Product> products = fileManagement.readFile();
        
        // GET: Product
        public ActionResult Index()
        {

            ViewBag.products = products;
            return View();
        }
       

        public ActionResult Edit(int id) 
        {
            Product product = new Product();

            foreach(var pro in products)
            {
                if(pro.Id == id)
                {
                    product = pro;
                }
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {

            foreach(var p in products)
            {
                if (p.Id == product.Id)
                {
                    p.Name = product.Name;
                    p.Pride = product.Pride;
                    p.Provider = product.Provider;
                }
            }
            fileManagement.WriteFile(products);
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Delete(int id)
        {
           
            Product product = new Product();
            foreach (var p in products)
            {
                if (p.Id == id)
                {
                    product = p;
                }
            }

            products.Remove(product);
            fileManagement.WriteFile(products);
            return RedirectToAction("Index", "Product");
        }

        public ActionResult Create()
        {
            Product product = new Product();
           
            return View(product);
        }


        [HttpPost]
        public ActionResult Create(Product product)
        {
           
            products.Add(product);
            fileManagement.WriteFile(products);
            return RedirectToAction("Index", "Product");
        }

    }
}