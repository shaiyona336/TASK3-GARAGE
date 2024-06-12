using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    sealed class ElectricEngine : Engine
    {
        private float statusBattery; //hours for battery
        private float maximumForBattery; //how many hours can electric car drive by with maximum battery


        protected override float getEnergy()
        {
            return statusBattery;
        }


        public void chargeBattery(int howManyHoursToAddToBattery)
        {
            statusBattery = WorkOnCar.addResourceToResource(statusBattery, howManyHoursToAddToBattery);
        }

    }
}
