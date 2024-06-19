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
            return m_Engine.IsElectricity();
        }

        public override bool IsFuel()
        {
            return m_Engine.IsFuel();
        }

        public override void AddFuelOrElectricity(float i_HowMuchFuelToAdd, string i_TypeOfEnergy)
        {
            m_Engine.AddEnergy(i_HowMuchFuelToAdd, i_TypeOfEnergy);
        }

        private eColorsOfCars stringColorToEnum(string i_Color)
        {
            eColorsOfCars colorToReturn;
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
                    throw new ArgumentException($"\"{i_Color}\" is not a valid color");
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
            return "Enter model name::string" +
                $"||Enter air pressure in wheels (maximum is {k_MaximumAirPressure})::float" +
                "||Enter the manufactor name of the car's wheels::string" +
                "||Enter the color of the car (yellow/white/red/black)::string" +
                "||Enter the number of doors in the car::int" +
                "||Is the car on fuel? (true/false)::bool" +
                $"||If the car runs of fuel, enter the amount of fuel it has (maximum is {k_MaximumAmountOfFuel})\n" +
                $"If it runs on electricity, enter the amount of time it has left (maximum is {k_MaximumAmountOfElectricity})::float";
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
                    m_Color = stringColorToEnum(i_StringAttribute);
                    break;
                default:
                    throw new ArgumentException("SENT WRONG ATTRIBUTE");
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
                throw new ArgumentException("SENT WRONG ATTRIBUTE");
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(float i_FloatAttribute)
        {
            if (m_IndexSetupAttribute == 1)
            {
                AddWheelsPressure(i_FloatAttribute);
            }
            else if (m_IndexSetupAttribute == 6)
            {
                m_Engine.SetEnergy(i_FloatAttribute);             
            }
            else
            {
                throw new ArgumentException("SENT WRONG ATTRIBUTE");
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(bool i_BoolAttribute)
        {
            if (m_IndexSetupAttribute == 5)
            {
                m_Engine = Engine.SetEngineByBool(i_BoolAttribute);
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
                throw new ArgumentException("SENT WRONG ATTRIBUTE");
            }
            m_IndexSetupAttribute++;
        }
    }
}
