/*using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        // Please note we could use a do-while loop here instead
        int userNumber = -1;
        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            
            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);
            
            // Only add the number to the list if it is not 0
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Part 1: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        // Part 2: Compute the average
        // Notice that we first cast the sum variable to be a float. Otherwise, because
        // both the sum and the count are integers, the computer will do integer division
        // and I will not get a decimal value (even though it puts the result into a float variable).

        // By making one of the variables a float first, the computer knows that it has to
        // do the floating point division, and we get the decimal value that we expect.
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Part 3: Find the max
        // There are several ways to do this, such as sorting the list
        
        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (number > max)
            {
                // if this number is greater than the max, we have found the new max!
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}*/
class Program
{
    static void Main(string[] args)
    {
        // Order 1
        Address address1 = new Address(
            "123 Main Street",
            "Dallas",
            "Texas",
            "USA");

        Customer customer1 = new Customer(
            "Jean jacques Museeau",
            address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product(
            "Laptop",
            "P1001",
            850.00,
            1));

        order1.AddProduct(new Product(
            "Wireless Mouse",
            "P1002",
            25.00,
            2));

        order1.AddProduct(new Product(
            "Keyboard",
            "P1003",
            40.00,
            1));


        // Order 2
        Address address2 = new Address(
            "15 Rue Metellus",
            "Port-au-Prince,Petion-Ville",
            "Ouest",
            "Haiti");

        Customer customer2 = new Customer(
            "Marie Jean",
            address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product(
            "Headphones",
            "P2001",
            50.00,
            1));

        order2.AddProduct(new Product(
            "USB Cable",
            "P2002",
            10.00,
            3));

        order2.AddProduct(new Product(
            "Webcam",
            "P2003",
            75.00,
            1));


        // Display Order 1
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


        // Display Order 2
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