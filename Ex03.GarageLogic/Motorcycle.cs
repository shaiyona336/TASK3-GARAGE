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

        private eTypeOfLicense m_TypeLicense;
        private int m_EngineVolume;
        private Engine m_Engine = new FuelEngine();
        private int m_IndexSetupAttribute = 0;
        private const int k_NumberOfWheels = 2;

        public Motorcycle()
        {
            InitializeWheels(k_NumberOfWheels);
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
            return "model name::string||maximum air pressure wheels::float||air pressure in wheels::float||manufactor name of wheels::string||type of license(A,A1,AA,B1)::string||engine volume::int||is car on fuel::bool||maximum energy::float";
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

        private eTypeOfLicense StringColorToEnum(string i_Color)
        {
            eTypeOfLicense i_TypeToReturn = eTypeOfLicense.A;
            switch (i_Color)
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
                    break;
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
                case 3:
                    SetWheelsManufactorName(i_StringAttribute);
                    break;
                case 4:
                    m_TypeLicense = StringColorToEnum(i_StringAttribute);
                    break;
                case 7:
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
            if (m_Engine != null && m_Engine is ElectricEngine)
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
