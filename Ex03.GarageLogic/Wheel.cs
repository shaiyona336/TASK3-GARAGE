using System;


namespace Ex03.GarageLogic
{
    public sealed class Wheel
    {
        private string m_nameCreator;
        private float m_airPressureInWheel;
        private float m_maximumAirPressureInWheel;


        public void setMaximumAirPressureInWheel(float i_maximumAirPressureInWheel)
        {
            m_maximumAirPressureInWheel = i_maximumAirPressureInWheel;
        }


        public void addAirPressureToWheels(int i_howMuchPressureToAdd)
        {
            m_airPressureInWheel = WorkOnCar.addResourceToResource(m_airPressureInWheel, i_howMuchPressureToAdd, m_maximumAirPressureInWheel);
        }

    }
}
