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
        private typeOfFuel m_typeFuel = typeOfFuel.Soler;
        private float m_statusFuel;
        private float m_maximumFuel;


        public override float getEnergy()
        {
            return m_statusFuel;
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
            if (typeOfFuelCorrectFormat == m_typeFuel)
            {
                m_statusFuel = WorkOnCar.addResourceToResource(m_statusFuel, howMuchFuelToAdd, m_maximumFuel);
            }
            //TODO: wrong fuel type tried to be added
        }

        public override void setMaximumEnergy(float i_maximumEnergy)
        {
            m_maximumFuel = i_maximumEnergy;
        }

    }
}

