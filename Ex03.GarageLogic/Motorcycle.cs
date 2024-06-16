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


        private string getTypeOfLicense()
        {
            string i_typeOfLicense = "";

            switch (m_typeLicense) {
                case (typeOfLicense.A):
                    i_typeOfLicense = "A";
                    break;
                case (typeOfLicense.A1):
                    i_typeOfLicense = "A1";
                    break;
                case (typeOfLicense.AA):
                    i_typeOfLicense = "AA";
                    break;
                case (typeOfLicense.B1):
                    i_typeOfLicense = "B1";
                    break;
            }
            return i_typeOfLicense;
        }



        public override string getInformationAboutCar()
        {
            string i_informationAboutCar = "";

            if (m_engine is FuelEngine)
            {
                i_informationAboutCar = String.Format("model name: {0}\n" +
                    "air pressure in wheels: {1}\n" +
                    "maximum air pressure in wheels: {2}\n" +
                    "manufactor name of wheels: {3}\n" +
                    "type of license: {4}\n" +
                    "cargo volume: {5}\n" +
                    "how much fuel: {6}\n" +
                    "type of fuel: {7}\n" +
                    "maximum amount of fuel: {8}\n", getModelName(), getAirPressureInWheels(), getMaximumAirPressureInWheels(), getWheeslManufactorName(), getTypeOfLicense(), m_engineVolume, m_engine.getEnergy(), (m_engine as FuelEngine).getTypeOfFuel(), m_engine.getMaximumEnergy());
            }
            else //car on electric engine
            {
                i_informationAboutCar = String.Format("model name: {0}\n" +
                    "air pressure in wheels: {1}\n" +
                    "maximum air pressure in wheels: {2}\n" +
                    "manufactor name of wheels: {3}\n" +
                    "type of license: {4}\n" +
                    "cargo volume: {5}\n" +
                    "how much hours for battery: {6}\n" +
                    "maximum amount of hours for battery: {7}\n", getModelName(), getAirPressureInWheels(), getMaximumAirPressureInWheels(), getWheeslManufactorName(), getTypeOfLicense(), m_engineVolume, m_engine.getEnergy(), m_engine.getMaximumEnergy());
            }

            return i_informationAboutCar;
        }


        public override string getAttributes()
        {
            return ("model name::string||maximum air pressure wheels::float||air pressure in wheels::float||manufactor name of wheels::string||type of license(A,A1,AA,B1)::string||engine volume::int||is car on fuel::bool||maximum energy::float");
        }


        public override float getEnergy()
        {
            return m_engine.getEnergy();
        }

        public override void addFuelOrElectricity(float howMuchFuelToAdd, string typeOfEnergy)
        {
            m_engine.addEnergy(howMuchFuelToAdd, typeOfEnergy);
        }

        public override bool isElectricity()
        {
            return WorkOnCar.isElectricity(m_engine);
        }

        public override bool isFuel()
        {
            return WorkOnCar.isFuel(m_engine);
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


        public override void setCarInitialState(string i_stringAttribute)
        {
            switch (m_indexSetupAttribute)
            {
                case (0):
                    this.setModelName(i_stringAttribute);
                    break;
                case (3):
                    setWheelsManufactorName(i_stringAttribute);
                    break;
                case (4):
                    m_typeLicense = stringColorToEnum(i_stringAttribute);
                    break;
                case (7):
                    (m_engine as FuelEngine).setTypeOfFuel(i_stringAttribute);
                    break;
                default:
                    //TODO : SENT WRONG ATTRIBUTE
                    break;
            }
            m_indexSetupAttribute++;
        }
        public override void setCarInitialState(int i_intAttribute)
        {
            if (m_indexSetupAttribute == 5)
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
            if (m_indexSetupAttribute == 1)
            {
                setInitialWheelsPressure(i_floatAttribute);
            }
            else if (m_indexSetupAttribute == 2)
            {
                addWheelsPressure(i_floatAttribute);
            }
            else if (m_indexSetupAttribute == 6)
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
            if (m_indexSetupAttribute == 8)
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
