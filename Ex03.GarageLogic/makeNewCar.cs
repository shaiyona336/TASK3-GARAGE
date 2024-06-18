using System;

namespace Ex03.GarageLogic
{
    internal class MakeNewCar
    {
        public static Vehicle GetVehicleFromString(string i_VehicleType)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case "car":
                    newVehicle = new Car();
                    break;
                case "truck":
                    newVehicle = new Truck();
                    break;
                case "motorcycle":
                    newVehicle = new Motorcycle();
                    break;
                default:
                    throw new ArgumentException($"There's no type of vehicle that matches with \"{i_VehicleType}\"", nameof(i_VehicleType));
            }
            return newVehicle;
        }
    }
}
