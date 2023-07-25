using static System.Net.Mime.MediaTypeNames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;


namespace bank
{
    static class Program
    {
        static List<Staff> staffs = new List<Staff>();
        static List<Customers> customers = new List<Customers>();

        static void Main()
        {
            Console.WriteLine("Hello, World!");
            CreateCustmors();
        }

        public static void CreateCustmors()
        {
            Customers newcustomer;
            newcustomer = new Customers("Andre", "Campos");
            customers.Add(newcustomer);
            newcustomer = new Customers("Oliver", "Campos");
            customers.Add(newcustomer);
            newcustomer = new Customers("Beatriz", "Campos");
            customers.Add(newcustomer);
            newcustomer = new Customers("Miguel", "Campos");
            customers.Add(newcustomer);

            foreach (Customers customer in customers)
            {
                Console.WriteLine(customer.firstName);
            }
        }
    }
}