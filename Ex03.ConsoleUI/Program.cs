using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            Garage i_garage = new Garage();
            string i_userInput = null;
            string i_licenseCar;

            while (i_userInput != "Q")
            {
                Console.WriteLine("enter: insert(insert new car),"); //TODO : fix message
                i_userInput = Console.ReadLine();
                switch(i_userInput)
                {
                    case ("insert"):
                        i_licenseCar = Console.ReadLine();
                        i_garage.addVehicleToGarage(i_licenseCar);
                        break;
                }
                
            }

        }
    }
}
