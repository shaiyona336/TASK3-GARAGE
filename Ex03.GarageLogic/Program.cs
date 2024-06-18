using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
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
                    HandleUserInput(garage, userInput);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void HandleUserInput(Garage i_Garage, string i_UserInput)
        {
            switch (i_UserInput)
            {
                case "insert":
                    InsertVehicle(i_Garage);
                    break;
                case "show all licenses":
                    ShowAllLicenses(i_Garage);
                    break;
                case "change vehicle status":
                    ChangeVehicleStatus(i_Garage);
                    break;
                case "add air pressure":
                    AddAirPressure(i_Garage);
                    break;
                case "add fuel to car":
                    AddFuel(i_Garage);
                    break;
                case "charge electricity":
                    AddElectricity(i_Garage);
                    break;
                case "show information car":
                    ShowInformationAboutCar(i_Garage);
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }

        private static void InsertVehicle(Garage i_Garage)
        {
            string licenseCar;
            string withCarToEnter;
            string attributesToEnter;
            Action<string> setLastEnteredVehicle = i_Garage.SetLastEnteredVehicle;
            Func<string, string> addVehicleToGarageFunc = i_Garage.AddVehicle;

            Console.WriteLine("enter license for car: ");
            licenseCar = Console.ReadLine();

            if (i_Garage.IsCarInGarage(licenseCar))
            {
                Console.WriteLine("car already in garage, moved to status INPROGRESS");
            }
            else
            {
                attributesToEnter = (string)ExecuteMethod("with type vehicle to enter (car/truck/motorcycle): ", addVehicleToGarageFunc);
                ExecuteMethod("enter name of owner:", setLastEnteredVehicle);
                ExecuteMethod("enter phone number of owner:", setLastEnteredVehicle);
                ExecuteMethod("enter the status you want for the car (INPROGRESS/FIXED/PAYED):", setLastEnteredVehicle);
                setLastEnteredVehicle(licenseCar);

                ProcessVehicleAttributes(i_Garage, attributesToEnter);
            }
        }

        private static void ProcessVehicleAttributes(Garage i_Garage, string i_AttributesToEnter)
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
                        }
                        i_Garage.SetLastEnteredVehicle(intInputAttribute);
                        break;
                    case "float":
                        if (!float.TryParse(inputAttribute, out float floatInputAttribute))
                        {
                            throw new FormatException("Cannot convert to float");
                        }
                        i_Garage.SetLastEnteredVehicle(floatInputAttribute);
                        break;
                    case "bool":
                        if (!bool.TryParse(inputAttribute, out bool boolInputAttribute))
                        {
                            throw new FormatException("Cannot convert to bool");
                        }
                        i_Garage.SetLastEnteredVehicle(boolInputAttribute);
                        break;
                    default:
                        i_Garage.SetLastEnteredVehicle(inputAttribute);
                        break;
                }

                if (messageWithAttributeToEnter == "is car on fuel" && bool.Parse(inputAttribute))
                {
                    ExecuteMethod("enter type of fuel for car:", (Action<string>)i_Garage.SetLastEnteredVehicle);
                }
            }
        }

        private static void ShowAllLicenses(Garage i_Garage)
        {
            string askForLicenseType = "what type of licenses(INPROGRESS,FIXED,PAYED,ANY):";
            Func<string, List<string>> showAllLicensesFunc = i_Garage.ShowAllLicenses;
            var allLicenses = ExecuteMethod(askForLicenseType, showAllLicensesFunc);

            foreach (string i_Licenses in (List<string>)allLicenses)
            {
                Console.WriteLine(i_Licenses);
            }
        }

        private static void ChangeVehicleStatus(Garage i_Garage)
        {
            string requestToUser1 = "enter license of car to change status to:";
            string requestToUser2 = "enter new status:";
            Action<string, string> changeStatusToCarFunc = i_Garage.ChangeStatusToCar;
            ExecuteMethod(requestToUser1, requestToUser2, changeStatusToCarFunc);
        }

        private static void AddAirPressure(Garage i_Garage)
        {
            ExecuteMethod("enter license of car to add pressure to:", (Action<string>)i_Garage.FillFullAirPressureInWheels);
        }

        private static void AddFuel(Garage i_Garage)
        {
        methodStart:
            Console.WriteLine("enter license of car to add fuel to: ");
            string licenseCar = Console.ReadLine();

            Console.WriteLine("enter how much fuel would you like to add: ");
            string howMuchFuel = Console.ReadLine();
            float valueHowMuchFuel = float.Parse(howMuchFuel);

            Console.WriteLine("enter what type of fuel do you want to use: ");
            string typeOfFuel = Console.ReadLine();

            try
            {
                i_Garage.AddFuel(licenseCar, valueHowMuchFuel, typeOfFuel);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                goto methodStart;
            }
        }

        public static void AddElectricity(Garage i_Garage)
        {
        methodStart:
            string licenseCarToCharge;
            string howMuchElectricityToAdd;

            Console.WriteLine("enter licenses of car to add pressure to: ");
            licenseCarToCharge = Console.ReadLine();
            Console.WriteLine("enter amount of hours to add to battery: ");
            howMuchElectricityToAdd = Console.ReadLine();
            float i_ValueHowMuchElectricityToAdd = float.Parse(howMuchElectricityToAdd);

            try
            {
                i_Garage.AddElectricity(licenseCarToCharge, i_ValueHowMuchElectricityToAdd);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                goto methodStart;
            }
        }

        public static void ShowInformationAboutCar(Garage i_Garage)
        {
            string askForCarLicenseMessage = "enter license of car to show information about:";
            Func<string, string> showInformationAboutCarFunc = i_Garage.ShowInformationAboutCar;

            string informationAboutCar = (string)ExecuteMethod(askForCarLicenseMessage, showInformationAboutCarFunc);
            Console.WriteLine(informationAboutCar);
        }

        private static object ExecuteMethod(string i_RequestFromUser1, Delegate i_Function)
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

        private static object ExecuteMethod(string i_RequestFromUser1, string i_RequestFromUser2, Delegate i_Function,
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

        private static object ExecuteMethod(string i_RequestFromUser1, string i_RequestFromUser2, Delegate i_Function,
            out string o_UserInput1)
        {
            return ExecuteMethod(i_RequestFromUser1, i_RequestFromUser2, i_Function, out o_UserInput1, out string dummy2);
        }

        private static object ExecuteMethod(string i_RequestFromUser1, string i_RequestFromUser2, Delegate i_Function)
        {
            return ExecuteMethod(i_RequestFromUser1, i_RequestFromUser2, i_Function, out string dummy1, out string dummy2);
        }

        private static int GetAmountOfInParamsInDelegate(Delegate i_Delegate)
        {
            MethodInfo methodInfo = i_Delegate.Method;
            ParameterInfo[] delegateParameters = methodInfo.GetParameters();
            return delegateParameters.Length;
        }
    }
}
