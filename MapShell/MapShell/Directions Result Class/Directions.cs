using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Drawing;
using System.IO;
using System;
using MapShell.StaticMap_Request_Classes;

namespace MapShell.Directions_Result_Class
{
    /// <summary>
    /// Base class for the mapquest json string.  It contains all nessesary data required for user.
    /// </summary>
    public class Directions
    {
        #region Variables
        /// <summary>
        /// Returns the calculated elapsed time in seconds for the route.
        /// </summary>
        public int time { get; set; }

        /// <summary>
        /// Returns the current Real Time
        /// </summary>
        public int realTime { get; set; }

        /// <summary>
        /// Returns the estimated amount of fuel used during the route.
        /// </summary>
        public double fuelUsed { get; set; }

        /// <summary>
        /// Returns the calculated distance of the route
        /// </summary>
        public double distance { get; set; }

        /// <summary>
        /// Returns true if at least one leg contains a Ferry attribute.  Otherwise it returns false.
        /// </summary>
        public bool hasFerry { get; set; }

        /// <summary>
        /// Returns true if at least one leg contains an Unpaved attribute, otherwise it returns false.
        /// </summary>
        public bool hasUnpaved { get; set; }

        /// <summary>
        /// Returns true if at least one leg has a Limited Access/Highway attribute, otherwise it returns false.
        /// </summary>
        public bool hasHighway { get; set; }

        /// <summary>
        /// Returns true if at least one leg contains a Toll Road attribute, otherwise it returns false.
        /// </summary>
        public bool hasTollRoad { get; set; }

        /// <summary>
        /// Returns true if at least one leg contains a Country Cross attribute, otherwise it returns false.
        /// </summary>
        public bool hasCountryCross { get; set; }

        /// <summary>
        /// Returns true if at least one leg contains a Seasonal Closure attribute, otherwise it returns false.
        /// </summary>
        public bool hasSeasonalClosure { get; set; }

        /// <summary>
        /// Storage used for storing the map returned from the Mapquest API.
        /// </summary>
        [JsonIgnore]    //Ignored because it is not a value in the json
        private StaticMap mapDetails_ { get; set; }

        /// <summary>
        /// Stores an instance of map_ to access the data.
        /// </summary>
        [JsonIgnore]    //Ignored because it is not a value in the json
        public StaticMap mapDetails
        {
            get
            {
                if (mapDetails_ == null)
                {
                    mapDetails_ = new StaticMap(sessionId, boundingBox, shape);
                }                    
                return mapDetails_;
            }
            set
            {
                mapDetails_ = value;
            }
        }

        /// <summary>
        /// 3.	Part of downloads process for the map and is the container for the map image.
        /// </summary>
        [JsonIgnore]    //Ignored because it is not a value in the json
        public Image mainMap
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

        /// <summary>
        /// Returns the unique identifier used to refer to a session.  
        /// An existingsession id will be used if provided, otherwise a new one will be created. 
        /// The route stored in the session will be automatically updated if the session id is provided. 
        /// Expires after 30 mins.
        /// </summary>
        public string sessionId { get; set; }

        /// <summary>
        /// Returns the calculated elapsed time as formatted text in HH:MM:SS format
        /// </summary>
        public string formattedTime { get; set; }

        /// <summary>
        /// A collaction of latlong coordinates or shape points for the entire route highlight based on original mapstate and/or the generalize option. 
        /// Shape is an alternated array of lat/lngs. 
        /// Evens are lat and odds are lng
        /// </summary>
        public Shape shape { get; set; }

        /// <summary>
        /// Returns routing options
        /// </summary>
        public Options options { get; set; }

        /// <summary>
        /// Returns lat.lng bounding rectangle of all points in the latlng collaction; Returns the bestfit for route shape.
        /// </summary>
        public BoundingBox boundingBox { get; set; }

        /// <summary>
        /// Returns a sequence array that can be used to determine the index in the original location object list.
        /// </summary>
        public List<int> locationSequence { get; set; }

        /// <summary>
        /// Returns a collection of leg objects, one for each "leg" of the route.
        /// </summary>
        public List<Leg> legs { get; set; }

        /// <summary>
        /// Returns a collection of locations in the form of an address.
        /// </summary>
        public List<Locations> locations { get; set; }
        #endregion

        public Directions()
        {
            //Default values for the mainMap
            //mapChanged = true;
            mapDetails = null;
            // Do not need to set mainMap because it is a value within map
            //and the rest of the values from the Result
            time = 0;
            realTime = 0;
            fuelUsed = 0.0;
            distance = 0.0;
            hasFerry = false;
            hasUnpaved = false;
            hasHighway = false;
            hasTollRoad = false;
            hasCountryCross = false;
            hasSeasonalClosure = false;
            sessionId = String.Empty;
            formattedTime = String.Empty;
            shape = new Shape();
            options = new Options();
            boundingBox = new BoundingBox();
            locationSequence = new List<int>();
            legs = new List<Leg>();
            locations = new List<Locations>();
        }

        public Image addHighlighting(List<LatLng> points, Color borderColor, Color fillColor, int lineWidth = 5)
        {
            mapDetails.polygon = new Polygon(borderColor, lineWidth, fillColor, points);
            return mainMap;
        }
    }
}