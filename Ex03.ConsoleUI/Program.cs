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
                    handleUserInput(garage, userInput);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void handleUserInput(Garage i_Garage, string i_UserInput)
        {
            switch (i_UserInput)
            {
                case "insert":
                    insertVehicle(i_Garage);
                    break;
                case "show all licenses":
                    showAllLicenses(i_Garage);
                    break;
                case "change vehicle status":
                    changeVehicleStatus(i_Garage);
                    break;
                case "add air pressure":
                    addAirPressure(i_Garage);
                    break;
                case "add fuel to car":
                    addFuel(i_Garage);
                    break;
                case "charge electricity":
                    addFuel(i_Garage);
                    break;
                case "show information car":
                    addFuel(i_Garage);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }

        private static void insertVehicle(Garage i_Garage)
        {
            Console.WriteLine("enter license for car: ");
            string licenseCar = Console.ReadLine();
            Console.WriteLine("with type vehicle to enter (car/truck/motorcycle): ");
            string withCarToEnter = Console.ReadLine();

            string attributesToEnter = i_Garage.addVehicleToGarage(licenseCar, withCarToEnter);
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

            // Send data basic about car to garage
            i_Garage.setLastEnteredVehicle(nameOfOwner);
            i_Garage.setLastEnteredVehicle(phoneOfOwner);
            i_Garage.setLastEnteredVehicle(carStatus);
            i_Garage.setLastEnteredVehicle(licenseCar);

            processVehicleAttributes(i_Garage, attributesToEnter);
        }

        private static void processVehicleAttributes(Garage i_Garage, string i_AttributesToEnter)
        {
            string[] attributesArray = i_AttributesToEnter.Split(new string[] { "||" }, StringSplitOptions.None);

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
                            //TODO : exception cannot convert to int (done?)
                        }
                        i_Garage.setLastEnteredVehicle(intInputAttribute);
                        break;
                    case "float":
                        if (!float.TryParse(inputAttribute, out float floatInputAttribute))
                        {
                            throw new FormatException("Cannot convert to float");
                            //TODO : exception cannot convert to float (done?)
                        }
                        i_Garage.setLastEnteredVehicle(floatInputAttribute);
                        break;
                    case "bool":
                        if (!bool.TryParse(inputAttribute, out bool boolInputAttribute))
                        {
                            throw new FormatException("Cannot convert to bool");
                            //TODO : exception cannot convert to boolean (done?)
                        }
                        i_Garage.setLastEnteredVehicle(boolInputAttribute);
                        break;
                    default: // Needed to send string
                        i_Garage.setLastEnteredVehicle(inputAttribute);
                        break;
                }

                if (messageWithAttributeToEnter == "is car on fuel" && bool.Parse(inputAttribute))
                {
                    Console.WriteLine("enter type of fuel for car: ");
                    string typeOfFuel = Console.ReadLine();
                    i_Garage.setLastEnteredVehicle(typeOfFuel);
                }
            }
        }

        private static void showAllLicenses(Garage i_Garage)
        {
            string i_whatTypeOfLicensesToShow;
            List<string> allLicenses;
            Console.WriteLine("what type of licenses(INPROGRESS,FIXED,PAYED,ANY): ");
            i_whatTypeOfLicensesToShow = Console.ReadLine();
            allLicenses = i_Garage.showAllLicenses(i_whatTypeOfLicensesToShow); //TODO : need to handle exception
            foreach (string i_licenses in allLicenses)
            {
                Console.WriteLine(i_licenses);

            }
        }

        private static void changeVehicleStatus(Garage i_Garage)
        {
            Console.WriteLine("enter license of car to change status to: ");
            string licenseCar = Console.ReadLine();
            Console.WriteLine("enter new status: ");
            string newStatus = Console.ReadLine();
            i_Garage.changeStatusToCar(licenseCar, newStatus); //TODO : need to handle exception
        }

        private static void addAirPressure(Garage i_Garage)
        {
            Console.WriteLine("enter license of car to add pressure to: ");
            string licenseCar = Console.ReadLine();
            i_Garage.FillFullAirPressureInWheels(licenseCar); //TODO : need to handle exception
        }

        private static void addFuel(Garage i_Garage)
        {

            Console.WriteLine("enter license of car to add fuel to: ");
            string licenseCar = Console.ReadLine();
            Console.WriteLine("enter how much fuel would you like to add: ");
            string howMuchFuel = Console.ReadLine();
            if (!float.TryParse(howMuchFuel, out float valueHowMuchFuel))
            {
                throw new FormatException("Cannot convert to float");
                //TODO : need to put this line in try
            }
            Console.WriteLine("enter what type of fuel do you want to use: ");
            string typeOfFuel = Console.ReadLine();
            i_Garage.addFuel(licenseCar, valueHowMuchFuel, typeOfFuel); //TODO : need to handle exception
        }

        public static void addElectricity(Garage i_Garage)
        {
            string i_licenseCarToCharge;
            string i_howMuchElectricityToAdd;

            Console.WriteLine("enter licenses of car to add pressure to: ");
            i_licenseCarToCharge = Console.ReadLine();
            Console.WriteLine("enter amount of hours to add to battery: ");
            i_howMuchElectricityToAdd = Console.ReadLine();
            if (!float.TryParse(i_howMuchElectricityToAdd, out float i_valueHowMuchElectricityToAdd))
            {
                throw new FormatException("Cannot convert to float");
            }
            i_Garage.addElectricity(i_licenseCarToCharge, i_valueHowMuchElectricityToAdd);

         }
     }
  }


