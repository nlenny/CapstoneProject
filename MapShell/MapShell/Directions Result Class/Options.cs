using System;
using System.Collections.Generic;

namespace MapShell.Directions_Result_Class
{
    //Link for api reference: open.mapquestapi.com/directions
    //see route response: options attribute and others listed below

    /// <summary>
    /// Options for routing
    /// </summary>
    public class Options
    {
        #region Variables
        /// <summary>
        /// Returns the time Type.
        /// Current time or custom time.
        /// </summary>
        public int timeType { get; set; }

        /// <summary>
        /// Returns maxLink Id.
        /// </summary>
        public int maxLinkId { get; set; }

        /// <summary>
        /// Returns generalization factor.
        /// If there is no mapState and fullShape = false, then the specified generalization factor will be used to generalize the shape.
        /// If the generalize parameter is 0, then no shape simplification will be done and all shape points will be returned.
        /// if the generalize parameter is greater than 0, it will be used as the tolerance distance (in meters) in the Douglas-Peucker Algorithm for line simplification.
        /// Higher values of generalize will result in fewer points in the final route shape.
        /// </summary>
        public int generalize { get; set; }

        /// <summary>
        /// Return route number
        /// </summary>
        public int routeNumber { get; set; }

        /// <summary>
        /// Returns driving style to be used when calculating fuel usage.
        /// 1 -> cautious - Assume a cautious driving style
        /// 2 -> normal - Assume a normal driving style. This is the default.
        /// 3 -> aggressive - Assume an aggressive driving style.
        /// </summary>
        public int drivingStyle { get; set; }

        /// <summary>
        /// Returns speed allowed for walking in mph.
        /// </summary>
        public int walkingSpeed { get; set; }
        
        /// <summary>
        /// Returns transfer Penalty
        /// </summary>
        public int transferPenalty { get; set; }

        /// <summary>
        /// Returns maneuver Penalty
        /// </summary>
        public int maneuverPenalty { get; set; }

        /// <summary>
        /// Returns avoid urban factor
        /// </summary>
        public int urbanAvoidFactor { get; set; }

        /// <summary>
        /// Returns the response as a part of the options and represents an internal route option used in alternate routes.  
        /// It cannot be set as an input by the application but can be used to differentiate 2 alternate route results.
        /// </summary>
        public int filterZoneFactor { get; set; }

        /// <summary>
        /// This is the fuel efficiency of your vehicle, given as miles per gallon. Valid range is 0-235 mpg.  
        /// If a value is entered that is less than the minimum range, then 0 will be used.  
        /// If a value is entered that is greater than the maximum range, then 235 will be used.
        /// </summary>
        public int highwayEfficiency { get; set; }

        /// <summary>
        /// Returns the cycling road favoring factor.  
        /// A value of less than 1 favors cycling on non-bike lange roads. 
        /// Values are clamped to the range 0.1 to 100.0
        /// Default = 1.0
        /// </summary>
        public int cyclingRoadFactor { get; set; }
        
        /// <summary>
        /// Returns maximum Walking Distance.
        /// </summary>
        public int maxWalkingDistance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool useTraffic { get; set; }

        /// <summary>
        /// Enhanced Narrative Option. This option will generate an enhanced narrative for Route & Alternate Route Services.
        /// This will encompass Intersection Counts, Previous Intersection and Next Intersection/ Gone too Far advice.
        /// false - no intersection counts
        /// true - interesection counts
        /// </summary>
        public bool enhancedNarrative { get; set; }

        /// <summary>
        /// Returns side of street to be displayed.
        /// </summary>
        public bool sideOfStreetDisplay { get; set; }

        /// <summary>
        /// Returns Link Directions
        /// </summary>
        public bool returnLinkDirections { get; set; }

        /// <summary>
        /// Returns avoid Timed Conditions
        /// </summary>
        public bool avoidTimedConditions { get; set; }

        /// <summary>
        /// Returns State boundary display option.
        /// True - State boundary crossing will be displayed in narrative.
        /// False - State boundary crossing will not be displayed in narrative.
        /// </summary>
        public bool stateBoundaryDisplay { get; set; }

        /// <summary>
        /// 
        /// Returns Country boundary display option.
        /// True - Country boundary crossing will be displayed in narrative.
        /// False - Country boundary crossing will not be displayed in narrative.
        /// </summary>
        public bool countryBoundaryDisplay { get; set; }

        /// <summary>
        /// Returns the End at Desination maneuver display option.
        /// true - the End at destination maneuver is displayed in narrative.
        /// false - the End at destination maneuver is not displayed in narrative
        /// </summary>
        public bool destinationManeuverDisplay { get; set; }

        /// <summary>
        /// Returns Specifirs the type of units to use when calculating distance.
        /// </summary>
        public string unit { get; set; }

        /// <summary>
        /// Returns language to use in the narrative.
        /// </summary>
        public string locale { get; set; }

        /// <summary>
        /// Maneuver maps display option
        /// True - A small staticmap is displayed per maneuver with the route shape of that maneuver. The route response will return a mapUrl
        /// False - A small static map is not displayed per maneuver.
        /// </summary>
        public bool manmaps { get; set; }

        /// <summary>
        /// Returns the Type of Route
        /// fastest - Quickest drive time route.
        /// shortest - Shortest driving distance route.
        /// pedestrain - Walking route.
        /// multimodal - Combination of walking and Public Transit.
        /// bicycle - Bike route.
        /// </summary>
        public string routeType { get; set; }

        /// <summary>
        /// Returns shape format options:
        /// raw - shape is represented as float pairs
        /// cmp - shape is represented as a compressed path string.
        /// none - no shape will be returned. In this case, the generalize parameter will be ignored.
        /// </summary>
        public string shapeFormat { get; set; }

        /// <summary>
        /// Specifies the type of narrative to generate.
        /// none - No narrative is generated
        /// text - Standard text narrative
        /// html - adds some HTML tags to the standard text
        /// microformat - Uses HTML span tags with class attributes to allow parts of the narrative to be easily styled via CSS.
        /// </summary>
        public string narrativeType { get; set; }

        /// <summary>
        /// Returns attribute ids of roads to try to avoid.  The avaible attribute flags depend on the data set.
        /// This does not guarantee roads with these attributes will be avoided if alternate route paths are too lengthy or 
        /// not possible or roads that contain these atrributes are very short. 
        /// </summary>
        public List<int> avoidTripIds { get; set; }

        /// <summary>
        /// Returns link Ids of roads that will beabsolutely avoided. May cause some routes to fail.
        /// </summary>
        public List<int> mustAvoidLinkIds { get; set; }

        /// <summary>
        /// Returns link Ids of raods that we will try to avoid during route calculation. 
        /// Does not guarantee theese roads will be avoided if alternate route paths are too lengthy or not possible.
        /// </summary>
        public List<int> tryAvoidLinkIds { get; set; }

        /// <summary>
        /// Returns a list of string of artey Weights.
        /// </summary>
        public List<string> arteryWeights { get; set; }
        #endregion

        public Options()
        {
            timeType = 0;
            maxLinkId = 0;
            generalize = 0;
            routeNumber = 0;
            drivingStyle = 0;
            walkingSpeed = 0;
            transferPenalty = 0;
            maneuverPenalty = 0;
            urbanAvoidFactor = 0;
            filterZoneFactor = 0;
            highwayEfficiency = 0;
            cyclingRoadFactor = 0;
            maxWalkingDistance = 0;
            useTraffic = false;
            manmaps = false;
            enhancedNarrative = false;
            sideOfStreetDisplay = false;
            returnLinkDirections = false;
            avoidTimedConditions = false;
            stateBoundaryDisplay = false;
            countryBoundaryDisplay = false;
            destinationManeuverDisplay = false;
            unit = String.Empty;
            locale = String.Empty;            
            routeType = String.Empty;
            shapeFormat = String.Empty;
            narrativeType = String.Empty;
            avoidTripIds = new List<int>();
            mustAvoidLinkIds = new List<int>();
            tryAvoidLinkIds = new List<int>();
            arteryWeights = new List<string>();
        }
    }
}