using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class GarageVehicleWithInformation
    {
        enum carStatus
        {
            INPROGRESS,
            FIXED,
            PAYED
        }
        private Vehicle m_vehicle;
        private string m_nameOfOwner;
        private string m_phoneOfOwner;
        private carStatus m_statusCar;

        public Vehicle getVehicle()
        {
            return m_vehicle;
        }

        public bool isCarCorrectStatusToShow(string i_carStatus)
        {
            bool i_flag = false;
            
            switch(i_carStatus)
            {
                case ("INPROGRESS"):
                    if (m_statusCar == carStatus.INPROGRESS)
                    {
                        i_flag = true;
                    }
                    break;
                case ("FIXED"):
                    if (m_statusCar == carStatus.FIXED)
                    {
                        i_flag = true;
                    }
                    break;
                case ("PAYED"):
                    if (m_statusCar == carStatus.PAYED)
                    {
                        i_flag = true;
                    }
                    break;
                case ("ANY"):
                    i_flag = true;
                    break;
                default:
                    //TODO : exception no such car status
                    break;
            }

            return i_flag;
                 
        }

        public void setStatusCar(string i_statusCar)
        {
            switch (i_statusCar)
            {
                case ("INPROGRESS"):
                    m_statusCar = carStatus.INPROGRESS;
                    break;
                case ("FIXED"):
                    m_statusCar = carStatus.FIXED;
                    break;
                case ("PAYED"):
                    m_statusCar = carStatus.PAYED;
                    break;
                default:
                    //TODO : exception no such status
                    break;
            }
        }

        public void setVehicle(Vehicle i_vehicle)
        {
            m_vehicle = i_vehicle;
        }

        public void setNameOfOwner(string i_nameOfOwner)
        {
            m_nameOfOwner = i_nameOfOwner;
        }

        public void setPhoneOfOwner(string i_phoneOfOwner)
        {
            m_phoneOfOwner = i_phoneOfOwner;
        }

        public void setCarStatusInProgress()
        {
            m_statusCar = carStatus.INPROGRESS;
        }
    }
}
