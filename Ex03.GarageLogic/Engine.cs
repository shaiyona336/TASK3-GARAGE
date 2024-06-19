namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public abstract float GetEnergy();
        public abstract void SetMaximumEnergy(float i_MaximumEnergy);
        public abstract float GetMaximumEnergy();
        public abstract void AddEnergy(float i_HowMuchToAdd, string i_TypeOfEnergy);
        public abstract void SetEnergy(float i_HowMuchEnergy);

        public static Engine SetEngineByBool(bool i_IsFuel)
        {
            Engine engine;
            if (i_IsFuel == true)
            {
                engine = new FuelEngine();
            }
            else
            {
                engine = new ElectricEngine();
            }
            return engine;
        }

        public bool IsFuel()
        {
            return this is FuelEngine;
        }

        public bool IsElectricity()
        {
            return this is ElectricEngine;
        }
    }
}
