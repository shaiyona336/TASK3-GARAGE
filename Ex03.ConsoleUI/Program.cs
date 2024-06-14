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
            string i_attributesToEnter;
            string[] i_attributesToEnterArray;
            //every car that we add we need to send name of owner, phone number of owner, and car status
            string nameOfOwnerLastAddedCar;
            string phoneOfOwnerLastAddedCar;
            string carStatusLastAddedCar;

            while (i_userInput != "Q")
            {
                Console.WriteLine("enter: insert(insert new car),"); //TODO : fix message
                i_userInput = Console.ReadLine();
                switch(i_userInput)
                {
                    case ("insert"):
                        i_licenseCar = Console.ReadLine();
                        i_attributesToEnter = i_garage.addVehicleToGarage(i_licenseCar,"car");
                        if (i_attributesToEnter == "car already in garage, moved to status: in-progress")
                        {
                            Console.WriteLine(i_attributesToEnter);
                        }
                        else //if new car added to the garage
                        {
                            nameOfOwnerLastAddedCar = Console.ReadLine();
                            phoneOfOwnerLastAddedCar = Console.ReadLine();
                            carStatusLastAddedCar = Console.ReadLine();
                            i_attributesToEnterArray = i_attributesToEnter.Split(new string[] { "::" }, StringSplitOptions.None);

                        }
                        break;
                }
                
            }

        }
    }
}
