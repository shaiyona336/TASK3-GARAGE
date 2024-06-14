using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private string modelName;
        private string licensePlate;
        private List<Wheel> wheels;
        

        abstract public float getEnergy();
    }
}
