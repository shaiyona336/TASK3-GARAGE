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
        int m_indexSetupAttribute = 0;
        private const int m_numberOfWheels = 2;


        public MotorCycle()
        {
            initializeWheels(m_numberOfWheels);
        }


        public override float getEnergy()
        {
            return m_engine.getEnergy();
        }

        public override string getAttributes()
        {
            return ("model name::string||air pressure wheels::int||type of license(A,A1,AA,B1)::string||engine volume::int||fuel or electric car::bool||maximum energy::float");
        }

        


        private typeOfLicense stringColorToEnum(string i_color)
        {
            typeOfLicense i_typeToReturn = typeOfLicense.A;
            switch (i_color)
            {
                case ("A"):
                    i_typeToReturn = i_typeToReturn = typeOfLicense.A;
                    break;
                case ("A1"):
                    i_typeToReturn = i_typeToReturn = typeOfLicense.A1;
                    break;
                case ("AA"):
                    i_typeToReturn = i_typeToReturn = typeOfLicense.AA;
                    break;
                case ("B1"):
                    i_typeToReturn = i_typeToReturn = typeOfLicense.B1;
                    break;
                default: //TODO: EXCEPTION NO SUCH TYPE OF LICENSE
                    break;

            }
            return i_typeToReturn;
        }


        public override void setCarInitialState(string stringAttribute)
        {
            switch (m_indexSetupAttribute)
            {
                case (0):
                    this.setModelName(stringAttribute);
                    break;
                case (2):
                    m_typeLicense = stringColorToEnum(stringAttribute);
                    break;
                default:
                    //TODO : SENT WRONG ATTRIBUTE
                    break;
            }
            m_indexSetupAttribute++;
        }
        public override void setCarInitialState(int i_intAttribute)
        {
            if (m_indexSetupAttribute == 1)
            {
                setInitialWheelsPressure(i_intAttribute);
            }
            else if (m_indexSetupAttribute == 3)
            {
                m_engineVolume = i_intAttribute;
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_indexSetupAttribute++;
        }


        public override void setCarInitialState(float i_floatAttribute)
        {
            if (m_indexSetupAttribute == 5)
            {
                m_engine.setMaximumEnergy(i_floatAttribute);
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_indexSetupAttribute++;
        }


        public override void setCarInitialState(bool i_boolAttribute)
        {
            if (m_indexSetupAttribute == 4)
            {
                m_engine = WorkOnCar.setEngineByBool(i_boolAttribute);
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_indexSetupAttribute++;
        }


    }
}
