using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    sealed class FuelEngine : Engine
    {
        enum typeOfFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,

        }
        private typeOfFuel typeFuel = typeOfFuel.Soler;
        private float statusFuel;
        private float maximumFuel;


        public override float getEnergy()
        {
            return statusFuel;
        }


        public void addFuel(int howMuchFuelToAdd, string typeOfFuelFunctionMethodRequestToAdd)
        {
            typeOfFuel typeOfFuelCorrectFormat = typeOfFuel.Soler;

            switch (typeOfFuelFunctionMethodRequestToAdd)
            {
                case ("Soler"):
                    typeOfFuelCorrectFormat = typeOfFuel.Soler;
                    break;
                case ("Octan95"):
                    typeOfFuelCorrectFormat = typeOfFuel.Octan95;
                    break;
                case ("Octan96"):
                    typeOfFuelCorrectFormat = typeOfFuel.Octan96;
                    break;
                case ("Octan98"):
                    typeOfFuelCorrectFormat = typeOfFuel.Octan98;
                    break;
                default:
                    //TODO: throw exception invalid fuel
                    break;
            }
            if (typeOfFuelCorrectFormat == typeFuel)
            {
                statusFuel = WorkOnCar.addResourceToResource(statusFuel, howMuchFuelToAdd);
            }
            //TODO: wrong fuel type tried to be added
        }
    }
}

