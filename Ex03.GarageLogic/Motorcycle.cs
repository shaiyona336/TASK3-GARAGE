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

        private typeOfLicense m_typeLicense;
        private int m_engineVolume;
        private Engine m_engine;


        public override float getEnergy()
        {
            return m_engine.getEnergy();
        }

        public string getAttributes()
        {
            return ("model name::string\\license plate::string\\air pressure wheels::int\\type of license(A,A1,AA,B1)::string\\engine volume::int\\fuel or electric car: (0 for fuel)");
        }

    }
}
