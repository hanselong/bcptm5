using System;
using System.Collections.Generic;

namespace ShoppingCartDemo
{
    class Program
    {
        static List<Inventory> _inventoryList;

        static Program()
        {
            // Set up the initial inventory to purchase
            InventoryList defaultList = new InventoryList();
            _inventoryList = defaultList.List;
        }

        static void Main(string[] args)
        {
            // Allow user to purchase
            int subtotal = AllowPurchasing();

            // Display the summary of the transaction
            double tax = (double)subtotal * (0.095);
            Console.WriteLine("Subtotal: ${0}", subtotal);
            Console.WriteLine("Tax (9.5%): ${0}", tax);
            Console.WriteLine("Total: ${0}", subtotal + tax);

            Console.WriteLine("Press any key to end the program.");
            Console.ReadKey();
        }

        /// <summary>
        /// Allow user to keep purchasing stuff
        /// </summary>
        static int AllowPurchasing()
        {
            int userInput = 0;
            int subtotal = 0;
            int listSize = _inventoryList.Count;
            do
            {
                // Display purchase options
                DisplayPurchaseOptions();
                userInput = GetPurchaseOption();

                if (userInput < listSize)
                {
                    //Update subtotal
                    subtotal += _inventoryList[(userInput - 1)].Price;
                }
            } while (userInput != 4);

            return subtotal;
        }

        /// <summary>
        /// Display purchase options for user
        /// </summary>
        static void DisplayPurchaseOptions()
        {
            int listSize = _inventoryList.Count;
            Console.WriteLine("Please choose from the following menu:");

            //TODO: Put this in a loop
            Console.WriteLine("1. {0}", _inventoryList[0].DisplayName());
            Console.WriteLine("2. {0}", _inventoryList[2].DisplayName());
            Console.WriteLine("3. {0}", _inventoryList[0].DisplayName());
            Console.WriteLine("4. Finish purchasing");

            Console.WriteLine("Which one would you like to purchase?");
        }

        /// <summary>
        /// Get the purchasing option from the user
        /// </summary>
        /// <returns>0 if user didn't give the correct option, more than 0 if user gives an int</returns>
        static int GetPurchaseOption()
        {
            int userInput = 0;
            try
            {
                userInput = Convert.ToInt16(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a whole number!");
            }
            return userInput;
        }
    }
}
