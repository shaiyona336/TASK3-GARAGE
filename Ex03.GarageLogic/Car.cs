using System;


namespace Ex03.GarageLogic
{
    sealed class Car : Vehicle
    {
        enum colorsOfCars
        {
            YELLOW,
            WHITE,
            RED,
            BLACK,
        }
        private colorsOfCars color;
        private int numberOfDoors;
        private Engine engine;


        public string getAttributes()
        {
            return ("model name::string\\license plate::string\\air pressure wheels::int\\color(yellow,white,red,black)::string\\number of doors::int\\fuel or electric car: (0 for fuel)");
        }


        public override float getEnergy()
        {
            return engine.getEnergy();
        }

    }
}
