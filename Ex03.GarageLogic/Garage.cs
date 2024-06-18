using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.FuelEngine;

namespace Ex03.GarageLogic
{
    public sealed class Garage
    {
        List<GarageVehicleWithInformation> m_vehiclesInGarage;
        int m_indexSetupAttribute = 0; //with attribute for the last entered vehicle does the function needs now



        public string getInformationCarInGarage(GarageVehicleWithInformation i_carWithInformationWithSameLicense)
        {
            string i_informationCarInGarage = "";

            if (!(i_carWithInformationWithSameLicense == null))
            {
                i_informationCarInGarage = String.Format("name of owner: {0}\n" +
                    "phone of owner: {1}\n" +
                    "car status: {2}\n", i_carWithInformationWithSameLicense.getNameOwner(), i_carWithInformationWithSameLicense.getPhoneOwner(), i_carWithInformationWithSameLicense.getCarStatus());
            }
            else
            {
                //TODO : exception no car to get information to
            }

            return i_informationCarInGarage;
        }


        public string showInformationAboutCar(string licenseCarToShowInformationAbout)
        {
            string i_informationAboutCarInGarage;
            string i_insideCarInformationAboutHimself;
            string allInformationAboutCar = "";
            GarageVehicleWithInformation i_carWithInformationWithSameLicense;
            i_carWithInformationWithSameLicense = isCarLicenseInGarage(licenseCarToShowInformationAbout);

            if (licenseCarToShowInformationAbout == null)
            {
                allInformationAboutCar = "no such car";
            }
            else
            {
                i_informationAboutCarInGarage = getInformationCarInGarage(i_carWithInformationWithSameLicense);
                i_insideCarInformationAboutHimself = i_carWithInformationWithSameLicense.getVehicle().getInformationAboutCar();
                allInformationAboutCar = i_informationAboutCarInGarage + i_insideCarInformationAboutHimself;
            }

            return allInformationAboutCar; // need to return allInformationAboutCar
        }





        public void addElectricity(string i_licenseCarToAddAirPressureTo, float i_howMuchElectricityToAdd)
        {
            GarageVehicleWithInformation i_carWithInformationWithSameLicense = isCarLicenseInGarage(i_licenseCarToAddAirPressureTo);
            if (i_carWithInformationWithSameLicense == null)
            {
                //TODO :throw exception no car with such license found
            }
            else if (!(i_carWithInformationWithSameLicense.getVehicle().isElectricity()))
            {
                //TODO :throw exception car not run on electricity
            }
            else
            {
                i_carWithInformationWithSameLicense.getVehicle().addFuelOrElectricity(i_howMuchElectricityToAdd, ""); //no need to send the type of fuel in electricity car
            }
        }

        public void addFuel(string i_licenseCarToAddAirPressureTo, float i_howMuchFuelToAdd, string typeOfFuel)
        {
            GarageVehicleWithInformation i_carWithInformationWithSameLicense = isCarLicenseInGarage(i_licenseCarToAddAirPressureTo);
            if (i_carWithInformationWithSameLicense == null)
            {
                //TODO :throw exception no car with such license found
            }
            else if (!(i_carWithInformationWithSameLicense.getVehicle().isFuel()))
            {
                //TODO :throw exception car not run on electricity
            }
            else
            {
                i_carWithInformationWithSameLicense.getVehicle().addFuelOrElectricity(i_howMuchFuelToAdd, typeOfFuel);
            }
        }



        public void FillFullAirPressureInWheels(string i_licenseCarToAddAirPressureTo)
        {
            GarageVehicleWithInformation i_carWithInformationWithSameLicense = isCarLicenseInGarage(i_licenseCarToAddAirPressureTo);
            if (i_carWithInformationWithSameLicense == null)
            {
                //TODO :throw exception no car with such license found
            }
            else
            {
                i_carWithInformationWithSameLicense.FillWheelsPressure();
            }

        }

        public void changeStatusToCar(string i_licenseCarToChangeStatusTo, string i_newStatusOfCar)
        {
            GarageVehicleWithInformation i_carWithInformationWithSameLicense = isCarLicenseInGarage(i_licenseCarToChangeStatusTo);
            if (i_carWithInformationWithSameLicense == null)
            {
                //TODO :throw exception no car with such license found
            }
            else
            {
                if (i_newStatusOfCar != "INPROGRESS" && i_newStatusOfCar != "FIXED" && i_newStatusOfCar != "PAYED")
                {
                    //TODO : throw exception no such status to change to
                }
                i_carWithInformationWithSameLicense.setStatusCar(i_newStatusOfCar);
            }
        }



        public List<String> showAllLicenses(string i_typeOfCarStatusToShow)
        {
            List<String> allLicensesToShow;

            allLicensesToShow = new List<string>();
            foreach (GarageVehicleWithInformation carWithInformation in m_vehiclesInGarage)
            {
                if (carWithInformation.isCarCorrectStatusToShow(i_typeOfCarStatusToShow))
                {
                    allLicensesToShow.Add(carWithInformation.getVehicle().getLicensePlate());
                }
            }
            return allLicensesToShow;
        }


        public bool isCarInGarage(string i_licenseCar) //canAddCar
        {
            bool i_isVehicleExist = false;
            GarageVehicleWithInformation i_carSameLicense;
            //check if license already exist
            i_carSameLicense = isCarLicenseInGarage(i_licenseCar);
            if (i_carSameLicense != null)
            {
                i_carSameLicense.setCarStatusInProgress();
                i_isVehicleExist = true;
            }
            return i_isVehicleExist;
        }


        public string addVehicle(string typeOfCar)
        {
            Vehicle i_newCar;
            GarageVehicleWithInformation i_newCarWithInformation = null;
            string i_argumentsToFillToInitializeVehicle;

            m_indexSetupAttribute = 0; //reset m_indexSetupAttribute to enter the new vehicle
            i_newCar = makeNewCar.getVehicleFromString(typeOfCar);
            i_newCarWithInformation = new GarageVehicleWithInformation();
            i_newCarWithInformation.setVehicle(i_newCar);
            if (m_vehiclesInGarage == null)
            {
                m_vehiclesInGarage = new List<GarageVehicleWithInformation>();
            }
            m_vehiclesInGarage.Insert(0, i_newCarWithInformation);
            i_argumentsToFillToInitializeVehicle = i_newCar.getAttributes();
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
                case (3):
                    m_vehiclesInGarage[0].getVehicle().setLicensePlate(stringAttribute);
                    break;
                default:
                    m_vehiclesInGarage[0].getVehicle().setCarInitialState(stringAttribute);
                    break;
            }
            m_indexSetupAttribute++;
        }


        public void setLastEnteredVehicle(int intAttribute)
        {
            m_vehiclesInGarage[0].getVehicle().setCarInitialState(intAttribute);
            //no need to incress m_indexSetupAttribute because the attributes that the function initiallize is for each specific car not name/phone of owner or status car
        }

        public void setLastEnteredVehicle(float floatAttribute)
        {
            m_vehiclesInGarage[0].getVehicle().setCarInitialState(floatAttribute);
        }

        public void setLastEnteredVehicle(bool boolAttribute)
        {
            m_vehiclesInGarage[0].getVehicle().setCarInitialState(boolAttribute);
        }

        private GarageVehicleWithInformation isCarLicenseInGarage(string carLicense) //return vehicle with information or null if not found
        {
            GarageVehicleWithInformation vehicleSameLicense = null;
            if (m_vehiclesInGarage != null)
            {
                foreach (var i_vehicle in m_vehiclesInGarage)
                {
                    if (i_vehicle.getVehicle().getLicensePlate() == carLicense)
                    {
                        vehicleSameLicense = i_vehicle;
                    }
                }
            }
            return vehicleSameLicense;
        }
    }
}