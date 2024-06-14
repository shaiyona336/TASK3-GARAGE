using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class Garage
    {
        List<GarageVehicleWithInformation> m_vehiclesInGarage;
        int m_indexSetupAttribute = 0; //with attribute for the last entered vehicle does the function needs now

        public string addVehicleToGarage(string i_licenseCar, string typeOfCar)
        {
            string i_argumentsToFillToInitializeVehicle = "car already in garage, moved to status: in-progress"; //default value if car is in the garage, if it is not, it will be changed to the arugments that we need to add to the new car
            GarageVehicleWithInformation i_carSameLicense;
            GarageVehicleWithInformation i_newCarWithInformation = null;
            Vehicle i_newCar;
            //check if license already exist
            i_carSameLicense = isCarLicenseInGarage(i_licenseCar);
            if (i_carSameLicense != null)
            {
                i_carSameLicense.setCarStatusInProgress();
            }
            else //if car not in garage, insert him
            {
                //TODO : add options for types of vehicles to create
                m_indexSetupAttribute = 0;
                i_newCar = new Car();
                i_newCarWithInformation = new GarageVehicleWithInformation();
                i_newCarWithInformation.setVehicle(i_newCar);
                i_argumentsToFillToInitializeVehicle = i_newCar.getAttributes();

                m_vehiclesInGarage.Insert(0, i_newCarWithInformation);

            }

            return i_argumentsToFillToInitializeVehicle;
        }

        public void setLastEnteredVehicle(string stringAttribute)
        {
            switch (m_indexSetupAttribute)
            {
                case (0):
                    m_vehiclesInGarage[0].setNameOfOwner(stringAttribute);
                    break;
                case (1):
                    m_vehiclesInGarage[0].setPhoneOfOwner(stringAttribute);
                    break;
                case (2):
                    m_vehiclesInGarage[0].setStatusCar(stringAttribute);
                    break;
                default:
                    m_vehiclesInGarage[0].getVehicle().setCarInitialState(stringAttribute);
                    //TODO : EXCEPTION SENT TOO MANY ATTRIBUTES
                    break;
            }
            m_indexSetupAttribute++;
        }

        public void setLastEnteredVehicle(int intAttribute)
        {
            m_indexSetupAttribute++;

        }

        public void setLastEnteredVehicle(bool boolAttribute)
        {
            m_indexSetupAttribute++;

        }

        private GarageVehicleWithInformation isCarLicenseInGarage(string carLicense) //return vehicle with information or null if not found
        {
            GarageVehicleWithInformation vehicleSameLicense = null;
            foreach (var i_vehicle in m_vehiclesInGarage)
            {
                if (i_vehicle.getVehicle().getLicensePlate() == carLicense)
                {
                    vehicleSameLicense = i_vehicle;
                }
            }
            return vehicleSameLicense;
        }
    }
}

    }


       