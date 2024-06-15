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
            bool i_booleanInputAttribute;
            string i_withCarToEnter;

            while (i_userInput != "Q")
            {
                Console.WriteLine("enter: insert(insert new car), "); //TODO : fix message
                i_userInput = Console.ReadLine();
                switch(i_userInput)
                {
                    case ("insert"):
                        Console.WriteLine("enter license for car: ");
                        i_licenseCar = Console.ReadLine();
                        Console.WriteLine("with car to enter: ");
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

                            }
                        }
                        break;
                }
                
            }

        }
    }
}
