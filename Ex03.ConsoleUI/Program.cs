using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
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
            string requestToUser1 = "enter license for car:";
            string requestToUser2 = "with type vehicle to enter (car/truck/motorcycle):";
            Func<string, string, string> addVehicleToGarageFunc = i_Garage.addVehicleToGarage;
            string attributesToEnter = (string)executeMethod(requestToUser1, requestToUser2, addVehicleToGarageFunc,
                out string licenseCar);

            if (attributesToEnter == "car already in garage, moved to status: in-progress")
            {
                Console.WriteLine(attributesToEnter);
                return;
            }

            // Send data basic about car to garage
            Action<string> setLastEnteredVehicle = i_Garage.setLastEnteredVehicle;
            executeMethod("enter name of owner:", setLastEnteredVehicle);
            executeMethod("enter phone number of owner:", setLastEnteredVehicle);
            executeMethod("enter the status you want for the car (INPROGRESS/FIXED/PAYED):", setLastEnteredVehicle);
            setLastEnteredVehicle(licenseCar);

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

                string parsedValue = parseAttribute(typeOfAttribute, inputAttribute); //TODO: exception generic 2
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
            string askForLicenseType = "what type of licenses(INPROGRESS,FIXED,PAYED,ANY):";
            Func<string, List<string>> showAllLicensesFunc = i_Garage.showAllLicenses;
            var allLicenses = executeMethod(askForLicenseType, showAllLicensesFunc);

            foreach (string i_licenses in (List<string>)allLicenses)
            {
                Console.WriteLine(i_licenses);
            }
        }

        //private static void showAllLicenses(Garage i_Garage)
        //{
        //    Console.WriteLine("what type of licenses(INPROGRESS,FIXED,PAYED,ANY): ");
        //    string typeOfLicenses = Console.ReadLine();
        //
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
            string requestToUser1 = "enter license of car to change status to:";
            string requestToUser2 = "enter new status:";
            Action<string, string> changeStatusToCarFunc = i_Garage.changeStatusToCar;
            executeMethod(requestToUser1, requestToUser2, changeStatusToCarFunc);
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
            i_Garage.addFuel(licenseCar, valueHowMuchFuel, typeOfFuel); //TODO: exception generic 3
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
            i_Garage.addElectricity(i_licenseCarToCharge, i_valueHowMuchElectricityToAdd);//TODO: exception generic 2

        }

        public static void showInformationAboutCar(Garage i_Garage)
        {
            string askForCarLicenseMessage = "enter license of car to show information about:";
            Func<string, string> showInformationAboutCarFunc = i_Garage.showInformationAboutCar;

            string informationAboutCar = (string)executeMethod(askForCarLicenseMessage, showInformationAboutCarFunc);
            Console.WriteLine(informationAboutCar);
        }

        private static object executeMethod(string i_RequestFromUser1, Delegate i_Function)
        {
            object returnValue = null;
            while (true)
            {
                Console.WriteLine(i_RequestFromUser1);
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

        private static object executeMethod(string i_RequestFromUser1, string i_RequestFromUser2, Delegate i_Function, 
            out string o_UserInput1, out string o_UserInput2)
        {
            object returnValue = null;
            while (true)
            {
                Console.WriteLine(i_RequestFromUser1);
                string userInput1 = Console.ReadLine();
                Console.WriteLine(i_RequestFromUser2);
                string userInput2 = Console.ReadLine();

                try
                {
                    if (i_Function is Func<string, string, object> nonVoidMethod)
                    {
                        returnValue = nonVoidMethod(userInput1, userInput2);
                    }
                    else if (i_Function is Action<string, string> voidMethod)
                    {
                        voidMethod(userInput1, userInput2);
                    }
                    o_UserInput1 = userInput1;
                    o_UserInput2 = userInput2;
                    break;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            return returnValue;
        }

        private static object executeMethod(string i_RequestFromUser1, string i_RequestFromUser2, Delegate i_Function, 
            out string o_UserInput1)
        {
            return executeMethod(i_RequestFromUser1, i_RequestFromUser2, i_Function, out o_UserInput1, out string dummy2);
        }

        private static object executeMethod(string i_RequestFromUser1, string i_RequestFromUser2, Delegate i_Function)
        {
            return executeMethod(i_RequestFromUser1, i_RequestFromUser2, i_Function, out string dummy1, out string dummy2);
        }

        //private static object executeMethod(Delegate i_Function, params string[] i_RequestsFromUser)
        //{
        //    object returnValue = null;
        //    string[] userInputs = new string[i_RequestsFromUser.Length];
        //    while (true)
        //    {
        //        for (int i = 0; i < i_RequestsFromUser.Length; i++)
        //        {
        //            Console.WriteLine(i_RequestsFromUser[i]);
        //            userInputs[i] = Console.ReadLine();
        //        }
        //
        //        try
        //        {
        //            if (getAmountOfInParamsInDelegate(i_Function) != i_RequestsFromUser.Length)
        //            {
        //                returnValue = nonVoidMethod(userInput);
        //            }
        //            else if (i_Function is Action<string> voidMethod)
        //            {
        //                voidMethod(userInput);
        //            }
        //
        //            break;
        //        }
        //        catch (Exception exception)
        //        {
        //            Console.WriteLine(exception.Message);
        //        }
        //
        //    }
        //}

        private static int getAmountOfInParamsInDelegate(Delegate i_delegate)
        {
            MethodInfo methodInfo = i_delegate.Method;
            ParameterInfo[] deletageParameters = methodInfo.GetParameters();
            return deletageParameters.Length;
        }

    }
}


