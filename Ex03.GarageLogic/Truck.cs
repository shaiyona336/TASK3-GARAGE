using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    sealed class Truck : Vehicle
    {

        private bool m_isTransferDangerousMaterials;
        private float m_cargoVolume;
        private Engine m_engine;
        int m_indexSetupAttribute = 0;
        private const int m_numberOfWheels = 4;

        public Truck()
        {
            base.wheels = new List<Wheel>();
            for (int wheelIndex = 0; wheelIndex < m_numberOfWheels; wheelIndex++)
            {
                Wheel wheel = new Wheel();
                base.wheels.Add(wheel);
            }
        }


        public override float getEnergy()
        {
            return m_engine.getEnergy();
        }

        public override string getAttributes()
        {
            return ("model name::string||air pressure wheels::int||is the truck transfer dangerous materials::bool||cargo volume::float||fuel or electric car::bool||maximum energy::float");
        }


        private void setIsTransferDangerousMaterials(bool i_isTransferDangerousMaterials)
        {
            m_isTransferDangerousMaterials = i_isTransferDangerousMaterials;
        }


        private void setCargoVolume(float i_cargoVolume)
        {
            m_cargoVolume = i_cargoVolume;
        }



        public override void setCarInitialState(string i_stringAttribute)
        {
            switch (m_indexSetupAttribute)
            {
                case (0):
                    this.setModelName(i_stringAttribute);
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
            else
            {
                //TODO : SENT WRONG ATTRIBUTE
            }
            m_indexSetupAttribute++;
        }

        public override void setCarInitialState(float i_floatAttribute)
        {
            if (m_indexSetupAttribute == 3)
            {
                setCargoVolume(i_floatAttribute);
            }
            else if (m_indexSetupAttribute == 5)
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
            if (m_indexSetupAttribute == 2)
            {
                setIsTransferDangerousMaterials(i_boolAttribute);
            }
            else if (m_indexSetupAttribute == 4)
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


   
