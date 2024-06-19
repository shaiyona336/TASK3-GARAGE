using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
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
                    printAllLicensesInGarage(i_Garage);
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
            string vehicleLicense;
            string vehicleTypeToEnterGarage;
            string attributesToEnter;
            Action<string> setLastEnteredVehicle = i_Garage.SetLastEnteredVehicle;
            Func<string, string> addVehicleToGarageFunc = i_Garage.AddVehicle;


            Console.WriteLine("enter license for the vehicle: ");
            vehicleLicense = Console.ReadLine();

            if (i_Garage.IsCarInGarage(vehicleLicense))
            {
                Console.WriteLine("car already in garage, moved to status INPROGRESS");
            }
            else
            {
                attributesToEnter = (string)askForInputAndHandleExceptions("What's the type" +
                    " of the vehicle you want to enter the garage? (car/truck/motorcycle): ",
                    addVehicleToGarageFunc);

                askForInputAndHandleExceptions("Enter name of owner:", setLastEnteredVehicle);
                askForInputAndHandleExceptions("Enter phone number of owner:", setLastEnteredVehicle);
                setLastEnteredVehicle(vehicleLicense);

                processVehicleAttributes(i_Garage, attributesToEnter);
            }
            //addVehicle

        }
   
        private static void processVehicleAttributes(Garage i_Garage, string i_AttributesToEnter)
        {
            Action<string> SetLastEnteredVehicle = i_Garage.SetLastEnteredVehicle;

            string[] attributesArray = i_AttributesToEnter.Split(new string[] { "||" }, 
                StringSplitOptions.None);

            foreach (string attribute in attributesArray)
            {
                string messageWithAttributeToEnter = attribute.Split(new string[] { "::" },
                    StringSplitOptions.None)[0];
                string typeOfAttribute = attribute.Split(new string[] { "::" },
                    StringSplitOptions.None)[1];

             askForInputWithTypeAndHandleExceptions(messageWithAttributeToEnter, typeOfAttribute, i_Garage, SetLastEnteredVehicle);
             
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
                throw new ArgumentException($"Unsupported attribute type: {i_TypeOfAttribute}", i_TypeOfAttribute);
            }

            return parsers[i_TypeOfAttribute](i_InputAttribute);
        }

        private static void printAllLicensesInGarage(Garage i_Garage)
        {
            string askForLicenseType = "what type of licenses(INPROGRESS,FIXED,PAYED,ANY):";
            Func<string, List<string>> showAllLicensesFunc = i_Garage.ShowAllLicenses;
            var allLicenses = askForInputAndHandleExceptions(askForLicenseType, showAllLicensesFunc);

            foreach (string license in (List<string>)allLicenses)
            {
                Console.WriteLine(license);
            }
        }

        private static void changeVehicleStatus(Garage i_Garage)
        {
            string requestToUser1 = "enter license of car to change status to:";
            string requestToUser2 = "enter new status:";
            Action<string, string> changeStatusToCarFunc = i_Garage.ChangeStatusToCar;
            executeMethod(requestToUser1, requestToUser2, changeStatusToCarFunc);
        }

        private static void addAirPressure(Garage i_Garage)
        {
            askForInputAndHandleExceptions("enter license of car to add pressure to:",
                (Action<string>)i_Garage.FillFullAirPressureInWheels);
        }

        private static void addFuel(Garage i_Garage)
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

        public static void addElectricity(Garage i_Garage)
        {
        methodStart:
            string licenseCarToCharge;
            string howMuchElectricityToAdd;

            Console.WriteLine("enter licenses of car to add pressure to: ");
            licenseCarToCharge = Console.ReadLine();
            Console.WriteLine("enter amount of hours to add to battery: ");
            howMuchElectricityToAdd = Console.ReadLine();
            float valueHowMuchElectricityToAdd = float.Parse(howMuchElectricityToAdd);

            try
            {
                i_Garage.AddElectricity(licenseCarToCharge, valueHowMuchElectricityToAdd);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                goto methodStart;
            }
        }

        public static void showInformationAboutCar(Garage i_Garage)
        {
            string askForCarLicenseMessage = "enter license of car to show information about:";
            Func<string, string> showInformationAboutCarFunc = i_Garage.ShowInformationAboutCar;

            string informationAboutCar = (string)askForInputAndHandleExceptions(askForCarLicenseMessage, showInformationAboutCarFunc);
            Console.WriteLine(informationAboutCar);
        }


        private static void askForInputWithTypeAndHandleExceptions(string i_RequestFromUser1, 
            string i_TypeArgumentSendFunction, Garage i_Garage, Delegate i_Function)
        {
            //object returnValue = null;
            bool flag = true;
            string i_typeOfFuel;
            string i_inputAttribute;


            while (flag)
            {
                Console.WriteLine(i_RequestFromUser1);
                i_inputAttribute = Console.ReadLine();
                try
                {
                    switch (i_TypeArgumentSendFunction)
                    {
                        case "int":
                            if (!int.TryParse(i_inputAttribute, out int intInputAttribute))
                            {
                                Console.WriteLine("Cannot convert to int");
                                break;
                            }

                            i_Garage.SetLastEnteredVehicle(intInputAttribute);
                            flag = false;
                            break;
                        case "float":
                            if (!float.TryParse(i_inputAttribute, out float floatInputAttribute))
                            {
                                throw new FormatException("Cannot convert to float");
                            }
                            i_Garage.SetLastEnteredVehicle(floatInputAttribute);
                            flag = false;
                            break;
                        case "bool":
                            if (!bool.TryParse(i_inputAttribute, out bool boolInputAttribute))
                            {
                                throw new FormatException("Cannot convert to bool");
                            }
                            i_Garage.SetLastEnteredVehicle(boolInputAttribute);
                            flag = false;
                            break;
                        default: // Needed to send string
                            i_Garage.SetLastEnteredVehicle(i_inputAttribute);
                            flag = false;
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                } 
            }
        }

        private static object askForInputAndHandleExceptions(string i_RequestFromUser1, Delegate i_Function)
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

        private static int getAmountOfInParamsInDelegate(Delegate i_delegate)
        {
            MethodInfo methodInfo = i_delegate.Method;
            ParameterInfo[] deletageParameters = methodInfo.GetParameters();
            return deletageParameters.Length;
        }

    }
}