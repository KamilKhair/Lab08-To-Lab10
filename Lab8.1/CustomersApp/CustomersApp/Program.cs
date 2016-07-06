using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace customersApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customersList = new List<Customer>
            {
                new Customer(10, "Kamil", "Maghar"),
                new Customer(30, "Amir", "Maghar"),
                new Customer(60, "Yair", "Maghar"),
                new Customer(90, "kamil", "Tel-Aviv"),
                new Customer(120, "amir", "Tel-Aviv"),
                new Customer(150, "yair", "Tel-Aviv")
            };

            Console.WriteLine("All Customers:");
            Display(customersList);

            // Seperate Delegate method
            Console.WriteLine("Customers with name starts with A-K:");
            var customersStartsWithAtoK = new CustomerFilter(CustomersStartWithAtoK);
            // CustomerFilter customersStartsWithAtoK = CustomersStartWithAtoK;
            Display(GetCustomers(customersList, customersStartsWithAtoK));

            // Anonymous Delegate
            Console.WriteLine("Customers with name starts with L-Z:");
            Display(GetCustomers(customersList, delegate(Customer customer)
            {
                return Regex.IsMatch(customer.Name, @"[L-Z]");
            }));


            // Lambda expression
            Console.WriteLine("Customers with ID < 100:");
            Display(GetCustomers(customersList, customer => customer.Id < 100));

        }

        public static bool CustomersStartWithAtoK(Customer customer)
        {
            return Regex.IsMatch(customer.Name, @"[A-K]");
        }

        public static ICollection<Customer> GetCustomers(ICollection<Customer> customerCollection, CustomerFilter customerFilter)
        {
            var list = new List<Customer>();
            foreach (var customer in customerCollection)
            {
                if (customerFilter(customer))
                {
                    list.Add(customer);
                }
            }
            return list;
        }

        public static void Display(ICollection<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID = {customer.Id} Name = {customer.Name} Address = {customer.Address}");
            }
            Console.WriteLine();
        }
    }
}
