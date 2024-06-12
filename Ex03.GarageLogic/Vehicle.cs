using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        private string modelName;
        private string licensePlate;
        private float energyLeft;
        private List<Wheel> wheels;
        private Engine engine;
    }
}
