using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class WorkOnCar
    {

        public static bool isFuel(Engine i_engine)
        {
            bool i_flag = false;
            if (i_engine is FuelEngine)
            {
                i_flag = true;
            }
            return i_flag;
        }

        public static bool isElectricity(Engine i_engine)
        {
            bool i_flag = false;
            if (i_engine is ElectricEngine)
            {
                i_flag = true;
            }
            return i_flag;
        }

        public static void addResourceToResource(ref float addTo, float howMuchToAdd, float maximumAirPressureInWheel)
        {
            if (addTo + howMuchToAdd <= maximumAirPressureInWheel)
            {
                addTo += howMuchToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, maximumAirPressureInWheel);
            }

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
