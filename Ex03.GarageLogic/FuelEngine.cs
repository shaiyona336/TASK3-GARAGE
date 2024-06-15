using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    sealed class FuelEngine : Engine
    {
        public enum typeOfFuel
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

        public void setTypeOfFuel(string i_typeOfFuel)
        {
            typeOfFuel typeOfFuelRightFormat = typeOfFuel.Soler;
            
            switch(i_typeOfFuel)
            {
                case ("Soler"):
                    typeOfFuelRightFormat = typeOfFuel.Soler; 
                    break;
                case ("Octan95"):
                    typeOfFuelRightFormat = typeOfFuel.Octan95;
                    break;
                case ("Octan96"):
                    typeOfFuelRightFormat = typeOfFuel.Octan96;
                    break;
                case ("Octan98"):
                    typeOfFuelRightFormat = typeOfFuel.Octan98;
                    break;
                default:
                    //TODO : wrong type of fuel
                    break;
            }

            m_typeFuel = typeOfFuelRightFormat;
        }


        public override void addEnergy(float howMuchFuelToAdd, string typeOfEnergy)
        {
            typeOfFuel typeOfFuelCorrectFormat = typeOfFuel.Soler;

            switch (typeOfEnergy)
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
                WorkOnCar.addResourceToResource(ref m_statusFuel, howMuchFuelToAdd, m_maximumFuel);
            }
            //TODO: wrong fuel type tried to be added
        }

        public override void setMaximumEnergy(float i_maximumEnergy)
        {
            m_maximumFuel = i_maximumEnergy;
        }

    }
}

