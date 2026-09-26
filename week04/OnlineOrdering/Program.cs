class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main Street",
            "Dallas",
            "Texas",
            "USA");

        Customer customer1 = new Customer(
            "Jean jacques Museeau",
            address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P1001", 850.00, 1));
        order1.AddProduct(new Product("Wireless Mouse", "P1002", 25.00, 2));
        order1.AddProduct(new Product("Keyboard", "P1003", 40.00, 1));

        Address address2 = new Address(
            "15 Rue Metellus",
            "Port-au-Prince,Petion-Ville",
            "Ouest",
            "Haiti");

        Customer customer2 = new Customer(
            "Marie Jean",
            address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Headphones", "P2001", 50.00, 1));
        order2.AddProduct(new Product("USB Cable", "P2002", 10.00, 3));
        order2.AddProduct(new Product("Webcam", "P2003", 75.00, 1));

        Console.WriteLine("========== ORDER 1 ==========");
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");
        Console.WriteLine();
        Console.WriteLine("=============================");
        Console.WriteLine();

        Console.WriteLine("========== ORDER 2 ==========");
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
        Console.WriteLine();
        Console.WriteLine("=============================");
    }
}