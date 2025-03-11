using System;
using OOP;

class MainProgram
{
    public static void Main()
    {
        OOP.ManageProduct.InsertNewProduct newProduct = new OOP.ManageProduct.InsertNewProduct();
        int maxEntries = 10;
        int currentEntries = 0;

        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        if (newProduct.Login(username, password))
        {
            Console.WriteLine(" __         ______     ______     __     __   __        ______     __  __     ______     ______     ______     ______     ______     ______   __  __     __        \r\n/\\ \\       /\\  __ \\   /\\  ___\\   /\\ \\   /\\ \"-.\\ \\      /\\  ___\\   /\\ \\/\\ \\   /\\  ___\\   /\\  ___\\   /\\  ___\\   /\\  ___\\   /\\  ___\\   /\\  ___\\ /\\ \\/\\ \\   /\\ \\       \r\n\\ \\ \\____  \\ \\ \\/\\ \\  \\ \\ \\__ \\  \\ \\ \\  \\ \\ \\-.  \\     \\ \\___  \\  \\ \\ \\_\\ \\  \\ \\ \\____  \\ \\ \\____  \\ \\  __\\   \\ \\___  \\  \\ \\___  \\  \\ \\  __\\ \\ \\ \\_\\ \\  \\ \\ \\____  \r\n \\ \\_____\\  \\ \\_____\\  \\ \\_____\\  \\ \\_\\  \\ \\_\\\\\"\\_\\     \\/\\_____\\  \\ \\_____\\  \\ \\_____\\  \\ \\_____\\  \\ \\_____\\  \\/\\_____\\  \\/\\_____\\  \\ \\_\\    \\ \\_____\\  \\ \\_____\\ \r\n  \\/_____/   \\/_____/   \\/_____/   \\/_/   \\/_/ \\/_/      \\/_____/   \\/_____/   \\/_____/   \\/_____/   \\/_____/   \\/_____/   \\/_____/   \\/_/     \\/_____/   \\/_____/ \r\n                                                                                                                                                                   ");

            while (currentEntries < maxEntries)
            {
                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter product price: ");
                if (int.TryParse(Console.ReadLine(), out int productPrice))
                {
                    if (productPrice >= 1 && productPrice <= 1000000)
                    {
                        Console.Write("Enter product description: ");
                        string productDescription = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(productDescription))
                        {
                            newProduct.InsertData(productName, productPrice, productDescription);
                            currentEntries++;
                            Console.WriteLine($"{username} inserted {currentEntries} of {maxEntries} entries.");
                        }
                        else
                        {
                            Console.WriteLine("Product description must be provided.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Product price must be between 1 and 1000000.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid price. Please enter a valid integer.");
                }
            }

            Console.WriteLine("Maximum number of entries reached.");
        }
        else
        {
            Console.WriteLine("Login failed. Invalid username or password.");
        }
    }
}
