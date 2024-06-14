using System;


namespace Ex03.GarageLogic
{
    sealed class MotorCycle : Vehicle
    {
        enum typeOfLicense
        {
            A,
            A1,
            AA,
            B1,
        }

        private typeOfLicense typeLicense;
        private int engineVolume;
        private Engine engine;


        public override float getEnergy()
        {
            return engine.getEnergy();
        }

        public string getAttributes()
        {
            return ("model name::string\\license plate::string\\air pressure wheels::int\\type of license(A,A1,AA,B1)::string\\engine volume::int\\fuel or electric car: (0 for fuel)");
        }

    }
}
