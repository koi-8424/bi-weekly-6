using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tWelcome to Sydney Hotel");
            int i = 0;
            string[] name = new string[20];
            int[] night = new int[20];
            string[] roomservice = new string[20];
            double[] costlist = new double[20];
            string[] roomtype = new string[20];
            int[] loyaltyPoints = new int[20];

            // Loop to repeat the steps
            while (true)
            {
                // Taking user inputs
                Console.WriteLine("Enter Customer Name:");
                string Name = Console.ReadLine();
                name[i] = Name;

                Console.WriteLine("Enter Number of Nights:");
                int NumberOfnight = 0;
                while (true)
                {
                    NumberOfnight = int.Parse(Console.ReadLine());
                    if (NumberOfnight >= 1 && NumberOfnight <= 20)
                    {
                        night[i] = NumberOfnight;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number of nights. Must be between 1 and 20:");
                    }
                }

                Console.WriteLine("Select Room Type (Standard/Deluxe/Suite):");
                string roomType;
                double roomCost = 0;
                while (true)
                {
                    roomType = Console.ReadLine().ToLower();
                    if (roomType == "standard")
                    {
                        roomCost = 100;
                        break;
                    }
                    else if (roomType == "deluxe")
                    {
                        roomCost = 150;
                        break;
                    }
                    else if (roomType == "suite")
                    {
                        roomCost = 200;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid room type. Please enter Standard, Deluxe, or Suite:");
                    }
                }
                roomtype[i] = char.ToUpper(roomType[0]) + roomType.Substring(1);

                Console.WriteLine("Enter Yes/No to indicate whether you want room service:");
                string roomService = Console.ReadLine().ToLower();
                roomservice[i] = roomService;

                // Calculate bill
                double cost = NumberOfnight * roomCost;
                if (roomService == "yes")
                {
                    cost += cost * 0.10; // Add 10% for room service
                }
                costlist[i] = cost;

                // Calculate loyalty points
                loyaltyPoints[i] = (int)(cost / 10); // Earn 1 point for every $10 spent

                // Printing results
                Console.WriteLine($"Total price for {Name} is ${cost:F2}");
                Console.WriteLine($"Loyalty points earned: {loyaltyPoints[i]}");

                i++;

                // Input to quit or continue
                Console.WriteLine("________________________________________");
                Console.WriteLine("Press Q to exit or any other key to continue:");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "q")
                {
                    break;
                }
                Console.WriteLine("________________________________________");
            }

            // Displaying the data in table format
            Console.WriteLine("\t\t\tSummary of Reservations");
            Console.WriteLine("Name\t\tRoom Type\tNights\tRoom Service\tCharge\tLoyalty Points");
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine($"{name[j]}\t\t{roomtype[j]}\t\t{night[j]}\t{roomservice[j]}\t\t${costlist[j]:F2}\t{loyaltyPoints[j]}");
            }

            // Check highest and least spending
            double largest = costlist[0];
            int ind = 0;
            for (int j = 1; j < i; j++)
            {
                if (largest < costlist[j])
                {
                    largest = costlist[j];
                    ind = j;
                }
            }
            Console.WriteLine($"Customer spending the most is {name[ind]} with ${costlist[ind]:F2}");

            double min = costlist[0];
            int ind2 = 0;
            for (int j = 1; j < i; j++)
            {
                if (min > costlist[j])
                {
                    min = costlist[j];
                    ind2 = j;
                }
            }
            Console.WriteLine($"Customer spending the least is {name[ind2]} with ${costlist[ind2]:F2}");
        }
    }
}
