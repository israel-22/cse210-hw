using System;
using System.Collections.Generic;

namespace OrderSystem
{
    // Address class
    public class Address
    {
        private string street;
        private string city;
        private string stateOrProvince;
        private string country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            this.street = street;
            this.city = city;
            this.stateOrProvince = stateOrProvince;
            this.country = country;
        }

        public bool IsInUSA()
        {
            return country.Trim().ToLower() == "usa" || country.Trim().ToLower() == "united states";
        }

        public string GetFullAddress()
        {
            return $"{street}\n{city}, {stateOrProvince}\n{country}";
        }
    }

    // Product class
    public class Product
    {
        private string name;
        private string productId;
        private double price;
        private int quantity;

        public Product(string name, string productId, double price, int quantity)
        {
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.quantity = quantity;
        }

        public double GetTotalCost()
        {
            return price * quantity;
        }

        public string GetPackingInfo()
        {
            return $"{name} (ID: {productId})";
        }
    }

    // Customer class
    public class Customer
    {
        private string name;
        private Address address;

        public Customer(string name, Address address)
        {
            this.name = name;
            this.address = address;
        }

        public bool LivesInUSA()
        {
            return address.IsInUSA();
        }

        public string GetName()
        {
            return name;
        }

        public string GetFullAddress()
        {
            return address.GetFullAddress();
        }
    }

    // Order class
    public class Order
    {
        private List<Product> products = new List<Product>();
        private Customer customer;

        public Order(Customer customer)
        {
            this.customer = customer;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var product in products)
            {
                total += product.GetTotalCost();
            }

            // Shipping cost
            if (customer.LivesInUSA())
            {
                total += 5;
            }
            else
            {
                total += 35;
            }

            return total;
        }

        public string GetPackingLabel()
        {
            string label = "Packing Label:\n";
            foreach (var product in products)
            {
                label += $"- {product.GetPackingInfo()}\n";
            }
            return label;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{customer.GetName()}\n{customer.GetFullAddress()}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // First order
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Customer customer1 = new Customer("Alice Johnson", address1);

            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "P001", 1200, 1));
            order1.AddProduct(new Product("Mouse", "P002", 25, 2));

            // Second order
            Address address2 = new Address("45 Queen St", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Bob Smith", address2);

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Phone", "P003", 800, 1));
            order2.AddProduct(new Product("Headphones", "P004", 50, 3));

            // Display results
            List<Order> orders = new List<Order> { order1, order2 };

            foreach (var order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Price: ${order.GetTotalPrice()}\n");
                Console.WriteLine(new string('-', 40));
            }

            Console.ReadLine();
        }
    }
}
