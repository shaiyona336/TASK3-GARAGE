using System;

namespace Ex03.GarageLogic
{
    public sealed class Wheel
    {
        private float m_AirPressureInWheel = 0;
        private float m_MaximumAirPressureInWheel;
        private string m_ManufactorName;

        public void SetManufactorName(string i_ManufactorName)
        {
            m_ManufactorName = i_ManufactorName;
        }

        public float GetAirPressureInWheel()
        {
            return m_AirPressureInWheel;
        }

        public float GetMaximumAirPressureInWheel()
        {
            return m_MaximumAirPressureInWheel;
        }

        public string GetManufactorName()
        {
            return m_ManufactorName;
        }

        public void SetAirPressureInWheelToMaximum()
        {
            m_AirPressureInWheel = m_MaximumAirPressureInWheel;
        }

        public void SetMaximumAirPressureInWheel(float i_MaximumAirPressureInWheel)
        {
            m_MaximumAirPressureInWheel = i_MaximumAirPressureInWheel;
        }

        public void AddAirPressureToWheel(float i_HowMuchPressureToAdd)
        {
            Vehicle.AddResourceToResource(ref m_AirPressureInWheel, i_HowMuchPressureToAdd, m_MaximumAirPressureInWheel);
        }
    }
}
