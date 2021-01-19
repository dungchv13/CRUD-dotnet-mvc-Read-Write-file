using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace product_management_application.Models
{
    public class FileManagement
    {
        String filePath = "C:/Users/DEII/source/repos/product_management_application/product_management_application/App_Data/products.txt";
        public List<Product> readFile()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] prod = line.Split(',');
                        Product product = new Product(Convert.ToInt32(prod[0]), prod[1], Convert.ToDouble(prod[2]),prod[3]);
                        products.Add(product);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);

            }
            return products;
        }
        public void WriteFile(List<Product> products)
        {
            try
            {
                // Create a file to write to.
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.Create(filePath).Dispose();
                }
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var item in products)
                    {
                        sw.WriteLine(item.Id + "," + item.Name + "," + item.Pride + "," + item.Provider);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be write:");
                Console.WriteLine(e.Message);
            }
        }
    }
}