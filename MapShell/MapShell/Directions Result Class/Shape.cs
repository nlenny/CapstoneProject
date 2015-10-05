using System.Collections.Generic;
using System;
using Newtonsoft.Json;

namespace MapShell.Directions_Result_Class
{
    /// <summary>
    ///  	A collection of latitude/longitude coordinates or 
    ///  	shape points for the entire route highlight based 
    ///  	on original mapstate and/or the generalize option. 
    ///  	Shape is an alternated array of lat/lngs. 
    ///  	Evens are lat and odds are lng.
    /// </summary>
    public class Shape
    {

        #region Enums
        /// <summary>
        /// delta: First shape point is represented in mutliples of 106 and subsequent points is given as difference from previous point.
        /// raw: Shape is represented as latitude/longitude pairs.
        /// cmp: Shape is represented as a compressed path string with 5 digits of precision.
        /// cmp6: Same as cmp, but uses 6 digits of precision.
        /// </summary>
        public enum SFormat { delta, cmp, raw, cmp6 };
        #endregion

        #region Variables

        /// <summary>
        /// The Shape format options.
        /// </summary>
        [JsonIgnore]
        public SFormat format { get; set; }

        /// <summary>
        /// An array of the starting index for each maneuver.
        /// </summary>
        public List<int> maneuverIndexes { get; set; }

        /// <summary>
        /// Shape points for the route (clipped and generalized) will be returned if mapState is given.
        /// Shape points is an alternated array of lat/lngs. Evens are lat and odds are lng.
        /// The index of a specific shape point is i/2.
        /// </summary>
        public List<double> shapePoints { get; set; }

        /// <summary>
        /// The shape point index which starts a specific route segment.
        /// The shape point index of the end of the segment is legIndex-1 of the next legIndex.
        /// Note: that there is always one extra legIndex (the number of legIndexes = number of legs +1)
        /// to account for the last shape point of the final segment.
        /// </summary>
        public List<int> legIndexes { get; set; }

        /// <summary>
        /// An option to encode shape to send to api.
        /// </summary>
        [JsonIgnore]
        private string encodedShape_ { get; set; }
        [JsonIgnore]
        public string encodedShape
        {
            get
            {
                if (encodedShape_ == null)
                {
                    encodedShape_ = returnCompressedPairs(shapePoints);
                }
                return encodedShape_;
            }
            set
            {
                encodedShape_ = value;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor for shape class.
        /// </summary>
        public Shape()
        {
            format = SFormat.cmp6;
            maneuverIndexes = new List<int>();
            shapePoints = new List<double>();
            legIndexes = new List<int>();
            encodedShape_ = null;
        }
        #endregion

        #region Functions
        /// <summary>
        /// Part of the encoding process.
        /// </summary>
        /// <param name="toBeCompressed">The array of doubles to be compressed</param>
        /// <param name="precision">How many digits to compress to.</param>
        /// <returns>String Encoded Value</returns>
        public string returnCompressedPairs(List<double> toBeCompressed, int precision = 6)
        {
            double oldLat = 0.0, oldLng = 0.0;
            int len = toBeCompressed.Count;
            string encoded = "";
            precision = (int)Math.Pow(10, precision);
            for (int i = 0; i < toBeCompressed.Count - 1; i += 2)
            {
                double temp_lat = Math.Round(toBeCompressed[i] * precision);
                double temp_long = Math.Round(toBeCompressed[i + 1] * precision);
                encoded += encodeNumber((int)(temp_lat - oldLat));
                encoded += encodeNumber((int)(temp_long - oldLng));
                oldLat = temp_lat;
                oldLng = temp_long;
            }
            return encoded;
        }

        /// <summary>
        /// Encodes the number for making the string size smaller.
        /// </summary>
        /// <param name="num"> value to encode</param>
        /// <returns>string encoded value</returns>
        public string encodeNumber(int num)
        {
            num = num << 1;
            if (num < 0)
            {
                num = ~(num);
            }
            string encoded = "";
            // while (num >= 0x20) means > 32
            while (num >= 0x20)
            {
                //String.fromCharCode((0x20 | (num & 0x1f)) + 63) converts a set of unicode values into characters
                encoded += (char)((0x20 | (num & 0x1f)) + 63);
                num >>= 5;
            }
            encoded += (char)(num + 63);
            return encoded;
        }
        /// <summary>
        /// This function returns the string nessessary for the static maps API
        /// </summary>
        /// <returns>String format</returns>
        public string getString()
        {
            return "&shapeformat=" + format.ToString() + "&shape=" + Convert.ToString(encodedShape);
        }
        #endregion
    }
}