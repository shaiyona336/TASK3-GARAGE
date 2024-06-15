using System;
using System.Collections.Generic;


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

        public override string getAttributes()
        {
            return ("model name::string||license plate::string||air pressure wheels::int||type of license(A,A1,AA,B1)::string||engine volume::int||fuel or electric car: (0 for fuel)");
        }


        public override void setCarInitialState(string i_intAttribute)
        {

        }

        public override void setCarInitialState(int i_stringAttribute)
        {

        }

        public override void setCarInitialState(float i_stringAttribute)
        {
            //TODO : class dont use this kind of attribute
        }

        public override void setCarInitialState(bool i_boolAttribute)
        {

        }


    }
}
