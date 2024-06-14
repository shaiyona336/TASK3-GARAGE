using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public sealed class Garage
    {
        List<GarageVehicleWithInformation> m_vehiclesInGarage;

        public GarageVehicleWithInformation addVehicleToGarage(string i_licenseCar)
        {
            GarageVehicleWithInformation i_carSameLicense;
            GarageVehicleWithInformation i_newCar = null;
            //check if license already exist
            i_carSameLicense = isCarLicenseInGarage(i_licenseCar);
            if (i_carSameLicense != null)
            {
                i_carSameLicense.setCarStatusInProgress();
            }
            else //if car not in garage, insert him
            {
                i_newCar = new GarageVehicleWithInformation();
                m_vehiclesInGarage.Add(i_carSameLicense);
            }

            return i_newCar;
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
