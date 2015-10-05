using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System;

namespace MapShell.Directions_Result_Class
{/// <summary>
    /// Manuevers Describes one step in a route narrative.
    /// </summary>
    public class Maneuver
    {
        #region Enums
        /// <summary>
        /// Possible attributes a given maneuver can have.
        /// </summary>
        public enum Attributes { none = 0, portionsToll = 1, portionsUnpaved = 2, possibleSeasonalRoadClosure = 4,
            gate = 8, ferry = 16, avoidId= 32, countryCrossing = 64, limitedCccessHighways = 128}

        /// <summary>
        /// Possibles directions a given manuever can go.
        /// </summary>
        public enum Direction { none = 0, north = 1, northwest = 2, northeast = 3, south = 4, southeast = 5, southwest = 6, west = 7, east = 8 }

        /// <summary>
        /// Possible types of turns a given maneuver can have.
        /// </summary>
        public enum TurnType { straight = 0, slightRight = 1, right = 2, sharpRight = 3, reverse = 4, sharpLeft = 5,
            left = 6, slightLeft = 7, rightUturn = 8, leftUturn =9, rightMerge =10, leftMerge = 11, rightOnRamp = 12,
            leftOnRamp = 13, rightOffRamp = 14, leftOffRamp = 15, rightFork = 16, leftFork = 17, straightFork = 18}
        #endregion

        #region Variables
        /// <summary>
        /// Returns calculated elapsed time in seconds for maneuver.
        /// </summary>
        public int time { get; set; }

        /// <summary>
        /// Returns the current maneuver position in the index list of maneuvers.
        /// </summary>
        public int index { get; set; }        

        /// <summary>
        /// Returns the calculated distance of this maneuver.
        /// </summary>
        public double distance { get; set; }
        [JsonIgnore]
        public Image map
        {
            get
            {
                if (map_ == null)
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(mapUrl);
                    HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    Stream stream = httpWebReponse.GetResponseStream();
                    map_ = Image.FromStream(stream);
                    httpWebReponse.Dispose();
                }
                return map_;
            }
            set
            {
                map_ = value;
            }
        }
        [JsonIgnore]
        private Image map_ { get; set; }
        /// <summary>
        /// Returns a URL to a static map of this maneuver.
        /// </summary>
        public string mapUrl { get; set; }

        /// <summary>
        /// Returns a URL of the icon of this maneuver.
        /// </summary>
        public string iconUrl { get; set; }

        /// <summary>
        /// Returns textual driving directions for a particular maneuver.
        /// </summary>
        public string narrative { get; set; }

        /// <summary>
        /// This is a string indicating the mode of transportation used for the maneuver.
        /// Values include:
        /// AUTO
        /// WALKING
        /// BICYCLE
        /// RAIL
        /// BUS
        /// </summary>
        public string transportMode { get; set; }

        /// <summary>
        /// Returns the calculated elapsed time as formatted text in HH:MM:SS format
        /// </summary>
        public string formattedTime { get; set; }

        /// <summary>
        /// Returns the direction name.
        /// </summary>
        public string directionName { get; set; }

        /// <summary>
        /// Returns the type associated to a particular maneuver. 
        /// Possible return values are:
        /// straight = 0
        /// slight right = 1
        /// right = 2
        /// sharp right = 3
        /// reverse = 4
        /// sharp left = 5
        /// left = 6
        /// slight left = 7
        /// right u-turn = 8
        /// left u-turn = 9
        /// right merge = 10
        /// left merge = 11
        /// right on ramp = 12
        /// left on ramp  13
        /// right off ramp = 14
        /// left off ramp = 15
        /// right  fork = 16
        /// left fork = 17
        /// straight fork = 18
        /// </summary>
        public Maneuver.TurnType turnType { get; set; }

        /// <summary>
        /// Returns the direction associated to a particular maneuver.
        /// Possible return values are:
        /// none = 0
        /// north = 1
        /// northwest = 2
        /// northeast = 3
        /// south = 4
        /// southeast = 5
        /// southwest = 7
        /// west = 7
        /// east = 8
        /// </summary>
        public Maneuver.Direction direction { get; set; }

        /// <summary>
        /// Returns the attributes associated to a particular maneuver.
        /// Possible return values are:
        /// none = 0
        /// portions toll = 1
        /// portions unpaved = 2
        /// possible seasonal road closure = 4
        /// gate = 8
        /// ferry = 16
        /// avoid id = 32
        /// country crossing = 64
        /// limited access (highways) = 128
        /// </summary>
        public Maneuver.Attributes attributes { get; set; }

        /// <summary>
        /// Returns the 1st shape point latLng for a particular maneuver.
        /// This will allow for zoomed street functionality for a maneuver.
        /// </summary>
        public LatLng startPoint { get; set; }

        /// <summary>
        /// Returns text name, extra text, type(road shield) and direction present for a particular maneuver.
        /// Also returns the URL for the sign images.
        /// </summary>
        public List<Sign> signs { get; set; }

        /// <summary>
        /// Returns a list of linkIds
        /// </summary>
        public List<int> linkIds { get; set; }

        /// <summary>
        /// Returns the collection of sto. names this maneuver applies treet
        /// </summary>
        public List<string> streets { get; set; }

        /// <summary>
        /// Returns the maneuver note for a particular maneuver. Maneuver notes can exist for Timed Turn Restrictions, 
        /// Timed Access Roads, HOV Roads, Seasonal Closures, and Timed Direction of Travel.  
        /// Note: When the enhanced Narrative flag is set to true additional maneuver notes may be displayed.
        /// </summary>
        public List<string> maneuverNotes { get; set; }
        #endregion

        public Maneuver()
        {
            map_ = null; 

            time = 0;
            index = 0;
            turnType = 0;
            direction = 0;
            attributes = 0;
            distance = 0.0;
            mapUrl = String.Empty;
            iconUrl = String.Empty;
            narrative = String.Empty;
            transportMode = String.Empty;
            formattedTime = String.Empty;
            directionName = String.Empty;
            startPoint = new LatLng();
            signs = new List<Sign>();
            linkIds = new List<int>();
            streets = new List<string>();
            maneuverNotes = new List<string>();
        }
    }
}