using System;


namespace Ex03.GarageLogic
{
    public sealed class Wheel
    {
        private string m_nameCreator;
        private float m_airPressureInWheel;
        private float m_maximumAirPressureInWheel;
        private string m_manufactorName;


        public void setManufactorName(string i_manuFctorName)
        {
            m_manufactorName = i_manuFctorName;
        }

        public float getAirPressureInWheel()
        {
            return m_airPressureInWheel;
        }

        public float getMaximumAirPressureInWheel()
        {
            return m_maximumAirPressureInWheel;
        }


        public string getManufactorName()
        {
            return m_manufactorName;
        }

        public void setAirPressureInWheelToMaximum()
        {
            m_airPressureInWheel = m_maximumAirPressureInWheel;
        }
        public void setMaximumAirPressureInWheel(float i_maximumAirPressureInWheel)
        {
            m_maximumAirPressureInWheel = i_maximumAirPressureInWheel;
        }


        public void addAirPressureToWheel(float i_howMuchPressureToAdd)
        {
            WorkOnCar.addResourceToResource(ref m_airPressureInWheel, i_howMuchPressureToAdd, m_maximumAirPressureInWheel);
        }

    }
}
