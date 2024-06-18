namespace Ex03.GarageLogic
{
    abstract class Engine
    {
        public abstract float GetEnergy();
        public abstract void SetMaximumEnergy(float i_MaximumEnergy);
        public abstract float GetMaximumEnergy();
        public abstract void AddEnergy(float i_HowMuchToAdd, string i_TypeOfEnergy);
    }
}
