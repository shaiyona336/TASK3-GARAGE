using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class WorkOnCar
    {

        public static int addResourceToResource(int addTo, int howMuchToAdd)
        {
            if (addTo + howMuchToAdd <= addTo)
            {
                addTo = addTo + howMuchToAdd;
            }
            //potentially need to throw exception
            return addTo;
        }

        public static float addResourceToResource(float addTo, int howMuchToAdd)
        {
            if (addTo + howMuchToAdd <= addTo)
            {
                addTo = addTo + howMuchToAdd;
            }
            //potentially need to throw exception
            return addTo;
        }
    }
}
