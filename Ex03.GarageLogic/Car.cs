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
        private Engine m_engine;
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


        public override string getAttributes()
        {
            m_indexSetupAttribute = 0;
            return ("model name::string||air pressure wheels::int||color(yellow,white,red,black)::string||number of doors::int||fuel or electric car::bool||maximum energy::float");
        }


        public override void setCarInitialState(string stringAttribute)
        {
            switch (m_indexSetupAttribute)
            {
                case (0):
                    this.setModelName(stringAttribute);
                    break;
                case (2):
                    m_color = stringColorToEnum(stringAttribute);
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
