using System;
using System.Collections.Generic;
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
            string i_nameOfOwnerLastAddedCar;
            string i_phoneOfOwnerLastAddedCar;
            string i_carStatusLastAddedCar;
            //with type of attribute need to add now
            string i_withTypeOfAttribute;
            //message to print to user
            string i_messageWithAttributeToEnter;
            //input attribute
            string i_stringInputAttribute;
            int i_intInputAttribute;
            float i_floatInputAttribute;
            bool i_booleanInputAttribute = false;
            string i_withCarToEnter;
            string i_whatTypeOfLicensesToShow;
            List<String> allLicenses;
            string i_licenseCarToChangeStatus;
            string i_newDesireStatusCar;
            string i_licenseCarToAddPressure;
            string i_licenseCarToAddFuel;
            string i_howMuchFuelToAdd;
            float i_valueHowMuchFuelToAdd;
            string i_typeOfFuel;
            string i_licenseCarToCharge;
            string i_howMuchElectricityToAdd;
            float i_valueHowMuchElectricityToAdd;

            string typeOfFuel;





            while (i_userInput != "Q")
            {
                Console.WriteLine("enter: insert(insert new vehicle), show all licenses, change vehicle status, add air pressure, add fuel to car, charge electricity, show information car"); //TODO : fix message
                i_userInput = Console.ReadLine();
                switch(i_userInput)
                {
                    case ("insert"):
                        Console.WriteLine("enter license for car: ");
                        i_licenseCar = Console.ReadLine();
                        Console.WriteLine("with type vehicle to enter (car/truck/motorcycle): ");
                        i_withCarToEnter = Console.ReadLine();
                        i_attributesToEnter = i_garage.addVehicleToGarage(i_licenseCar, i_withCarToEnter);
                        if (i_attributesToEnter == "car already in garage, moved to status: in-progress")
                        {
                            Console.WriteLine(i_attributesToEnter);
                        }
                        else //if new car added to the garage
                        {
                            Console.WriteLine("enter name of owner: ");
                            i_nameOfOwnerLastAddedCar = Console.ReadLine();
                            Console.WriteLine("enter phone of owner: ");
                            i_phoneOfOwnerLastAddedCar = Console.ReadLine();
                            Console.WriteLine("enter the status you want for the car (INPROGRESS/FIXED/PAYED): ");
                            i_carStatusLastAddedCar = Console.ReadLine();
                            //send data basic about car to garage
                            i_garage.setLastEnteredVehicle(i_nameOfOwnerLastAddedCar);
                            i_garage.setLastEnteredVehicle(i_phoneOfOwnerLastAddedCar);
                            i_garage.setLastEnteredVehicle(i_carStatusLastAddedCar);
                            i_garage.setLastEnteredVehicle(i_licenseCar);


                            i_attributesToEnterArray = i_attributesToEnter.Split(new string[] { "||" }, StringSplitOptions.None);
                            foreach (string attribute in i_attributesToEnterArray)
                            {
                                i_messageWithAttributeToEnter = attribute.Split(new string[] { "::" }, StringSplitOptions.None)[0];
                                i_withTypeOfAttribute = attribute.Split(new string[] { "::" }, StringSplitOptions.None)[1];
                                Console.WriteLine(i_messageWithAttributeToEnter);
                                i_stringInputAttribute = Console.ReadLine();
                                switch (i_withTypeOfAttribute)
                                {
                                    case ("int"):
                                        if (!int.TryParse(i_stringInputAttribute, out i_intInputAttribute))
                                        {
                                            //TODO : exception cannot convert to int
                                        }
                                        i_garage.setLastEnteredVehicle(i_intInputAttribute);
                                        break;
                                    case ("float"):
                                        if (!float.TryParse(i_stringInputAttribute, out i_floatInputAttribute))
                                        {
                                            //TODO : exception cannot convert to int
                                        }
                                        i_garage.setLastEnteredVehicle(i_floatInputAttribute);
                                        break;
                                    case ("bool"):
                                        if (!bool.TryParse(i_stringInputAttribute, out i_booleanInputAttribute))
                                        {
                                            //TODO : exception cannot convert to boolean
                                        }
                                        i_garage.setLastEnteredVehicle(i_booleanInputAttribute);
                                        break;
                                    default: //needed to send string
                                        i_garage.setLastEnteredVehicle(i_stringInputAttribute);
                                        break;
                                }
                                if (i_messageWithAttributeToEnter == "is car on fuel" && i_booleanInputAttribute == true) //need to send type of fuel only for fuel engine
                                {
                                    Console.WriteLine("enter type of fuel for car: ");
                                    typeOfFuel = Console.ReadLine();
                                    i_garage.setLastEnteredVehicle(typeOfFuel);
                                }
                                

                            }
                        }
                        break;
                    case ("show all licenses"):
                        Console.WriteLine("what type of licenses(INPROGRESS,FIXED,PAYED,ANY): ");
                        i_whatTypeOfLicensesToShow = Console.ReadLine();
                        allLicenses = i_garage.showAllLicenses(i_whatTypeOfLicensesToShow); //TODO : need to handle exception
                        foreach (string i_licenses in allLicenses)
                        {
                            Console.WriteLine(i_licenses);
                        }
                        break;
                    case ("change vehicle status"): // i_newDesireStatusCar
                        Console.WriteLine("enter licenses of car to change status to: ");
                        i_licenseCarToChangeStatus = Console.ReadLine();
                        Console.WriteLine("enter new status: ");
                        i_newDesireStatusCar = Console.ReadLine();
                        i_garage.changeStatusToCar(i_licenseCarToChangeStatus, i_newDesireStatusCar); //TODO : need to handle exception
                        break;
                    case ("add air pressure"):
                        Console.WriteLine("enter licenses of car to add pressure to: ");
                        i_licenseCarToAddPressure = Console.ReadLine();
                        i_garage.FillFullAirPressureInWheels(i_licenseCarToAddPressure); //TODO : need to handle exception
                        break;
                    case ("add fuel to car"):
                        Console.WriteLine("enter licenses of car to add pressure to: ");
                        i_licenseCarToAddFuel = Console.ReadLine();
                        Console.WriteLine("enter how much fuel would you like to add: ");
                        i_howMuchFuelToAdd = Console.ReadLine();
                        float.TryParse(i_howMuchFuelToAdd, out i_valueHowMuchFuelToAdd); //TODO : need to put this lines in try
                        Console.WriteLine("enter what type of fuel do you want to use: ");
                        i_typeOfFuel = Console.ReadLine();
                        i_garage.addFuel(i_licenseCarToAddFuel, i_valueHowMuchFuelToAdd, i_typeOfFuel); //TODO : need to handle exception
                        break;
                    case ("charge electricity"):
                        Console.WriteLine("enter licenses of car to add pressure to: ");
                        i_licenseCarToCharge = Console.ReadLine();
                        Console.WriteLine("enter amount of hours to add to battery: ");
                        i_howMuchElectricityToAdd = Console.ReadLine();
                        float.TryParse(i_howMuchElectricityToAdd, out i_valueHowMuchElectricityToAdd); //TODO : need to put this lines in try
                        i_garage.addElectricity(i_licenseCarToCharge, i_valueHowMuchElectricityToAdd);
                        break;
                    case ("show information car"):
                        break;

                        
                }
                
            }

        }
    }
}
