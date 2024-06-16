using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    abstract class Engine
    {
        abstract public float getEnergy();
        abstract public void setMaximumEnergy(float i_maximumEnergy);
        abstract public float getMaximumEnergy();
        abstract public void addEnergy(float howMuchToAdd,string typeOfEnergy);



    }
}
