using Ex03.GarageLogic;
using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string modelName;
        private string licensePlate;
        protected List<Wheel> wheels;


        abstract public void setCarInitialState(string stringAttribute);
        abstract public void setCarInitialState(int i_intAttribute);
        abstract public void setCarInitialState(float i_intAttribute);
        abstract public void setCarInitialState(bool i_intAttribute);


      
        public void setAirPressureInWheelToMaximum()
        {
            if (wheels.Count != 0)
                {
                    foreach (Wheel wheel in wheels)
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
            wheels = new List<Wheel>();
            for (int wheelIndex = 0; wheelIndex < numberOfWheels; wheelIndex++)
            {
                Wheel wheel = new Wheel();
                wheels.Add(wheel);
            }
        }



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




        public void setInitialWheelsPressure(int i_setMaximumAirPressure)
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.setMaximumAirPressureInWheel(i_setMaximumAirPressure);
            }
        }



        public void addWheelsPressure (int setAirPressure)
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.addAirPressureToWheels(setAirPressure);
            }
        }



        abstract public float getEnergy();
    }
}
