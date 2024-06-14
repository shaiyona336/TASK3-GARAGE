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
        private colorsOfCars m_color;
        private int m_numberOfDoors;
        private Engine m_engine;
        int m_indexSetupAttribute = 0; //with attribute by the order of get attributes do i now set


        public override float getEnergy()
        {
            return m_engine.getEnergy();
        }


        private void setEngineByBool(bool isFuel)
        {
            if (isFuel == true)
            {
                m_engine = new FuelEngine();
            }
            else
            {
                m_engine = new ElectricEngine();
            }
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


        public string getAttributes()
        {
            return ("model name::string\\license plate::string\\air pressure wheels::int\\color(yellow,white,red,black)::string\\number of doors::int\\fuel or electric car: (0 for fuel)::bool");
        }


        public void setCarInitialState(string stringAttribute)
        {
            switch (m_indexSetupAttribute)
            {
                case (0):
                    this.setModelName(stringAttribute);
                    break;
                case (1):
                    this.setLicensePlate(stringAttribute);
                    break;
                case (3):
                    m_color = stringColorToEnum(stringAttribute);
                    break;
                case (5):
                    m_color = stringColorToEnum(stringAttribute);
                    break;
                default:
                    //TODO : EXCEPTION SENT TOO MANY ATTRIBUTES
                    break;


            }
        }
        public void setCarInitialState(int i_intAttribute)
        {
            if (m_indexSetupAttribute == 2)
            {
                this.setWheelsPressure(i_intAttribute);

            }
            else if (m_indexSetupAttribute == 4)
            {
                m_numberOfDoors = i_intAttribute;
            }
            else
            {
                //TODO : EXCEPTION SENT TOO MANY ATTRIBUTES
            }
        }

        public void setCarInitialState(bool boolAttribute)
        {
            if (m_indexSetupAttribute == 4)
            {

            }
            else
            {
                //TODO : EXCEPTION SENT TOO MANY ATTRIBUTES
            }
        }

    }
}
