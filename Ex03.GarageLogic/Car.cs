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
        private const int k_MaximumAirPressure = 31;
        private const string k_FuelType = "Octan95";
        private const float k_MaximumAmountOfFuel = 45;
        private const float k_MaximumAmountOfElectricity = 3.5f;
        private const int k_NumberOfWheels = 5;

        private eColorsOfCars m_Color;
        private int m_NumberOfDoors;
        private Engine m_Engine = new FuelEngine();
        private int m_IndexSetupAttribute = 0; //with attribute by the order of get attributes does the function need now to set

        public Car()
        {
            InitializeWheels(k_NumberOfWheels);
            SetInitialWheelsPressure(k_MaximumAirPressure);
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
                default:
                    throw new ArgumentException($"\"{i_Color}\" is not a valid color", nameof(i_Color));
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
            return ("model name::string||air pressure in wheels::float||manufactor name of wheels::string||color (yellow/white/red/black)::string||number of doors::int||is car on fuel (true/false)::bool");
        }

        public override void SetCarInitialState(string i_StringAttribute)
        {
            switch (m_IndexSetupAttribute)
            {
                case (0):
                    this.SetModelName(i_StringAttribute);
                    break;
                case (2):
                    SetWheelsManufactorName(i_StringAttribute);
                    break;
                case (3):
                    m_Color = StringColorToEnum(i_StringAttribute);
                    break;
                case (6):
                    (m_Engine as FuelEngine).SetTypeOfFuel(k_FuelType);
                    break;
                default:
                    //TODO : SENT WRONG ATTRIBUTE
                    break;
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(int i_IntAttribute)
        {
            if (m_IndexSetupAttribute == 4)
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
            else if (m_IndexSetupAttribute == 1)
            {
                AddWheelsPressure(i_FloatAttribute);
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(bool i_BoolAttribute)
        {
            if (m_IndexSetupAttribute == 5)
            {
                m_Engine = WorkOnCar.SetEngineByBool(i_BoolAttribute);
                if (m_Engine is FuelEngine)
                {
                    m_Engine.SetMaximumEnergy(k_MaximumAmountOfFuel);
                    (m_Engine as FuelEngine).SetTypeOfFuel(k_FuelType);
                }
                else if (m_Engine is ElectricEngine)
                {
                    m_Engine.SetMaximumEnergy(k_MaximumAmountOfElectricity);
                }
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_IndexSetupAttribute++;
        }
    }
}
