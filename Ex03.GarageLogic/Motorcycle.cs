using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    sealed class Motorcycle : Vehicle
    {
        enum eTypeOfLicense
        {
            A,
            A1,
            AA,
            B1,
        }

        private const int k_MaximumAirPressure = 33;
        private const string k_FuelType = "Octan98";
        private const float k_MaximumAmountOfFuel = 5.5f;
        private const float k_MaximumAmountOfElectricity = 2.5f;
        private const int k_NumberOfWheels = 2;

        private eTypeOfLicense m_TypeLicense;
        private int m_EngineVolume;
        private Engine m_Engine = new FuelEngine();
        private int m_IndexSetupAttribute = 0;

        public Motorcycle()
        {
            InitializeWheels(k_NumberOfWheels);
            SetInitialWheelsPressure(k_MaximumAirPressure);
        }

        private string GetTypeOfLicense()
        {
            string typeOfLicense = "";

            switch (m_TypeLicense)
            {
                case eTypeOfLicense.A:
                    typeOfLicense = "A";
                    break;
                case eTypeOfLicense.A1:
                    typeOfLicense = "A1";
                    break;
                case eTypeOfLicense.AA:
                    typeOfLicense = "AA";
                    break;
                case eTypeOfLicense.B1:
                    typeOfLicense = "B1";
                    break;
                default:
                    break;
            }
            return typeOfLicense;
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
                    "type of license: {4}\n" +
                    "cargo volume: {5}\n" +
                    "how much fuel: {6}\n" +
                    "type of fuel: {7}\n" +
                    "maximum amount of fuel: {8}\n", GetModelName(), GetAirPressureInWheels(), GetMaximumAirPressureInWheels(), GetWheeslManufactorName(), GetTypeOfLicense(), m_EngineVolume, m_Engine.GetEnergy(), (m_Engine as FuelEngine).GetTypeOfFuel(), m_Engine.GetMaximumEnergy());
            }
            else //car on electric engine
            {
                informationAboutCar = String.Format("model name: {0}\n" +
                    "air pressure in wheels: {1}\n" +
                    "maximum air pressure in wheels: {2}\n" +
                    "manufactor name of wheels: {3}\n" +
                    "type of license: {4}\n" +
                    "cargo volume: {5}\n" +
                    "how much hours for battery: {6}\n" +
                    "maximum amount of hours for battery: {7}\n", GetModelName(), GetAirPressureInWheels(), GetMaximumAirPressureInWheels(), GetWheeslManufactorName(), GetTypeOfLicense(), m_EngineVolume, m_Engine.GetEnergy(), m_Engine.GetMaximumEnergy());
            }

            return informationAboutCar;
        }

        public override string GetAttributes()
        {
            return "model name::string" + //0
                "||Enter air pressure in wheels::float" + //1
                "||Enter manufactor name of wheels::string" + //2
                "||Enter the type of license (A,A1,AA,B1)::string" + //3
                "||Enter engine volume::int" + //4
                "||Is the motorcycle on fuel? (true/false)::bool" + //5
                $"||If the motorcycle runs of fuel, enter the amount of fuel it has (maximum is {k_MaximumAmountOfFuel})\n" +
                $"If it runs on electricity, enter the amount of time it has left (maximum is {k_MaximumAmountOfElectricity})::float"; //6
        }

        public override float GetEnergy()
        {
            return m_Engine.GetEnergy();
        }

        public override void AddFuelOrElectricity(float i_HowMuchFuelToAdd, string i_TypeOfEnergy)
        {
            m_Engine.AddEnergy(i_HowMuchFuelToAdd, i_TypeOfEnergy);
        }

        public override bool IsElectricity()
        {
            return WorkOnCar.IsElectricity(m_Engine);
        }

        public override bool IsFuel()
        {
            return WorkOnCar.IsFuel(m_Engine);
        }

        private eTypeOfLicense StringLicenseTypeToEnum(string i_LicenseType)
        {
            eTypeOfLicense i_TypeToReturn = eTypeOfLicense.A;
            switch (i_LicenseType)
            {
                case "A":
                    i_TypeToReturn = eTypeOfLicense.A;
                    break;
                case "A1":
                    i_TypeToReturn = eTypeOfLicense.A1;
                    break;
                case "AA":
                    i_TypeToReturn = eTypeOfLicense.AA;
                    break;
                case "B1":
                    i_TypeToReturn = eTypeOfLicense.B1;
                    break;
                default: //TODO: EXCEPTION NO SUCH TYPE OF LICENSE
                    throw new ArgumentException($"\"{i_LicenseType}\" is not a type of license", 
                        nameof(i_LicenseType));
            }
            return i_TypeToReturn;
        }

        public override void SetCarInitialState(string i_StringAttribute)
        {
            switch (m_IndexSetupAttribute)
            {
                case 0:
                    this.SetModelName(i_StringAttribute);
                    break;
                case 2:
                    SetWheelsManufactorName(i_StringAttribute);
                    break;
                case 3:
                    m_TypeLicense = StringLicenseTypeToEnum(i_StringAttribute);
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
                m_EngineVolume = i_IntAttribute;
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
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
