using System;
using System.Collections.Generic;



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
        private colorsOfCars m_color;
        private int m_numberOfDoors;
        private Engine m_engine = new FuelEngine();
        int m_indexSetupAttribute = 0; //with attribute by the order of get attributes does the function need now to set
        private const int m_numberOfWheels = 4;


        public Car()
        {
            initializeWheels(m_numberOfWheels);
        }


        public override float getEnergy()
        {
            return m_engine.getEnergy();
        }


        public override bool isElectricity()
        {
            return WorkOnCar.isElectricity(m_engine);
        }


        public override bool isFuel()
        {
            return WorkOnCar.isFuel(m_engine);
        }


        public override void addFuelOrElectricity(float howMuchFuelToAdd, string typeOfEnergy)
        {
            m_engine.addEnergy(howMuchFuelToAdd, typeOfEnergy);
        }



        private colorsOfCars stringColorToEnum(string i_color)
        {
            colorsOfCars i_colorToReturn = colorsOfCars.BLACK;
            switch (i_color)
            {
                case ("yellow"):
                    i_colorToReturn = i_colorToReturn = colorsOfCars.YELLOW;
                    break;
                case ("white"):
                    i_colorToReturn = i_colorToReturn = colorsOfCars.WHITE;
                    break;
                case ("red"):
                    i_colorToReturn = i_colorToReturn = colorsOfCars.RED;
                    break;
                case ("black"):
                    i_colorToReturn = i_colorToReturn = colorsOfCars.BLACK;
                    break;
                default: //TODO: EXCEPTION NO SUCH COLOR
                    break;

            }
            return i_colorToReturn;
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
                    "color: {4}\n" +
                    "number of doors: {5}\n" +
                    "how much fuel: {6}\n" +
                    "type of fuel: {7}\n" +
                    "maximum amount of fuel: {8}\n", getModelName(), getAirPressureInWheels(), getMaximumAirPressureInWheels(), getWheeslManufactorName(), m_color, m_numberOfDoors, m_engine.getEnergy(), (m_engine as FuelEngine).getTypeOfFuel(), m_engine.getMaximumEnergy());
            }
            else //car on electric engine
            {
                i_informationAboutCar = String.Format("model name: {0}\n" +
                    "air pressure in wheels: {1}\n" +
                    "maximum air pressure in wheels: {2}\n" +
                    "manufactor name of wheels: {3}\n" +
                    "color: {4}\n" +
                    "number of doors: {5}\n" +
                    "how much hours for battery: {6}\n" +
                    "maximum amount of hours for battery: {7}\n" , getModelName(), getAirPressureInWheels(), getMaximumAirPressureInWheels(), getWheeslManufactorName(), m_color, m_numberOfDoors, m_engine.getEnergy(), m_engine.getMaximumEnergy());
            }

            return i_informationAboutCar;
        }


        public override string getAttributes()
        {
            m_indexSetupAttribute = 0;
            return ("model name::string||maximum air pressure wheels::float||air pressure in wheels::float||manufactor name of wheels::string||color(yellow,white,red,black)::string||number of doors::int||is car on fuel::bool||maximum energy::float");
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
                    m_color = stringColorToEnum(i_stringAttribute);
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
                m_numberOfDoors = i_intAttribute;
            }
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_indexSetupAttribute++;
        }


        public override void setCarInitialState(float i_floatAttribute)
        {
            if (m_engine != null && m_engine is ElectricEngine) //electric engine do not need to get type of fuel, so the index of set maximum energy is one less and need to add one
            {
                m_indexSetupAttribute++;
            }
            if (m_indexSetupAttribute == 1)
            {
                setInitialWheelsPressure(i_floatAttribute);
            }
            else if (m_indexSetupAttribute == 2)
            {
                addWheelsPressure(i_floatAttribute);
            }
            else if (m_indexSetupAttribute == 8)
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
            if (m_indexSetupAttribute == 6)
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
