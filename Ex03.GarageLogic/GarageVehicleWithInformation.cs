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
        private Vehicle vehicle;
        private string nameOfOwner;
        private string phoneOfOwner;
        private carStatus statusCar;

        public Vehicle getVehicle()
        {
            return vehicle;
        }

        public void setCarStatusInProgress()
        {
            statusCar = carStatus.INPROGRESS;
        }
    }
}
