using System;

namespace Ex03.GarageLogic
{
    sealed class Truck : Vehicle
    {
        private const int k_MaximumAirPressure = 28;
        private const string k_FuelType = "Soler";
        private const float k_MaximumAmountOfFuel = 120;
        private const int k_NumberOfWheels = 12;

        private bool m_IsTransferDangerousMaterials;
        private float m_CargoVolume;
        private FuelEngine m_Engine;
        private int m_IndexSetupAttribute = 0;

        public Truck()
        {
            InitializeWheels(k_NumberOfWheels);
            SetInitialWheelsPressure(k_MaximumAirPressure);

            m_Engine = new FuelEngine();
            m_Engine.SetTypeOfFuel(k_FuelType);
            m_Engine.SetMaximumEnergy(k_MaximumAmountOfFuel);
        }

        public override string GetInformationAboutCar()
        {
            string informationAboutVehicle;

            if (m_Engine is FuelEngine)
            {
                informationAboutVehicle = String.Format("model name: {0}\n" +
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
                informationAboutVehicle = String.Format("model name: {0}\n" +
                     "air pressure in wheels: {1}\n" +
                     "maximum air pressure in wheels: {2}\n" +
                     "manufactor name of wheels: {3}\n" +
                     "is truck transfer dangerous materials: {4}\n" +
                     "cargo volume: {5}\n" +
                     "how much hours for battery: {6}\n" +
                     "maximum amount of hours for battery: {7}\n", GetModelName(), GetAirPressureInWheels(), GetMaximumAirPressureInWheels(), GetWheeslManufactorName(), m_IsTransferDangerousMaterials, m_CargoVolume, m_Engine.GetEnergy(), m_Engine.GetMaximumEnergy());
            }

            return informationAboutVehicle;
        }

        public override string GetAttributes()
        {
            return "Enter Model Name::string" + //0
                $"||Enter air pressure in wheels (maximum is {k_MaximumAirPressure})::float" + //1
                "||Enter the manufactor name of the wheels::string" + //2
                "||Is the truck transferring dangerous materials? (true/false)::bool" + //3
                "||Enter cargo volume::float" + //4
                $"||Enter the amount of fuel in the truck (maximum is {k_MaximumAmountOfFuel})::float"; //5
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

        private void setIsTransferDangerousMaterials(bool i_IsTransferDangerousMaterials)
        {
            m_IsTransferDangerousMaterials = i_IsTransferDangerousMaterials;
        }

        private void setCargoVolume(float i_CargoVolume)
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
                case 2:
                    SetWheelsManufactorName(i_StringAttribute);
                    break;
                default:
                    throw new ArgumentException("SENT WRONG ATTRIBUTE");
            }
            m_IndexSetupAttribute++;
        }

        public override void SetCarInitialState(int i_IntAttribute)
        {
            throw new ArgumentException("SENT WRONG ATTRIBUTE");
        }

        public override void SetCarInitialState(float i_FloatAttribute)
        {
            if (m_IndexSetupAttribute == 1)
            {
                AddWheelsPressure(i_FloatAttribute);
            }
            else if (m_IndexSetupAttribute == 4)
            {
                setCargoVolume(i_FloatAttribute);
            }
            else if (m_IndexSetupAttribute == 5)
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
            if (m_IndexSetupAttribute == 3)
            {
                setIsTransferDangerousMaterials(i_BoolAttribute);
            }
            else
            {
                throw new ArgumentException("SENT WRONG ATTRIBUTE");
            }
            m_IndexSetupAttribute++;
        }
    }
}
