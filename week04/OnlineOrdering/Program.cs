using System;

class Program
{
    static void Main(string[] args)
    {
        // Av. Las Mercedes, Caracas, Miranda, Venezuela
        Address address1 = new Address("Av. Las Mercedes", "Caracas", "Miranda", "Venezuela");
        Customer customer1 = new Customer("Ederson", address1);

        // 1600 Pennsylvania Avenue NW, Washington, DC, USA
        Customer customer2 = new Customer("Andres", "1600 Pennsylvania Avenue NW", "Washington", "DC", "USA");

        // Products
        Product product1 = new Product("ABC123", "Watch", 100.75, 2);
        Product product2 = new Product("CBA321", "Apple MacBook Air", 1393.02, 1);
        Product product3 = new Product("XYZ1234", "Laptop HP FHD", 414.99, 1);
        Product product4 = new Product("ZYX4321", "Samsung 990 EVO Plus SSD 4TB", 566.99, 1);

        List<Product> list1 = new List<Product>();
        list1.Add(product1);
        list1.Add(product2);

        List<Product> list2 = new List<Product>();
        list2.Add(product3);
        list2.Add(product4);

        Order order1 = new Order(list1, customer1);
        Order order2 = new Order(list2, customer2);

        // Order 1
        Console.WriteLine("====================");
        Console.WriteLine("Order #1");
        Console.WriteLine("====================");
        Console.WriteLine("Packing Label");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nShipping Cost: ${order1.GetShippingCost()}");
        Console.WriteLine($"\nTotal Price: ${order1.GetTotalPrice()}\n");

        // Order 2
        Console.WriteLine("====================");
        Console.WriteLine("Order #2");
        Console.WriteLine("====================");
        Console.WriteLine("Packing Label");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nShipping Cost: ${order2.GetShippingCost()}");
        Console.WriteLine($"\nTotal Price: ${order2.GetTotalPrice()}");
    }


}