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

        public override string getAttributes()
        {
            return ("model name::string\\license plate::string\\air pressure wheels::int\\is the truck transfer dangerous materials(write yes if it does)::string\\cargo volume::float\\fuel or electric car: (0 for fuel)");
        }


        public override void setCarInitialState(string i_intAttribute)
        {

        }

        public override void setCarInitialState(int i_stringAttribute)
        {

        }

        public override void setCarInitialState(bool i_boolAttribute)
        {

        }

    }


   
}
