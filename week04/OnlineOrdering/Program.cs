using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 (USA)
        Address address1 = new Address("123 Maple St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Keyboard", "K123", 25.99, 2));
        order1.AddProduct(new Product("Mouse", "M456", 15.50, 1));

        // Order 2 (International)
        Address address2 = new Address("456 Oxford Rd", "London", "ENG", "UK");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Monitor", "MN789", 180.00, 1));
        order2.AddProduct(new Product("HDMI Cable", "HD101", 10.00, 3));

        // Display results
        DisplayOrder(order1);
        Console.WriteLine("-----------------------------------");
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalCost():0.00}");
    }
}


