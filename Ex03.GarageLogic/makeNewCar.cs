using System;


namespace Ex03.GarageLogic
{
    internal class makeNewCar
    {
        public static Vehicle getVehicleFromString(string i_withCar)
        {
            Vehicle i_newCar = null;

            switch (i_withCar)
            {
                case ("car"):
                    i_newCar = new Car();
                    break;
                case ("truck"):
                    i_newCar = new Truck();
                    break;
                case ("Motorcycle"):
                    i_newCar = new MotorCycle();
                    break;
                default:
                    throw new ArgumentException($"There's no type of vehicle that matches with \"{i_withCar}\"");
                    
            }
            return i_newCar;
        }
    }
}
