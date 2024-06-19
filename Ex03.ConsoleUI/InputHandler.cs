using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    internal class InputHandler
    {
        public static void HandleUserInput(Garage i_Garage, int i_UserInput)
        {
            switch (i_UserInput)
            {
                case 1:
                    insertVehicle(i_Garage);
                    Console.WriteLine("The requested vehicle has entered the garage.");
                    break;
                case 2:
                    printAllLicensesInGarage(i_Garage);
                    break;
                case 3:
                    changeVehicleStatus(i_Garage);
                    Console.WriteLine("Vehicle status changed");
                    break;
                case 4:
                    addAirPressure(i_Garage);
                    Console.WriteLine("Air pressure was added to the requested vehicle.");
                    break;
                case 5:
                    addFuel(i_Garage);
                    Console.WriteLine("More fuel was added to the requested vehicle.");
                    break;
                case 6:
                    addElectricity(i_Garage);
                    Console.WriteLine("The electric vehicle was charged.");
                    break;
                case 7:
                    showInformationAboutCar(i_Garage);
                    break;
                case 8:
                    break;
                default:
                    throw new ValueOutOfRangeException(1, 8);
            }
        }

        public static void PrintProgramOptions()
        {
            Console.WriteLine("Enter one of the options below:");
            Console.WriteLine("1. Insert a new vehicle into the garage");
            Console.WriteLine("2. Show all the licenses in the garage");
            Console.WriteLine("3. Change a vehicle's status");
            Console.WriteLine("4. Add air pressure to vehicle");
            Console.WriteLine("5. Add fuel to vehicle");
            Console.WriteLine("6. Charge electric vehicle");
            Console.WriteLine("7. Show information about vehicle");
            Console.WriteLine("8. Quit the program");
        }

        private static void insertVehicle(Garage i_Garage)
        {
            string vehicleLicense;
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
        }

        private static void processVehicleAttributes(Garage i_Garage, string i_AttributesToEnter)
        {
            string[] attributesArray = i_AttributesToEnter.Split(new string[] { "||" },
                StringSplitOptions.None);

            foreach (string attribute in attributesArray)
            {
                string messageWithAttributeToEnter = attribute.Split(new string[] { "::" },
                    StringSplitOptions.None)[0];
                string typeOfAttribute = attribute.Split(new string[] { "::" },
                    StringSplitOptions.None)[1];

                askForInputWithTypeAndSetVehicle(messageWithAttributeToEnter, typeOfAttribute, i_Garage);
            }
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

        private static void addElectricity(Garage i_Garage)
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

        private static void showInformationAboutCar(Garage i_Garage)
        {
            string askForCarLicenseMessage = "enter license of car to show information about:";
            Func<string, string> showInformationAboutCarFunc = i_Garage.ShowInformationAboutCar;

            string informationAboutCar = (string)askForInputAndHandleExceptions(askForCarLicenseMessage, showInformationAboutCarFunc);
            Console.WriteLine(informationAboutCar);
        }

        private static void askForInputWithTypeAndSetVehicle(string i_RequestFromUser1,
            string i_TypeArgumentSendFunction, Garage i_Garage)
        {
            //object returnValue = null;
            bool flag = true;
            string inputAttribute;

            while (flag)
            {
                Console.WriteLine(i_RequestFromUser1);
                inputAttribute = Console.ReadLine();
                try
                {
                    switch (i_TypeArgumentSendFunction)
                    {
                        case "int":
                            if (!int.TryParse(inputAttribute, out int intInputAttribute))
                            {
                                Console.WriteLine("Cannot convert to int");
                                break;
                            }

                            i_Garage.SetLastEnteredVehicle(intInputAttribute);
                            flag = false;
                            break;
                        case "float":
                            if (!float.TryParse(inputAttribute, out float floatInputAttribute))
                            {
                                throw new FormatException("Cannot convert to float");
                            }
                            i_Garage.SetLastEnteredVehicle(floatInputAttribute);
                            flag = false;
                            break;
                        case "bool":
                            if (!bool.TryParse(inputAttribute, out bool boolInputAttribute))
                            {
                                throw new FormatException("Cannot convert to bool");
                            }
                            i_Garage.SetLastEnteredVehicle(boolInputAttribute);
                            flag = false;
                            break;
                        default: // Needed to send string
                            i_Garage.SetLastEnteredVehicle(inputAttribute);
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

    }
}

