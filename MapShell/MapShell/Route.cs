using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell
{

    class Route
    {
        private List<string> Addresses;
        public List<string> Maneuvers;
        public string MapUrl;
        public int TollRoads;
        public double TotalDistance;
        public int NumberOfTollRoads;
        public string StartAddress;
        public string EndAddress;
        public string EstimatedTravelTime;
        public int TravelTime;

        //public List<string> ListOfManeuvers;
        
        //public void giveCommand(){}
        

        //these may not be needed
        //public List<string> getAddresses(){return addresses; }
        //public void setAddresses(List<string> Adresses) { addresses = Adresses; }
        
        //public string getMapUrl(){ return MapUrl;}
        //public void setMapUrl(string url) { MapUrl = url; }

        //public double getTotalDistance() { return totalDistance; }
        //public void setTotalDistance(double miles) { totalDistance = miles; }

        //public string getEndAddress() { return endAddress; }
        //public void setEndAddress(string endaddresses) { endAddress = endaddresses; }

        //public int getTollRoads() { return tollRoads; }
        //public void setTollRoads(int numberOfTollRoads) { tollRoads = numberOfTollRoads; }

        //public string getStartAddress() { return startAddress; }
        //public void setStartAddress(string address) { startAddress = address; }

        //public int getTravelTime() { return travelTime; }
        //public void setTravelTime(int traveltime) { travelTime = traveltime; }

        //public List<string> getListOfManeuvers() { return listOfManeuvers; }
        //public void setListOfManeuvers(List<string> maneuvers) { listOfManeuvers = maneuvers; }
         
    }
}
