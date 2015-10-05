using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapShell.Directions_Result_Class;
using MapShell.StaticMap_Request_Classes;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;

namespace MapShell.Directions_Request_Class
{
    abstract public class DirectionsRequest
    {
        public enum Avoids { LimitedAccess, TollRoad, SeasonalClosure, Unpaved, Ferry, CountryBorderCrossing };
        public enum RouteType { Fastest, Shortest, Pedestrian, Multimodal, Bicycle };
        public enum DrivingStyle { Normal, Cautious, Aggressive };
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locations"></param>
        /// <param name="routeType"></param>
        /// <param name="drivingStyle"></param>
        /// <param name="avoids"></param>
        /// <param name="enhancedNarrative"></param>
        /// <param name="metric"></param>
        /// <param name="fuelEfficiency"></param>
        /// <returns></returns>
        public static Directions getDirections(List<Locations> locations, StaticMap.MapType mapType, RouteType routeType = RouteType.Fastest, DrivingStyle drivingStyle = DrivingStyle.Normal, List<Avoids> avoids = null, bool enhancedNarrative = false, bool metric = false, int fuelEfficiency = 21)
        {
            if (locations.Count == 0)
                return new Directions();
            if (locations.Count == 1)
            {
                //Front end request an empty direction with the map of the location
                Directions d = new Directions();
                d.mainMap = locations[0].map;
                d.mapDetails = locations[0].mapDetails;
                d.mapDetails.mapType = mapType;
                d.legs.Add(new Leg());
                d.legs[0].maneuvers.Add(new Maneuver());
                return d;
            }
            WebClient w = new WebClient();
            string url = ConfigurationManager.AppSettings["MapQuestDirectionsURL"] + ConfigurationManager.AppSettings["MapQuestAPIKey"];
            if (avoids != null)
            {
                foreach (Avoids a in avoids)
                    switch (a)
                    {
                        case Avoids.CountryBorderCrossing:
                            url += "&avoids=Country border";
                            break;
                        case Avoids.Ferry:
                            url += "&avoids=Ferry";
                            break;
                        case Avoids.LimitedAccess:
                            url += "&avoids=Limited Access";
                            break;
                        case Avoids.SeasonalClosure:
                            url += "&avoids=Approximate Seasonal Closure";
                            break;
                        case Avoids.TollRoad:
                            url += "&avoids=Toll road";
                            break;
                        case Avoids.Unpaved:
                            url += "&avoids=Unpaved";
                            break;
                        default:
                            break;
                    }
            }
            url += "&outFormat=json";
            switch (routeType)
            {
                case RouteType.Fastest:
                    url += "&routeType=fastest";
                    break;
                case RouteType.Shortest:
                    url += "&routeType=shortest";
                    break;
                case RouteType.Pedestrian:
                    url += "&routeType=pedestrian";
                    break;
                case RouteType.Bicycle:
                    url += "&routeType=bicycle";
                    break;
                case RouteType.Multimodal:
                    url += "&routeType=multimodal";
                    break;
                default:
                    url += "&routeType=fastest";
                    break;
            }
            url += "&timeType=1";
            url += (enhancedNarrative ? "&enhancedNarrative=true" : "&enhancedNarrative=false");
            url += "&shapeFormat=raw&generalize=0";
            url += ConfigurationManager.AppSettings["MapQuestDirectionsLocale"];
            url += (metric ? "&unit=k" : "&unit=m");
            for (int i = 1; i < locations.Count; ++i)
            {
                url += ("&from=" + locations[i - 1].latLng.lat + ',' + locations[i - 1].latLng.lng
                    + "&to=" + locations[i].latLng.lat + ',' + locations[i].latLng.lng);
            }
            url += "&drivingStyle=";
            switch (drivingStyle)
            {
                case DrivingStyle.Aggressive:
                    url += "3";
                    break;
                case DrivingStyle.Cautious:
                    url += "1";
                    break;
                case DrivingStyle.Normal:
                    url += "2";
                    break;
                default:
                    url += "2";
                    break;
            }
            url += "&highwayEfficiency=" + fuelEfficiency;
            JsonSerializerSettings s = new JsonSerializerSettings();
            s.NullValueHandling = NullValueHandling.Ignore;
            s.ObjectCreationHandling = ObjectCreationHandling.Replace;
            Directions result = JsonConvert.DeserializeObject<DirectionsRootObject>(w.DownloadString(url), s).route;
            result.mapDetails.mapType = mapType;
            return result;
        }
    }
}
