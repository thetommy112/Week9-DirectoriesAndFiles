﻿using System;
using System.IO;

namespace DirectoriesAndFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string rootDirectory = @"D:\Koolitööd\Programmeerimise alused\Samples";

            Console.WriteLine("Enter directory name:");
            string newDirectory = Console.ReadLine();

            Console.WriteLine("Enter file name:");
            string fileName = Console.ReadLine();

            
            

            if (Directory.Exists($"{rootDirectory}\\{newDirectory}") && File.Exists($"{rootDirectory}\\{newDirectory}\\{fileName}"))
            {
                Console.WriteLine($"Directory and file exists.");
            }
            else
            {
                Directory.CreateDirectory($"{rootDirectory}\\{newDirectory}");
                File.Create($"{rootDirectory}\\{newDirectory}\\{fileName}");
            }

        }
    }
}
