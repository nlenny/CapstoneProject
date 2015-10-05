using MapShell.Directions_Result_Class;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MapShell.Directions_Request_Class
{
    public class Address
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }

        public Address()
        {
            street = String.Empty;
            city = String.Empty;
            state = String.Empty;
            postalCode = String.Empty;
        }

        public Address(string _street = "", string _city = "", string _state = "", string _postalCode = ""){
            street = _street;
            city = _city;
            state = _state;
            postalCode = _postalCode;
        }

        public async Task<List<Locations>> getLocations()
        {
            System.Net.WebClient w = new System.Net.WebClient();
            //tsage modified on 4/2 for the circular progress bar. This helps makes the method run asynchronously, thus allowing the loading icon to work!
            string json = "";
            try
            {
                json = await Task.Run(() => w.DownloadString(ConfigurationManager.AppSettings["MapQuestGeocodingURL"]
                + ConfigurationManager.AppSettings["MapQuestAPIKey"]
                + "&street=" + street + "&city=" + city + "&state=" + state + "&postalCode=" + postalCode));
            }
            catch (Exception)
            {
                return new List<Locations>();
            }            
            LocationsRootObject result = JsonConvert.DeserializeObject<LocationsRootObject>(json);  
            return (result.results.Count > 0 ? result.results[0].locations : new List<Locations>());
        }
    }
}