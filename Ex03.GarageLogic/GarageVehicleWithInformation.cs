using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    internal class GarageVehicleWithInformation
    {
        enum carStatus
        {
            INPROGRESS,
            FIXED,
            PAYED
        }
        private string nameOfOwner;
        private string phoneOfOwner;
        private carStatus statusCar;
    }
}
