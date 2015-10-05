using System;
using System.IO;
using System.Net;
using System.Drawing;
using Newtonsoft.Json;
using System.Collections.Generic;
using MapShell.StaticMap_Request_Classes;

namespace MapShell.Directions_Result_Class
{
    //Link for api reference: open.mapquestapi.com/geocoding/
    //see geocoding response: multiple addributes

    /// <summary>
    /// Contains data nessessary to store Addresses.
    /// </summary>
    public class Locations
    {
        #region Variables
        /// <summary>
        /// Returns linkId
        /// </summary>
        public string linkId { get; set; }

        /// <summary>
        /// Returns whether or not the point is a drag point.
        /// True: Location is a drag point
        /// False: Location is not a drag point
        /// </summary>
        public bool dragPoint { get; set; }

        /// <summary>
        /// Returns type of location.
        /// s = stop(default)
        /// v = via
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Returns Street Address
        /// </summary>
        public string street { get; set; }

        /// <summary>
        /// Returns Country Name
        /// </summary>
        [JsonProperty("adminArea1")]
        public string countryName { get; set; }

        /// <summary>
        /// Returns State Name
        /// </summary>
        [JsonProperty("adminArea3")]
        public string stateName { get; set; }

        /// <summary>
        /// Returns County Name
        /// </summary>
        [JsonProperty("adminArea4")]
        public string countyName { get; set; }

        /// <summary>
        /// Returns City Name
        /// </summary>
        [JsonProperty("adminArea5")]
        public string cityName { get; set; }

        /// <summary>
        /// Returns Postal Code
        /// </summary>
        public string postalCode { get; set; }

        /// <summary>
        /// Specifies the side of the street:
        /// L = left
        /// R = right
        /// N = none (default)
        /// </summary>
        public string sideOfStreet { get; set; }

        /// <summary>
        /// Returns Country Name Type
        /// </summary>
        [JsonProperty("adminArea1Type")]
        public string countryNameType { get; set; }

        /// <summary>
        /// Returns City Name Type
        /// </summary>
        [JsonProperty("adminArea5Type")]
        public string cityNameType { get; set; }

        /// <summary>
        /// Returns County Name Type
        /// </summary>
        [JsonProperty("adminArea4Type")]
        public string countyNameType { get; set; }

        /// <summary>
        /// Returns the precision of the geocoded location.
        /// </summary>
        public string geocodeQuality { get; set; }

        /// <summary>
        /// Returns the five character quality code for the precision of the geocoded location.
        /// </summary>
        public string geocodeQualityCode { get; set; }

        /// <summary>
        /// Returns State Name Type
        /// </summary>
        [JsonProperty("adminArea3Type")]
        public string stateNameType { get; set; }

        /// <summary>
        /// Longitude and Latitude ADT class.
        /// </summary>
        [JsonProperty("latLng")]
        public LatLng latLng { get; set; }

        /// <summary>
        /// A lat/lng pair that can be helpful when showing this address as a Point of Interest
        /// </summary>
        [JsonProperty("displayLatLng")]
        public LatLng displayLatLng { get; set; }
        [JsonIgnore]
        private StaticMap mapDetails_ { get; set; }
        [JsonIgnore]
        public StaticMap mapDetails
        {
            get
            {
                if (mapDetails_ == null)
                {
                    mapDetails_ = new StaticMap(displayLatLng);
                }
                return mapDetails_;
            }
            set
            {
                mapDetails_ = value;
            }
        }
        [JsonIgnore]
        public Image map
        {
            get
            {
                return mapDetails.map;
            }
            set
            {
                mapDetails.map = value;
            }
        }
        #endregion

        public Locations()
        {
            mapDetails_ = null;
            linkId = String.Empty;
            dragPoint = false;
            type = String.Empty;
            street = String.Empty;
            countryName = String.Empty;
            stateName = String.Empty;
            countyName = String.Empty;
            cityName = String.Empty;
            postalCode = String.Empty;
            sideOfStreet = String.Empty;
            countryNameType = String.Empty;
            cityNameType = String.Empty;
            countyNameType = String.Empty;
            geocodeQuality = String.Empty;
            geocodeQualityCode = String.Empty;
            stateNameType = String.Empty;
            latLng = new LatLng();
            displayLatLng = new LatLng();
        }
    }
}