using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    sealed class FuelEngin
    {
        enum typeOfFuel
        {
            Soler,
            Octan95,
            Octan96,
            Octan98,

        }
        private typeOfFuel typeFuel;
        private float statusFuel;
        private float maximumFuel;
    }
}
