using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicensePlate;
        protected List<Wheel> m_Wheels;

        public abstract void SetCarInitialState(string i_StringAttribute);
        public abstract void SetCarInitialState(int i_IntAttribute);
        public abstract void SetCarInitialState(float i_IntAttribute);
        public abstract void SetCarInitialState(bool i_IntAttribute);
        public abstract bool IsFuel();
        public abstract bool IsElectricity();
        public abstract void AddFuelOrElectricity(float i_HowMuchFuelToAdd, string i_TypeOfEnergy);
        public abstract string GetInformationAboutCar();

        public string GetLicensePlate()
        {
            return m_LicensePlate;
        }

        public string GetModelName()
        {
            return m_ModelName;
        }

        public string GetWheeslManufactorName()
        {
            string manuFactorName;

            if (m_Wheels.Count != 0)
            {
                manuFactorName = m_Wheels[0].GetManufactorName();
            }
            else
            {
                manuFactorName = "no wheels";
            }
            return manuFactorName;
        }

        public float GetMaximumAirPressureInWheels()
        {
            float airPressureInWheels = 0;

            if (m_Wheels.Count != 0)
            {
                airPressureInWheels = m_Wheels[0].GetMaximumAirPressureInWheel();
            }
            else
            {
                throw new ArgumentException("CANNON GET MAXIMUM AIR PRESSURE FROM WHEELS IN VEHICLE WITHOUT WHEELS");
            }
            return airPressureInWheels;
        }

        public float GetAirPressureInWheels()
        {
            float airPressureInWheels = 0;

            if (m_Wheels.Count != 0)
            {
                airPressureInWheels = m_Wheels[0].GetAirPressureInWheel();
            }
            else
            {
                throw new ArgumentException("CANNOT GET AIR PRESUSRE IN WHEELS IN VEHICLE THAT HAS NO WHEELS");
            }
            return airPressureInWheels;
        }

        public void SetWheelsManufactorName(string i_ManufactorName)
        {
            if (m_Wheels.Count != 0)
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    wheel.SetManufactorName(i_ManufactorName);
                }
            }
        }

        public void SetAirPressureInWheelToMaximum()
        {
            if (m_Wheels.Count != 0)
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    wheel.SetAirPressureInWheelToMaximum();
                }
            }
            else
            {
                throw new ArgumentException("CANNON SET MAXIMUM AIR PRESUSRE IN WHEELS FOR VEHICLE WITHOUT WHEELS");
            }
        }

        public void InitializeWheels(int i_NumberOfWheels)
        {
            m_Wheels = new List<Wheel>();
            for (int wheelIndex = 0; wheelIndex < i_NumberOfWheels; wheelIndex++)
            {
                Wheel wheel = new Wheel();
                m_Wheels.Add(wheel);
            }
        }

        public void SetModelName(string i_SetModelName)
        {
            m_ModelName = i_SetModelName;
        }

        public void SetLicensePlate(string i_SetLicensePlate)
        {
            m_LicensePlate = i_SetLicensePlate;
        }

        public abstract string GetAttributes();

        public void SetInitialWheelsPressure(float i_SetMaximumAirPressure)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.SetMaximumAirPressureInWheel(i_SetMaximumAirPressure);
            }
        }

        public void AddWheelsPressure(float i_SetAirPressure)
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.AddAirPressureToWheel(i_SetAirPressure);
            }
        }

        public abstract float GetEnergy();
    }
}
