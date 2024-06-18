using Ex03.GarageLogic;
using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_modelName;
        private string m_licensePlate;
        protected List<Wheel> m_wheels;
        public int m_indexSetupAttribute { get; set; } = 0; //with attribute by the order of get attributes does the function need now to set


        abstract public void setCarInitialState(string stringAttribute);
        abstract public void setCarInitialState(int i_intAttribute);
        abstract public void setCarInitialState(float i_intAttribute);
        abstract public void setCarInitialState(bool i_intAttribute);
        abstract public bool isFuel();
        abstract public bool isElectricity();
        abstract public void addFuelOrElectricity(float howMuchFuelToAdd, string typeOfEnergy);
        abstract public string getInformationAboutCar();


        public string getLicensePlate()
        {
            return m_licensePlate;
        }

        public string getModelName()
        {
            return m_modelName;
        }

        public string getWheeslManufactorName()
        {
            string i_manuFactorName;

            if (m_wheels.Count != 0)
            {
                i_manuFactorName = m_wheels[0].m_manufactorName;
            }
            else
            {
                i_manuFactorName = "no wheels";
            }
            return i_manuFactorName;
        }

        public float getMaximumAirPressureInWheels()
        {
            float airPressureInWheels = 0;

            if (m_wheels.Count != 0)
            {
                airPressureInWheels = m_wheels[0].m_maximumAirPressureInWheel;
            }
            else
            {
                //TODO : no wheels
            }
            return airPressureInWheels;
        }

        public float getAirPressureInWheels()
        {
            float airPressureInWheels = 0;

            if (m_wheels.Count != 0)
            {
                airPressureInWheels = m_wheels[0].getAirPressureInWheel();
            }
            else
            {
                //TODO : no wheels
            }
            return airPressureInWheels;
        }


        public void setWheelsManufactorName(string i_manufactorName)
        {
            if (m_wheels.Count != 0)
            {
                foreach (Wheel wheel in m_wheels)
                {
                    wheel.m_manufactorName = i_manufactorName;
                }
            }
        }




        public void setAirPressureInWheelToMaximum()
        {
            if (m_wheels.Count != 0)
                {
                    foreach (Wheel wheel in m_wheels)
                {
                    wheel.setAirPressureInWheelToMaximum();
                }
                   }
                else
                    {
                        //TODO : exception no wheels in vehicle
                    }
          }


        public void initializeWheels(int numberOfWheels)
        {
            m_wheels = new List<Wheel>();
            for (int wheelIndex = 0; wheelIndex < numberOfWheels; wheelIndex++)
            {
                Wheel wheel = new Wheel();
                m_wheels.Add(wheel);
            }
        }



        public void setModelName(string setModelName)
        {
            m_modelName = setModelName;
        }

        public void setLicensePlate(string setLicensePlate)
        {
            m_licensePlate = setLicensePlate;
        }


        abstract public string getAttributes();




        public void setInitialWheelsPressure(float i_setMaximumAirPressure)
        {
            foreach (Wheel wheel in m_wheels)
            {
                wheel.m_maximumAirPressureInWheel = i_setMaximumAirPressure;
            }
        }



        public void addWheelsPressure (float setAirPressure)
        {
            foreach (Wheel wheel in m_wheels)
            {
                wheel.addAirPressureToWheel(setAirPressure);
            }
        }

        abstract public float getEnergy();

    }
}
