using System;
using System.Collections.Generic;
using System.Runtime;

namespace Ex03.GarageLogic
{
    sealed class Truck : Vehicle
    {
        private bool m_IsTransferDangerousMaterials;
        private float m_CargoVolume;
        private Engine m_Engine = new FuelEngine();
        private int m_IndexSetupAttribute = 0;
        private const int k_NumberOfWheels = 4;

        public Truck()
        {
            InitializeWheels(k_NumberOfWheels);
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
                    "is truck transfer dangerous materials: {4}\n" +
                    "cargo volume: {5}\n" +
                    "how much fuel: {6}\n" +
                    "type of fuel: {7}\n" +
                    "maximum amount of fuel: {8}\n", GetModelName(), GetAirPressureInWheels(), GetMaximumAirPressureInWheels(), GetWheeslManufactorName(), m_IsTransferDangerousMaterials, m_CargoVolume, m_Engine.GetEnergy(), (m_Engine as FuelEngine).GetTypeOfFuel(), m_Engine.GetMaximumEnergy());
            }
            else //car on electric engine
            {
                informationAboutCar = String.Format("model name: {0}\n" +
                     "air pressure in wheels: {1}\n" +
                     "maximum air pressure in wheels: {2}\n" +
                     "manufactor name of wheels: {3}\n" +
                     "is truck transfer dangerous materials: {4}\n" +
                     "cargo volume: {5}\n" +
                     "how much hours for battery: {6}\n" +
                     "maximum amount of hours for battery: {7}\n", GetModelName(), GetAirPressureInWheels(), GetMaximumAirPressureInWheels(), GetWheeslManufactorName(), m_IsTransferDangerousMaterials, m_CargoVolume, m_Engine.GetEnergy(), m_Engine.GetMaximumEnergy());
            }

            return informationAboutCar;
        }

        public override string GetAttributes()
        {
            return "model name::string||maximum air pressure wheels::float||air pressure in wheels::float||manufactor name of wheels::string||is the truck transfer dangerous materials::bool||cargo volume::float||is car on fuel(true/false)::bool||maximum energy::float";
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

        private void SetIsTransferDangerousMaterials(bool i_IsTransferDangerousMaterials)
        {
            m_IsTransferDangerousMaterials = i_IsTransferDangerousMaterials;
        }

        private void SetCargoVolume(float i_CargoVolume)
        {
            m_CargoVolume = i_CargoVolume;
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
                case 7:
                    (m_Engine as FuelEngine).SetTypeOfFuel(i_StringAttribute);
                    break;
                default:
                    throw new ArgumentException("SENT WRONG ATTRIBUTE");
                    break;
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(int i_IntAttribute)
        {
            throw new ArgumentException("SENT WRONG ATTRIBUTE");
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
            else if (m_IndexSetupAttribute == 5)
            {
                SetCargoVolume(i_FloatAttribute);
            }
            else if (m_IndexSetupAttribute == 8)
            {
                m_Engine.SetMaximumEnergy(i_FloatAttribute);
            }
            else
            {
                throw new ArgumentException("SENT WRONG ATTRIBUTE");
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(bool i_BoolAttribute)
        {
            if (m_IndexSetupAttribute == 4)
            {
                SetIsTransferDangerousMaterials(i_BoolAttribute);
            }
            else if (m_IndexSetupAttribute == 6)
            {
                m_Engine = WorkOnCar.SetEngineByBool(i_BoolAttribute);
            }
            else
            {
                throw new ArgumentException("SENT WRONG ATTRIBUTE");
            }
            m_IndexSetupAttribute++;
        }
    }
}
