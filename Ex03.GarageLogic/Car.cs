using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    sealed class Car : Vehicle
    {
        enum eColorsOfCars
        {
            Yellow,
            White,
            Red,
            Black,
        }
        private eColorsOfCars m_Color;
        private int m_NumberOfDoors;
        private Engine m_Engine = new FuelEngine();
        private int m_IndexSetupAttribute = 0; //with attribute by the order of get attributes does the function need now to set
        private const int k_NumberOfWheels = 4;

        public Car()
        {
            InitializeWheels(k_NumberOfWheels);
        }

        public override float GetEnergy()
        {
            return m_Engine.GetEnergy();
        }

        public override bool IsElectricity()
        {
            return WorkOnCar.IsElectricity(m_Engine);
        }

        public override bool IsFuel()
        {
            return WorkOnCar.IsFuel(m_Engine);
        }

        public override void AddFuelOrElectricity(float i_HowMuchFuelToAdd, string i_TypeOfEnergy)
        {
            m_Engine.AddEnergy(i_HowMuchFuelToAdd, i_TypeOfEnergy);
        }

        private eColorsOfCars StringColorToEnum(string i_Color)
        {
            eColorsOfCars colorToReturn = eColorsOfCars.Black;
            switch (i_Color)
            {
                case ("yellow"):
                    colorToReturn = eColorsOfCars.Yellow;
                    break;
                case ("white"):
                    colorToReturn = eColorsOfCars.White;
                    break;
                case ("red"):
                    colorToReturn = eColorsOfCars.Red;
                    break;
                case ("black"):
                    colorToReturn = eColorsOfCars.Black;
                    break;
                default: //TODO: EXCEPTION NO SUCH COLOR
                    break;
            }
            return colorToReturn;
        }

        public override string GetInformationAboutCar()
        {
            string informationAboutCar;

            if (m_Engine is FuelEngine)
            {
                informationAboutCar = String.Format("model name: {0}\n" +
                    "air pressure in wheels: {1}\n" +
                    "maximum air pressure in wheels: {2}\n" +
                    "manufactor name of wheels: {3}\n" +
                    "color: {4}\n" +
                    "number of doors: {5}\n" +
                    "how much fuel: {6}\n" +
                    "type of fuel: {7}\n" +
                    "maximum amount of fuel: {8}\n", GetModelName(), GetAirPressureInWheels(), GetMaximumAirPressureInWheels(), GetWheeslManufactorName(), m_Color, m_NumberOfDoors, m_Engine.GetEnergy(), (m_Engine as FuelEngine).GetTypeOfFuel(), m_Engine.GetMaximumEnergy());
            }
            else //car on electric engine
            {
                informationAboutCar = String.Format("model name: {0}\n" +
                    "air pressure in wheels: {1}\n" +
                    "maximum air pressure in wheels: {2}\n" +
                    "manufactor name of wheels: {3}\n" +
                    "color: {4}\n" +
                    "number of doors: {5}\n" +
                    "how much hours for battery: {6}\n" +
                    "maximum amount of hours for battery: {7}\n", GetModelName(), GetAirPressureInWheels(), GetMaximumAirPressureInWheels(), GetWheeslManufactorName(), m_Color, m_NumberOfDoors, m_Engine.GetEnergy(), m_Engine.GetMaximumEnergy());
            }

            return informationAboutCar;
        }

        public override string GetAttributes()
        {
            m_IndexSetupAttribute = 0;
            return ("model name::string||maximum air pressure wheels::float||air pressure in wheels::float||manufactor name of wheels::string||color(yellow,white,red,black)::string||number of doors::int||is car on fuel::bool||maximum energy::float");
        }

        public override void SetCarInitialState(string i_StringAttribute)
        {
            switch (m_IndexSetupAttribute)
            {
                case (0):
                    this.SetModelName(i_StringAttribute);
                    break;
                case (3):
                    SetWheelsManufactorName(i_StringAttribute);
                    break;
                case (4):
                    m_Color = StringColorToEnum(i_StringAttribute);
                    break;
                case (7):
                    (m_Engine as FuelEngine).SetTypeOfFuel(i_StringAttribute);
                    break;
                default:
                    //TODO : SENT WRONG ATTRIBUTE
                    break;
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(int i_IntAttribute)
        {
            if (m_IndexSetupAttribute == 5)
            {
                m_NumberOfDoors = i_IntAttribute;
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(float i_FloatAttribute)
        {
            if (m_Engine != null && m_Engine is ElectricEngine) //electric engine do not need to get type of fuel, so the index of set maximum energy is one less and need to add one
            {
                m_IndexSetupAttribute++;
            }
            if (m_IndexSetupAttribute == 1)
            {
                SetInitialWheelsPressure(i_FloatAttribute);
            }
            else if (m_IndexSetupAttribute == 2)
            {
                AddWheelsPressure(i_FloatAttribute);
            }
            else if (m_IndexSetupAttribute == 8)
            {
                m_Engine.SetMaximumEnergy(i_FloatAttribute);
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(bool i_BoolAttribute)
        {
            if (m_IndexSetupAttribute == 6)
            {
                m_Engine = WorkOnCar.SetEngineByBool(i_BoolAttribute);
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_IndexSetupAttribute++;
        }
    }
}
