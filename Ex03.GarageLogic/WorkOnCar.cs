using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class WorkOnCar
    {

        public static int addResourceToResource(int addTo, int howMuchToAdd, int maximumAirPressureInWheel)
        {
            if (addTo + howMuchToAdd <= maximumAirPressureInWheel)
            {
                addTo = addTo + howMuchToAdd;
            }
            //TODO: throw exception
            return addTo;
        }

        public static float addResourceToResource(float addTo, int howMuchToAdd, float maximumAirPressureInWheel)
        {
            if (addTo + howMuchToAdd <= maximumAirPressureInWheel)
            {
                addTo = addTo + howMuchToAdd;
            }
            //TODO: throw exception
            return addTo;
        }


        public static Engine setEngineByBool(bool isFuel)
        {
            Engine i_engine;
            if (isFuel == true)
            {
                i_engine = new FuelEngine();
            }
            else
            {
                i_engine = new ElectricEngine();
            }
            return i_engine;
        }
    }
}
