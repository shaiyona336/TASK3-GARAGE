using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class WorkOnCar
    {
        public static bool IsFuel(Engine i_Engine)
        {
            bool flag = false;
            if (i_Engine is FuelEngine)
            {
                flag = true;
            }
            return flag;
        }

        public static bool IsElectricity(Engine i_Engine)
        {
            bool flag = false;
            if (i_Engine is ElectricEngine)
            {
                flag = true;
            }
            return flag;
        }

        public static void AddResourceToResource(ref int i_AddTo, int i_HowMuchToAdd, int i_MaximumAirPressureInWheel)
        {
            if (i_AddTo + i_HowMuchToAdd <= i_MaximumAirPressureInWheel)
            {
                i_AddTo += i_HowMuchToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, i_MaximumAirPressureInWheel);
            }
        }

        public static void AddResourceToResource(ref float i_AddTo, float i_HowMuchToAdd, float i_MaximumAirPressureInWheel)
        {
            if (i_AddTo + i_HowMuchToAdd <= i_MaximumAirPressureInWheel)
            {
                i_AddTo = i_AddTo + i_HowMuchToAdd;
            }
            else
            {
                throw new ArgumentException("CANT ADD MORE THAN MAXIMUM");
            }
        }

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
    }
}
