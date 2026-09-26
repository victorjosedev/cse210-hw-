using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("             ONLINE ORDERING SYSTEM              ");
        Console.WriteLine("=================================================");
        Console.WriteLine();

        // Order 1: USA Customer
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "OR", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mechanical Keyboard", "KB-901", 79.99m, 1));
        order1.AddProduct(new Product("Ergonomic Gaming Mouse", "MS-402", 34.50m, 2));
        order1.AddProduct(new Product("Large Desk Mat", "DM-105", 18.00m, 1));

        // Order 2: International Customer (Mexico)
        Address address2 = new Address("Av. Paseo de la Reforma 222", "Mexico City", "CDMX", "Mexico");
        Customer customer2 = new Customer("Sofia Ramirez", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Noise Cancelling Headphones", "HD-880", 149.99m, 1));
        order2.AddProduct(new Product("USB-C Fast Charger 65W", "CH-330", 25.00m, 2));

        // Order 3: International Customer (Canada)
        Address address3 = new Address("123 Maple Leaf Way", "Toronto", "ON", "Canada");
        Customer customer3 = new Customer("Liam Tremblay", address3);
        Order order3 = new Order(customer3);
        order3.AddProduct(new Product("Ultra-wide Monitor 34\"", "MN-700", 389.00m, 1));
        order3.AddProduct(new Product("Heavy Duty Monitor Arm", "MA-112", 45.00m, 1));
        order3.AddProduct(new Product("HDMI 2.1 Braided Cable", "CB-505", 12.50m, 2));

        List<Order> orders = new List<Order> { order1, order2, order3 };

        int orderNumber = 1;
        foreach (Order order in orders)
        {
            Console.WriteLine($"--- ORDER #{orderNumber} ---");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine();
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}");
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine();
            orderNumber++;
        }
    }
}