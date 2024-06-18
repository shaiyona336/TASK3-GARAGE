using System;

namespace Ex03.GarageLogic
{
    sealed class FuelEngine : Engine
    {
        public enum eTypeOfFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,
        }
        private eTypeOfFuel m_TypeFuel = eTypeOfFuel.Soler;
        private float m_StatusFuel;
        private float m_MaximumFuel;

        public override float GetMaximumEnergy()
        {
            return m_MaximumFuel;
        }
        public string GetTypeOfFuel()
        {
            string typeOfFuel = "";

            switch (m_TypeFuel)
            {
                case eTypeOfFuel.Soler:
                    typeOfFuel = "Soler";
                    break;
                case eTypeOfFuel.Octan95:
                    typeOfFuel = "Octan95";
                    break;
                case eTypeOfFuel.Octan96:
                    typeOfFuel = "Octan96";
                    break;
                case eTypeOfFuel.Octan98:
                    typeOfFuel = "Octan98";
                    break;
                default:
                    throw new ArgumentException($"{typeOfFuel} is not a valid fuel type", nameof(typeOfFuel));
            }
            return typeOfFuel;
        }

        public override float GetEnergy()
        {
            return m_StatusFuel;
        }

        public void SetTypeOfFuel(string i_TypeOfFuel)
        {
            eTypeOfFuel typeOfFuelRightFormat = eTypeOfFuel.Soler;

            switch (i_TypeOfFuel)
            {
                case "Soler":
                    typeOfFuelRightFormat = eTypeOfFuel.Soler;
                    break;
                case "Octan95":
                    typeOfFuelRightFormat = eTypeOfFuel.Octan95;
                    break;
                case "Octan96":
                    typeOfFuelRightFormat = eTypeOfFuel.Octan96;
                    break;
                case "Octan98":
                    typeOfFuelRightFormat = eTypeOfFuel.Octan98;
                    break;
                default:
                    //TODO : wrong type of fuel
                    break;
            }

            m_TypeFuel = typeOfFuelRightFormat;
        }

        public override void AddEnergy(float i_HowMuchFuelToAdd, string i_TypeOfEnergy)
        {
            eTypeOfFuel typeOfFuelCorrectFormat = eTypeOfFuel.Soler;

            switch (i_TypeOfEnergy)
            {
                case "Soler":
                    typeOfFuelCorrectFormat = eTypeOfFuel.Soler;
                    break;
                case "Octan95":
                    typeOfFuelCorrectFormat = eTypeOfFuel.Octan95;
                    break;
                case "Octan96":
                    typeOfFuelCorrectFormat = eTypeOfFuel.Octan96;
                    break;
                case "Octan98":
                    typeOfFuelCorrectFormat = eTypeOfFuel.Octan98;
                    break;
                default:
                    //TODO: throw exception invalid fuel
                    break;
            }
            if (typeOfFuelCorrectFormat == m_TypeFuel)
            {
                WorkOnCar.AddResourceToResource(ref m_StatusFuel, i_HowMuchFuelToAdd, m_MaximumFuel);
            }
            //TODO: wrong fuel type tried to be added
        }

        public override void SetMaximumEnergy(float i_MaximumEnergy)
        {
            m_MaximumFuel = i_MaximumEnergy;
        }

    }
}
