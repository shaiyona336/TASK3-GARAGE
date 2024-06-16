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
                Console.WriteLine("enter: insert(insert new vehicle), show all licenses, change vehicle status, add air pressure, add fuel to car, charge electricity, show information car"); //TODO : fix message
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
                    addElectricity(i_Garage);
                    break;
                case "show information car":
                    showInformationAboutCar(i_Garage);
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

            // Send data basic about car to garage
            Action<string> setLastEnteredVehicle = i_Garage.setLastEnteredVehicle;
            executeMethod("enter name of owner: ", setLastEnteredVehicle);
            executeMethod("enter phone number of owner:", setLastEnteredVehicle);
            executeMethod("enter the status you want for the car (INPROGRESS/FIXED/PAYED):", setLastEnteredVehicle);
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

                string parsedValue = parseAttribute(typeOfAttribute, inputAttribute);
                i_Garage.setLastEnteredVehicle(parsedValue);

                if (messageWithAttributeToEnter == "is car on fuel" && bool.Parse(inputAttribute))
                {
                    executeMethod("enter type of fuel for car:", (Action<string>)i_Garage.setLastEnteredVehicle);
                }
            }
        }

        private static string parseAttribute(string i_TypeOfAttribute, string i_InputAttribute)
        {
            var parsers = new Dictionary<string, Func<string, string>>
    {
        { "int", input => int.TryParse(input, out int result) ? input : throw new FormatException("Cannot convert to int") },
        { "float", input => float.TryParse(input, out float result) ? input : throw new FormatException("Cannot convert to float") },
        { "bool", input => bool.TryParse(input, out bool result) ? input : throw new FormatException("Cannot convert to bool") },
        { "string", input => input }
    };

            if (!parsers.ContainsKey(i_TypeOfAttribute))
            {
                throw new ArgumentException($"Unsupported attribute type: {i_TypeOfAttribute}");
            }

            return parsers[i_TypeOfAttribute](i_InputAttribute);
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

        //private static void showAllLicenses(Garage i_Garage)
        //{
        //    Console.WriteLine("what type of licenses(INPROGRESS,FIXED,PAYED,ANY): ");
        //    string typeOfLicenses = Console.ReadLine();

        //    switch (typeOfLicenses)
        //    {
        //        case "A":
        //        case "A1":
        //        case "AA":
        //        case "B1":
        //            List<string> allLicenses = i_Garage.showAllLicenses(typeOfLicenses); //TODO : need to handle exception (done?)
        //            foreach (string license in allLicenses)
        //            {
        //                Console.WriteLine(license);
        //            }
        //            break;
        //        default:
        //            throw new ArgumentException($"No valid license type matches \"{typeOfLicenses}\"");
        //    }
        //}

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
            executeMethod("enter license of car to add pressure to:", (Action<string>)i_Garage.FillFullAirPressureInWheels);
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

        public static void showInformationAboutCar(Garage i_Garage)
        {
            string i_licenseCarToShowInformationAbout;
            string i_informationAboutCar;

            Console.WriteLine("enter license of car to show information about: ");
            i_licenseCarToShowInformationAbout = Console.ReadLine();
            i_informationAboutCar = i_Garage.showInformationAboutCar(i_licenseCarToShowInformationAbout);
            Console.WriteLine(i_informationAboutCar);
        }

        private static object executeMethod(string i_RequestFromUser, Delegate i_Function)
        {
            object returnValue = null;
            while (true)
            {
                Console.WriteLine(i_RequestFromUser);
                string userInput = Console.ReadLine();

                try
                {
                    if (i_Function is Func<string, object> nonVoidMethod)
                    {
                        returnValue = nonVoidMethod(userInput);
                    }
                    else if (i_Function is Action<string> voidMethod)
                    {
                        voidMethod(userInput);
                    }

                    break;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return returnValue;
        }

    }
}


