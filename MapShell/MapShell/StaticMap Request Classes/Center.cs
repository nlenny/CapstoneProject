using System;
using MapShell.Directions_Result_Class;

// Ngwa T Leonard

namespace MapShell.StaticMap_Request_Classes
{
    /// <summary>
    /// Center is the name derived from mapquest developers page http://developer.mapquest.com.
    /// This center class is the base class for other mapquest api attributes.
    /// </summary>
    public class Center
    {
        public LatLng latlng;
        public double offX;
        public double offY;
        public char stopLetter;


        /// <summary>
        /// Default constructor for class center with no given parameters
        /// </summary>       
        public Center()
        {
            //All set to their default as specified by the problem domain
            latlng = null;
            offX = 0;
            offY = 0;
            stopLetter = '\0';
        }


        /// <summary>
        /// This is the class constructor.  This class constructs a center point for the api to zoom in on.
        /// This class also constructs mcenter, pcenter, scenter, and ecenter. 
        /// mcenter-specifies a point to place a star icon
        /// pcenter-specifies a point to place a search icon
        /// scenter-specifies a point to place the start icon at the begininning of a route
        /// ecenter-specifies a point to place the end icon at the end of a route
        /// </summary>
        /// <param name="inputLat">accepts a 'double' value for a latitude position</param>
        /// <param name="inputLng">accepts a 'double' value for a longitude position</param>
        /// <param name="inputOffx">accepts 'grid' type coordinates to offset the icon from the point</param>
        /// <param name="inputOffy">same as inputOffx</param>

        public Center(double inputLat, double inputLng, int inputOffx = 0, int inputOffy = 0, char letter = '\0')
        {
            //No limit on OFFY/OFFY so will not test for upper and lower bounds
            offX = inputOffx;
            offY = inputOffy;
            // Using nested ternary to test for upper and lower bounds on latitude : if > 90 assign 90 if < -90 assign -90 else assign input
            // Using nested ternary for longitude to test for upper and lower bounds. Takes values between -180 and 180
            latlng = new LatLng((inputLat > 90 ? 90 : (inputLat < -90 ? -90 : inputLat)), (inputLng > 180 ? 180 : (inputLng < -180 ? -180 : inputLng)));
            stopLetter = letter;
        }

        public Center(LatLng latlng_, double offX_ = 0, double offY_ = 0, char letter = '\0')
        {
            latlng = latlng_;
            offX = offX_;
            offY = offY_;
            stopLetter = letter;
        }



        /// <summary>
        /// A function that creates a specific part of the Json that this Center class refers to.
        /// </summary>
        /// <returns>This function returns latitude, longitude, and offset values in the correct format for the api to understand.</returns>

        //A function that creates a specific part of the Json that this Center class refers to

        public string returnCenterString()
        {
            if (latlng == null && offX == 0 && offY == 0)
            {
                return "";
            }
            else
            {
                return (Char.IsLetter(stopLetter) ? stopLetter + "," : "") + Convert.ToString(latlng.lat) + ',' + Convert.ToString(latlng.lng) + ',' + Convert.ToString(offX) + ',' + Convert.ToString(offY);
            }
        }
    }
}