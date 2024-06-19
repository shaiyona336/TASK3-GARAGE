using System;

namespace Ex03.GarageLogic
{
    public sealed class Wheel
    {
        private float m_AirPressureInWheel = 0;
        public float AirPressureInWheel
        {
            get { return m_AirPressureInWheel; }
        }

        public string ManufactorName { get; set; }
        public float MaximumAirPressureInWheel { get; set; }

        public void SetAirPressureInWheelToMaximum()
        {
            m_AirPressureInWheel = MaximumAirPressureInWheel;
        }

        public void AddAirPressureToWheel(float i_HowMuchPressureToAdd)
        {
            Vehicle.AddResourceToResource(ref m_AirPressureInWheel, i_HowMuchPressureToAdd, MaximumAirPressureInWheel);
        }
    }
}
