using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace myShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"D:\Koolitööd\Programmeerimise alused\Samples";
            string newDirectory = @"\shoppingList"; //saab teha ka Console.ReadLine-iga, aga hetkel ülesanne näeb ette kindla kausta ja faili nime
            string fileName = @"\myShoppingList.txt";

            char userInput;



            if (Directory.Exists($"{rootDirectory}{newDirectory}") && File.Exists($"{rootDirectory}{newDirectory}{fileName}"))
            {
                AddToFile(rootDirectory, newDirectory, fileName);

            }
            else if (Directory.Exists($"{rootDirectory}{newDirectory}") && File.Exists($"{rootDirectory}{newDirectory}{fileName}") == false)
            {
                Console.WriteLine("Kas te soovite luua nimekirja? Y/N");
                userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    FileCreation(rootDirectory, newDirectory, fileName);
                    AddToFile(rootDirectory, newDirectory, fileName);
                }
            }
            else
            {
                Console.WriteLine("Kas te soovite luua ostukorvi kausta ja faili? Y/N");
                userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    FileCreation(rootDirectory, newDirectory, fileName);
                    AddToFile(rootDirectory, newDirectory, fileName);
                }
            }
        }


        private static void FileCreation(string rootDirectory, string newDirectory, string fileName)
        {
            if (Directory.Exists($"{rootDirectory}{newDirectory}"))
            {
                File.Create($"{rootDirectory}{newDirectory}{fileName}").Close();
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}{newDirectory}");
                File.Create($"{rootDirectory}{newDirectory}{fileName}").Close();
            }
            
        }
        private static void AddToFile(string rootDirectory, string newDirectory, string fileName)
        {
            
            string[] arrayFromFile = File.ReadAllLines($"{rootDirectory}{newDirectory}{fileName}");
            List<string> myShoppingList = arrayFromFile.ToList<string>();

            bool loopActive = true;

            while (loopActive)
            {
                Console.WriteLine("Kas te soovite nimekirja lisada midagi? Y/N");
                char userInput = Convert.ToChar(Console.ReadLine().ToLower());

                if (userInput == 'y')
                {
                    Console.WriteLine("Sisesta soovitud toode:");
                    string userNeed = Console.ReadLine();
                    myShoppingList.Add(userNeed);
                }
                else
                {
                    loopActive = false;
                    Console.WriteLine("Kena päeva!");
                }
            }

            Console.Clear();

            foreach (string item in myShoppingList)
            {
                Console.WriteLine($"Osta on vaja: {item}");
            }

            File.WriteAllLines($"{rootDirectory}{newDirectory}{fileName}", myShoppingList);
        }
    }
}
