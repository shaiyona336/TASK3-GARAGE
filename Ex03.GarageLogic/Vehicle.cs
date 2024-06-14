using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string modelName;
        private string licensePlate;
        private List<Wheel> wheels;


        abstract public void setCarInitialState(string stringAttribute);


        public void setModelName(string setModelName)
        {
            modelName = setModelName;
        }

        public void setLicensePlate(string setLicensePlate)
        {
            licensePlate = setLicensePlate;
        }

        public string getLicensePlate()
        {
            return licensePlate;
        }

        abstract public string getAttributes();


        public void setWheelsPressure (int setAirPressure)
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.addAirPressureToWheels(setAirPressure);
                break;
            }
        }



        abstract public float getEnergy();
    }
}
