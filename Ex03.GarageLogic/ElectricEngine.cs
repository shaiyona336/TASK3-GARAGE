namespace Ex03.GarageLogic
{
    sealed class ElectricEngine : Engine
    {
        private float m_StatusBattery; //hours for battery
        private float m_MaximumForBattery; //how many hours can electric car drive by with maximum battery

        public override float GetMaximumEnergy()
        {
            return m_MaximumForBattery;
        }

        public override float GetEnergy()
        {
            return m_StatusBattery;
        }

        public override void AddEnergy(float i_HowManyHoursToAddToBattery, string i_TypeOfEnergy)
        {
            WorkOnCar.AddResourceToResource(ref m_StatusBattery, i_HowManyHoursToAddToBattery, m_MaximumForBattery);
        }

        public override void SetMaximumEnergy(float i_MaximumEnergy)
        {
            m_MaximumForBattery = i_MaximumEnergy;
        }

        public override void SetEnergy(float i_HowMuchEnergy)
        {
            if (i_HowMuchEnergy <= m_MaximumForBattery)
            {
                m_StatusBattery = i_HowMuchEnergy;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaximumForBattery);
            }
        }
    }
}
