using System;


namespace Ex03.GarageLogic
{
    sealed class Truck : Vehicle
    {

        private bool isTransferDangerousMaterials;
        private float cargoVolume;
        private Engine engine;
        public override float getEnergy()
        {
            return engine.getEnergy();
        }

        public string getAttributes()
        {
            return ("model name::string\\license plate::string\\air pressure wheels::int\\is the truck transfer dangerous materials(write yes if it does)::string\\cargo volume::float\\fuel or electric car: (0 for fuel)");
        }

    }


   
}
