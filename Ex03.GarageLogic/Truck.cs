using System;
using System.Collections.Generic;
using System.Runtime;

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
            initializeWheels(m_numberOfWheels);
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
                    "is truck transfer dangerous materials: {4}\n" +
                    "cargo volume: {5}\n" +
                    "how much fuel: {6}\n" +
                    "type of fuel: {7}\n" +
                    "maximum amount of fuel: {8}\n", getModelName(), getAirPressureInWheels(), getMaximumAirPressureInWheels(), getWheeslManufactorName(), m_isTransferDangerousMaterials, m_cargoVolume, m_engine.getEnergy(), (m_engine as FuelEngine).getTypeOfFuel(), m_engine.getMaximumEnergy());
            }
            else //car on electric engine
            {
                i_informationAboutCar = String.Format("model name: {0}\n" +
                     "air pressure in wheels: {1}\n" +
                     "maximum air pressure in wheels: {2}\n" +
                     "manufactor name of wheels: {3}\n" +
                     "is truck transfer dangerous materials: {4}\n" +
                     "cargo volume: {5}\n" +
                     "how much hours for battery: {6}\n" +
                     "maximum amount of hours for battery: {7}\n", getModelName(), getAirPressureInWheels(), getMaximumAirPressureInWheels(), getWheeslManufactorName(), m_isTransferDangerousMaterials, m_cargoVolume, m_engine.getEnergy(),  m_engine.getMaximumEnergy());
            }

            return i_informationAboutCar;
        }


        public override string getAttributes()
        {
            return ("model name::string||maximum air pressure wheels::float||air pressure in wheels::float||manufactor name of wheels::string||is the truck transfer dangerous materials::bool||cargo volume::float||is car on fuel::bool||maximum energy::float");
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
                case (3):
                    setWheelsManufactorName(i_stringAttribute);
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
           //TODO : SENT WRONG ATTRIBUTE
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
            else if (m_indexSetupAttribute == 5)
            {
                setCargoVolume(i_floatAttribute);
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
            if (m_indexSetupAttribute == 4)
            {
                setIsTransferDangerousMaterials(i_boolAttribute);
            }
            else if (m_indexSetupAttribute == 6)
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


   
