using System.Collections.Generic;

namespace MapShell.Directions_Result_Class
{
    /// <summary>
    /// Describes one "leg" of a route. It contains the maneuvers describing how to get from one location to the next location.
    /// Each leg will contain a variety of information, including index, time, distance, and formattedTime.
    /// </summary>
    //
    //Link for api reference: open.mapquestapi.com/directions
    //see route response: leg attribute
    public class Leg
    {
        #region Variables
        /// <summary>
        /// Returns the calculated elapsed time in seconds for the route.
        /// </summary>
        public int time { get; set; }

        /// <summary>
        /// Returns the index position of current leg.
        /// </summary>
        public int index { get; set; }

        /// <summary>
        /// Returns the origin index. Origin index is the index of the first non-collapsed maneuver.
        /// </summary>
        public int origIndex { get; set; }

        /// <summary>
        /// Returns the destination index which is the index of the last non-collapsed maneuver.
        /// </summary>
        public int destIndex { get; set; }

        /// <summary>
        /// Returns the calculated distance of the route.
        /// </summary>
        public double distance { get; set; }

        /// <summary>
        /// Returns true if at least one leg contains a Ferry attribute.  Otherwise it returns false.
        /// </summary>
        public bool hasFerry { get; set; }

        /// <summary>
        /// Returns true if at least one leg has a Limited Access/Highway attribute, otherwise it returns false.
        /// </summary>
        public bool hasHighway { get; set; }

        /// <summary>
        /// Returns true if at least one leg contains an Unpaved attribute, otherwise it returns false.
        /// </summary>
        public bool hasUnpaved { get; set; }

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
        /// The rephrased desitination narrative string for the desination maneuver.
        /// </summary>
        public string origNarrative { get; set; }

        /// <summary>
        /// Returns the calculated elpased time as formatted text in HH:MM:SS format.
        /// </summary>
        public string formattedTime { get; set; }

        /// <summary>
        /// Returns the rephrased desitination narrative string for the desitination maneuver.
        /// </summary>
        public string destNarrative { get; set; }

        /// <summary>
        /// A collections of Maneuver objects.
        /// </summary>
        public List<Maneuver> maneuvers { get; set; }

        /// <summary>
        /// Note: for bicycle routes only
        /// Specifies the road grade avoidance strategies to be used for each leg:
        /// DEFAULT_STRATEGY - No road grade strategy will be used.
        /// AVOID_UP_HILL - Avoid up hill road grades.
        /// AVOID_DOWN_HILL - Avoid down hill road grades.
        /// AVOID_ALL_HILLS - Avoid all hill road grades.
        /// FAVOR_UP_HILL - Favor up hill road grades.
        /// FAVOR_DOWN_HILL - Favor down hill road grades.
        /// FAVOR_ALL_HILLS - Favor all hill road grades.
        /// Note: Default='DEFAULT_STRATEGY'
        /// </summary>
        public List<List<string>> roadGradeStrategy { get; set; } //Only for bicycle routes
        #endregion

        public Leg()
        {
            time = 0;
            index = 0;
            origIndex = 0;
            destIndex = 0;
            distance = 0;
            hasFerry = false;
            hasHighway = false;
            hasUnpaved = false;
            hasTollRoad = false;
            hasCountryCross = false;
            hasSeasonalClosure = false;
            origNarrative = "";
            formattedTime = "";
            destNarrative = "";
            maneuvers = new List<Maneuver>();
            roadGradeStrategy = new List<List<string>>(); //Only for bicycle routes
        }
    }
}