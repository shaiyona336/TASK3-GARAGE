using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    sealed class ElectricEngine : Engine
    {
        private float m_statusBattery; //hours for battery
        private float m_maximumForBattery; //how many hours can electric car drive by with maximum battery


        public override float getEnergy()
        {
            return m_statusBattery;
        }


        public override void addEnergy(float howManyHoursToAddToBattery, string typeOfEnergy)
        {
            WorkOnCar.addResourceToResource(ref m_statusBattery, howManyHoursToAddToBattery, m_maximumForBattery);
        }


        public override void setMaximumEnergy(float i_maximumEnergy)
        {
            m_maximumForBattery = i_maximumEnergy;
        }

    }
}
