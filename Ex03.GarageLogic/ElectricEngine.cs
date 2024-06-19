namespace Ex03.GarageLogic
{
    sealed class ElectricEngine : Engine
    {
        private float m_MaximumForBattery; //how many hours can electric car drive by with maximum battery
        private float m_StatusBattery; //hours for battery
        public float StatusBattery
        {
            get { return m_StatusBattery; } 
            set
            {
                if (value <= m_MaximumForBattery)
                {
                    m_StatusBattery = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaximumForBattery);
                }
            }
        }

        public override float GetMaximumEnergy()
        {
            return m_MaximumForBattery;
        }

        public override float GetEnergy()
        {
            return StatusBattery;
        }

        public override void AddEnergy(float i_HowManyHoursToAddToBattery, string i_TypeOfEnergy)
        {
            Vehicle.AddResourceToResource(ref m_StatusBattery, i_HowManyHoursToAddToBattery, m_MaximumForBattery);
        }

        public override void SetMaximumEnergy(float i_MaximumEnergy)
        {
            m_MaximumForBattery = i_MaximumEnergy;
        }

        public override void SetEnergy(float i_HowMuchEnergy)
        {
            StatusBattery = i_HowMuchEnergy;
        }
    }
}
