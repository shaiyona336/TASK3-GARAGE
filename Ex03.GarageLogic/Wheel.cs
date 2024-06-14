using System;


namespace Ex03.GarageLogic
{
    sealed class Wheel
    {
        private string nameCreator;
        private float airPressureInWheel;
        private float maximumAirPressureInWheel;


        public void addAirPressureToWheels(int howMuchPressureToAdd)
        {
            airPressureInWheel = WorkOnCar.addResourceToResource(airPressureInWheel, howMuchPressureToAdd);
        }

    }
}
