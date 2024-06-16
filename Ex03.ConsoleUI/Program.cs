using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            Garage garage = new Garage();
            string userInput = null;

            while (userInput != "Q")
            {
                Console.WriteLine("enter: insert(insert new vehicle), show all licenses, change vehicle status, add air pressure, add fuel to car, "); //TODO : fix message
                userInput = Console.ReadLine();
                try
                {
                    HandleUserInput(garage, userInput);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void HandleUserInput(Garage garage, string userInput)
        {
            switch (userInput)
            {
                case "insert":
                    InsertVehicle(garage);
                    break;
                case "show all licenses":
                    ShowAllLicenses(garage);
                    break;
                case "change vehicle status":
                    ChangeVehicleStatus(garage);
                    break;
                case "add air pressure":
                    AddAirPressure(garage);
                    break;
                case "add fuel to car":
                    AddFuel(garage);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }

        private static void InsertVehicle(Garage garage)
        {
            Console.WriteLine("enter license for car: ");
            string licenseCar = Console.ReadLine();
            Console.WriteLine("with type vehicle to enter (car/truck/motorcycle): ");
            string withCarToEnter = Console.ReadLine();

            string attributesToEnter = garage.addVehicleToGarage(licenseCar, withCarToEnter);
            if (attributesToEnter == "car already in garage, moved to status: in-progress")
            {
                Console.WriteLine(attributesToEnter);
                return;
            }

            Console.WriteLine("enter name of owner: ");
            string nameOfOwner = Console.ReadLine();
            Console.WriteLine("enter phone of owner: ");
            string phoneOfOwner = Console.ReadLine();
            Console.WriteLine("enter the status you want for the car (INPROGRESS/FIXED/PAYED): ");
            string carStatus = Console.ReadLine();

            garage.setLastEnteredVehicle(nameOfOwner);
            garage.setLastEnteredVehicle(phoneOfOwner);
            garage.setLastEnteredVehicle(carStatus);
            garage.setLastEnteredVehicle(licenseCar);

            ProcessVehicleAttributes(garage, attributesToEnter);
        }

        private static void ProcessVehicleAttributes(Garage garage, string attributesToEnter)
        {
            string[] attributesArray = attributesToEnter.Split(new string[] { "||" }, StringSplitOptions.None);

            foreach (string attribute in attributesArray)
            {
                string messageWithAttributeToEnter = attribute.Split(new string[] { "::" }, StringSplitOptions.None)[0];
                string typeOfAttribute = attribute.Split(new string[] { "::" }, StringSplitOptions.None)[1];
                Console.WriteLine(messageWithAttributeToEnter);
                string inputAttribute = Console.ReadLine();

                switch (typeOfAttribute)
                {
                    case "int":
                        if (!int.TryParse(inputAttribute, out int intInputAttribute))
                        {
                            throw new FormatException("Cannot convert to int");
                        }
                        garage.setLastEnteredVehicle(intInputAttribute);
                        break;
                    case "float":
                        if (!float.TryParse(inputAttribute, out float floatInputAttribute))
                        {
                            throw new FormatException("Cannot convert to float");
                        }
                        garage.setLastEnteredVehicle(floatInputAttribute);
                        break;
                    case "bool":
                        if (!bool.TryParse(inputAttribute, out bool boolInputAttribute))
                        {
                            throw new FormatException("Cannot convert to bool");
                        }
                        garage.setLastEnteredVehicle(boolInputAttribute);
                        break;
                    default:
                        garage.setLastEnteredVehicle(inputAttribute);
                        break;
                }

                if (messageWithAttributeToEnter == "is car on fuel" && bool.Parse(inputAttribute))
                {
                    Console.WriteLine("enter type of fuel for car: ");
                    string typeOfFuel = Console.ReadLine();
                    garage.setLastEnteredVehicle(typeOfFuel);
                }
            }
        }

        private static void ShowAllLicenses(Garage garage)
        {
            Console.WriteLine("what type of licenses(INPROGRESS,FIXED,PAYED,ANY): ");
            string typeOfLicenses = Console.ReadLine();

            List<string> allLicenses = garage.showAllLicenses(typeOfLicenses); //TODO : need to handle exception
            foreach (string license in allLicenses)
            {
                Console.WriteLine(license);
            }
        }

        private static void ChangeVehicleStatus(Garage garage)
        {
            Console.WriteLine("enter license of car to change status to: ");
            string licenseCar = Console.ReadLine();
            Console.WriteLine("enter new status: ");
            string newStatus = Console.ReadLine();
            garage.changeStatusToCar(licenseCar, newStatus); //TODO : need to handle exception
        }

        private static void AddAirPressure(Garage garage)
        {
            Console.WriteLine("enter license of car to add pressure to: ");
            string licenseCar = Console.ReadLine();
            garage.FillFullAirPressureInWheels(licenseCar); //TODO : need to handle exception
        }

        private static void AddFuel(Garage garage)
        {
            Console.WriteLine("enter license of car to add fuel to: ");
            string licenseCar = Console.ReadLine();
            Console.WriteLine("enter how much fuel would you like to add: ");
            string howMuchFuel = Console.ReadLine();
            if (!float.TryParse(howMuchFuel, out float valueHowMuchFuel))
            {
                throw new FormatException("Cannot convert to float");
            }
            Console.WriteLine("enter what type of fuel do you want to use: ");
            string typeOfFuel = Console.ReadLine();
            garage.addFuel(licenseCar, valueHowMuchFuel, typeOfFuel); //TODO : need to handle exception
        }
    }
}
