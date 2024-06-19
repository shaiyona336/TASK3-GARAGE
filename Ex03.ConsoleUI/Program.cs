using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            Garage garage = new Garage();
            int userInput = 0;
            Console.WriteLine("Welcome to Garage program!");

            while (userInput != 8)
            {
                InputHandler.PrintProgramOptions();

                userInput = int.Parse(Console.ReadLine());
                try
                {
                    InputHandler.HandleUserInput(garage, userInput);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}