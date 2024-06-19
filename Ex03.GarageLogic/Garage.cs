using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class Garage
    {
        private List<GarageVehicleWithInformation> m_VehiclesInGarage;
        private int m_IndexSetupAttribute = 0; //with attribute for the last entered vehicle does the function needs now

        public string GetInformationCarInGarage(GarageVehicleWithInformation i_CarWithInformationWithSameLicense)
        {
            string informationCarInGarage = "";

            if (i_CarWithInformationWithSameLicense != null)
            {
                informationCarInGarage = String.Format("name of owner: {0}\n" +
                    "phone of owner: {1}\n" +
                    "car status: {2}\n", i_CarWithInformationWithSameLicense.GetNameOwner(), i_CarWithInformationWithSameLicense.GetPhoneOwner(), i_CarWithInformationWithSameLicense.GetCarStatus());
            }
            else
            {
                throw new ArgumentException("No Vehicle to get information from");
            }

            return informationCarInGarage;
        }

        public string ShowInformationAboutCar(string i_LicenseCarToShowInformationAbout)
        {
            string informationAboutCarInGarage;
            string insideCarInformationAboutHimself;
            string allInformationAboutCar;
            GarageVehicleWithInformation carWithInformationWithSameLicense;
            carWithInformationWithSameLicense = IsCarLicenseInGarage(i_LicenseCarToShowInformationAbout);

            if (i_LicenseCarToShowInformationAbout == null)
            {
                allInformationAboutCar = "no such car";
            }
            else
            {
                informationAboutCarInGarage = GetInformationCarInGarage(carWithInformationWithSameLicense);
                insideCarInformationAboutHimself = carWithInformationWithSameLicense.GetVehicle().GetInformationAboutCar();
                allInformationAboutCar = informationAboutCarInGarage + insideCarInformationAboutHimself;
            }

            return allInformationAboutCar; // need to return allInformationAboutCar
        }

        public void AddElectricity(string i_LicenseCarToAddAirPressureTo, float i_HowMuchElectricityToAdd)
        {
            GarageVehicleWithInformation carWithInformationWithSameLicense = IsCarLicenseInGarage(i_LicenseCarToAddAirPressureTo);
            if (carWithInformationWithSameLicense == null)
            {
                throw new KeyNotFoundException("No vehicle with that license was found in the garage");
            }
            else if (!(carWithInformationWithSameLicense.GetVehicle().IsElectricity()))
            {
                throw new InvalidOperationException("Vehicle does not run on electricity");
            }
            else
            {
                carWithInformationWithSameLicense.GetVehicle().AddFuelOrElectricity(i_HowMuchElectricityToAdd, ""); //no need to send the type of fuel in electricity car
            }
        }

        public void AddFuel(string i_LicenseCarToAddAirPressureTo, float i_HowMuchFuelToAdd, string i_TypeOfFuel)
        {
            GarageVehicleWithInformation carWithInformationWithSameLicense = IsCarLicenseInGarage(i_LicenseCarToAddAirPressureTo);
            if (carWithInformationWithSameLicense == null)
            {
                throw new KeyNotFoundException("No vehicle with that license was found in the garage");
            }
            else if (!(carWithInformationWithSameLicense.GetVehicle().IsFuel()))
            {
                throw new InvalidOperationException("Vehicle does not run on electricity");
            }
            else
            {
                carWithInformationWithSameLicense.GetVehicle().AddFuelOrElectricity(i_HowMuchFuelToAdd, i_TypeOfFuel);
            }
        }

        public void FillFullAirPressureInWheels(string i_LicenseCarToAddAirPressureTo)
        {
            GarageVehicleWithInformation carWithInformationWithSameLicense = IsCarLicenseInGarage(i_LicenseCarToAddAirPressureTo);
            if (carWithInformationWithSameLicense == null)
            {
                throw new KeyNotFoundException("No vehicle with that license was found in the garage");
            }
            else
            {
                carWithInformationWithSameLicense.FillWheelsPressure();
            }
        }

        public void ChangeStatusToCar(string i_LicenseCarToChangeStatusTo, string i_NewStatusOfCar)
        {
            GarageVehicleWithInformation carWithInformationWithSameLicense = IsCarLicenseInGarage(i_LicenseCarToChangeStatusTo);
            if (carWithInformationWithSameLicense == null)
            {
                throw new ArgumentException("No vehice with that license was found in the garage",
             nameof(carWithInformationWithSameLicense));
            }
            else
            {
                if (i_NewStatusOfCar != "INPROGRESS" && i_NewStatusOfCar != "FIXED" && i_NewStatusOfCar != "PAYED")
                {
                    throw new ArgumentException($"\"{i_NewStatusOfCar}\" is not a valid status", nameof(i_NewStatusOfCar));
                }
                carWithInformationWithSameLicense.SetStatusCar(i_NewStatusOfCar);
            }
        }

        public List<string> ShowAllLicenses(string i_TypeOfCarStatusToShow)
        {
            List<string> allLicensesToShow = new List<string>();

            foreach (GarageVehicleWithInformation carWithInformation in m_VehiclesInGarage)
            {
                if (carWithInformation.IsCarCorrectStatusToShow(i_TypeOfCarStatusToShow))
                {
                    allLicensesToShow.Add(carWithInformation.GetVehicle().GetLicensePlate());
                }
            }
            return allLicensesToShow;
        }

        public bool IsCarInGarage(string i_LicenseCar) //canAddCar
        {
            bool isVehicleExist = false;
            GarageVehicleWithInformation carSameLicense;
            //check if license already exist
            carSameLicense = IsCarLicenseInGarage(i_LicenseCar);
            if (carSameLicense != null)
            {
                carSameLicense.SetCarStatusInProgress();
                isVehicleExist = true;
            }
            return isVehicleExist;
        }

        public string AddVehicle(string i_TypeOfVehicle)
        {
            Vehicle newVehicle;
            GarageVehicleWithInformation newCarWithInformation = null;
            string argumentsToFillToInitializeVehicle;

            m_IndexSetupAttribute = 0; //reset m_indexSetupAttribute to enter the new vehicle
            newVehicle = MakeNewCar.GetVehicleFromString(i_TypeOfVehicle);
            newCarWithInformation = new GarageVehicleWithInformation();
            newCarWithInformation.SetVehicle(newVehicle);
            if (m_VehiclesInGarage == null)
            {
                m_VehiclesInGarage = new List<GarageVehicleWithInformation>();
            }
            m_VehiclesInGarage.Insert(0, newCarWithInformation);
            argumentsToFillToInitializeVehicle = newVehicle.GetAttributes();
            return argumentsToFillToInitializeVehicle;
        }

        public void SetLastEnteredVehicle(string i_StringAttribute)
        {
            switch (m_IndexSetupAttribute)
            {
                case 0:
                    m_VehiclesInGarage[0].SetNameOfOwner(i_StringAttribute);
                    break;
                case 1:
                    m_VehiclesInGarage[0].SetPhoneOfOwner(i_StringAttribute);
                    break;
                case 2:
                    m_VehiclesInGarage[0].GetVehicle().SetLicensePlate(i_StringAttribute);
                    break;
                default:
                    m_VehiclesInGarage[0].GetVehicle().SetCarInitialState(i_StringAttribute);
                    break;
            }
            m_IndexSetupAttribute++;
        }

        public void SetLastEnteredVehicle(int i_IntAttribute)
        {
            m_VehiclesInGarage[0].GetVehicle().SetCarInitialState(i_IntAttribute);
            //no need to increase m_indexSetupAttribute because the attributes that the function initialize is for each specific car not name/phone of owner or status car
        }

        public void SetLastEnteredVehicle(float i_FloatAttribute)
        {
            m_VehiclesInGarage[0].GetVehicle().SetCarInitialState(i_FloatAttribute);
        }

        public void SetLastEnteredVehicle(bool i_BoolAttribute)
        {
            m_VehiclesInGarage[0].GetVehicle().SetCarInitialState(i_BoolAttribute);
        }

        private GarageVehicleWithInformation IsCarLicenseInGarage(string i_CarLicense) //return vehicle with information or null if not found
        {
            GarageVehicleWithInformation vehicleSameLicense = null;
            if (m_VehiclesInGarage != null)
            {
                foreach (var vehicle in m_VehiclesInGarage)
                {
                    if (vehicle.GetVehicle().GetLicensePlate() == i_CarLicense)
                    {
                        vehicleSameLicense = vehicle;
                    }
                }
            }
            return vehicleSameLicense;
        }
    }
}
