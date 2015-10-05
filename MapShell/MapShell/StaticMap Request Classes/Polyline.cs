using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapShell.Directions_Result_Class;

//Ngwa T Leonard

namespace MapShell.StaticMap_Request_Classes
{
    /// <summary>
    /// This class draws a line composed of one or more line segments.
    /// color-color of the line creating the line
    /// width-width of the line creating the line
    /// LatLngPairs-List of coordinates that creates the line
    /// </summary>
    public class Polyline
    {
        string color;
        int width = 0;
        List<LatLng> LatLngPairs;


        /// <summary>
        /// Default constructor for the Polyline class
        /// definitions from top summary apply here as well
        /// </summary>
        public Polyline()
        {
            color = "";
            width = 0;
            LatLngPairs = new List<LatLng>();//&polyline=color:0x000000|width:5|40.07089,-76.3264,40.0622,-76.3429,40.0606,-76.3610,40.0526,-76.3757,40.0531,-76.3923
           
        }

        /// <summary>
        /// Class constructor for the polyline class
        /// </summary>
        /// <param name="inputColor">color of the line creating the polyline</param>
        /// <param name="inputWidth">width of the line creating the polyline</param>
        /// <param name="inputLatLngPairs">List of pairs of coordinates to create points of polyline</param>
        public Polyline(string inputColor, int inputWidth, List<LatLng> inputLatLngPairs)
        {
            color = inputColor;
            width = inputWidth;
            LatLngPairs = inputLatLngPairs;
        }

        /// <summary>
        /// Function that returns values to the api in a correct format for the api to read.
        /// </summary>
        /// <returns>color in hexadecimal, an integer width,pairs of lat/lng values</returns>
        public string returnPolylineString()
        {
            string result = "";
            //Convert.ToString should always be used in a try catch bracket, just in case of a wrong input things will be handled properly

            if (LatLngPairs.Count == 0) { return result; }


            else
            {
                result += "&polyline=";
                //color:0x000000|width:5|40.07089,-76.3264,40.0622,-76.3429,40.0606,-76.3610,40.0526,-76.3757,40.0531,-76.3923
                result += "color:" + Convert.ToString(color) + '|' + "width:" + Convert.ToString(width);


                // Leonard modified 05/01/2015
                result += '|';

                for (int index = 0; index < LatLngPairs.Count; ++index)
                {
                    result += Convert.ToString(LatLngPairs[index].lat) + ',' + Convert.ToString(LatLngPairs[index].lng);
                    if (LatLngPairs.Count < LatLngPairs.Count - 1)
                    {
                        result += ',';
                    }
                }
            }
            return result;
        }
    }
}

