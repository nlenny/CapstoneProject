using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MapShell.Directions_Result_Class;
using System.Threading.Tasks;

// Ngwa T Leonard

namespace MapShell.StaticMap_Request_Classes
{
    /// <summary>
    /// /Class ellipse --- Takes a color, width, a pair of latitude and longitude, fill which is a color.
    /// </summary>
    public class Ellipse
    {
        string color;
        int width;
        List<LatLng> LatLngPairs;
        //&ellipse=fill:0x70ff0000|color:0xff0000|width:2|40.19,-76.35,40.13,-76.27
        
        string fill;

        /// <summary>
        /// Default constructor for the Ellipse class
        /// color-this is the actual solid color of the line creating the shape
        /// width-this is the width of the line creating the shape using the above 'color'
        /// fill-this is the shading of the interior of the ellipse
        /// LatLngPairs-This accepts two pairs of lat, lngs. The first pair is the upper left coordinate of the bounding box and the 
        /// second pair is the lower left of the bounding box.
        /// </summary>
        public Ellipse()
        {
            //Variable declarations and initialization
            //color = 0x000000; // Defaulted to a hexidecimal representation of color
            color = "";
            width = 0;
            LatLngPairs = new List<LatLng>();
            fill = "";
           // fill = 0x000000; //Also defaulted to a hexidecimal representation of color
        }

        /// <summary>
        /// The same description applies for this class constructor that applies for the default constructor.
        /// </summary>
        /// <param name="inputColor">color of the line</param>
        /// <param name="inputWidth">width of the line</param>
        /// <param name="inputLatLngPairs">upper left, and lower right of bounding box</param>
        /// <param name="inputFill">the color of the shading of the ellipse</param>
        public Ellipse(string inputColor, int inputWidth, List<LatLng> inputLatLngPairs, string inputFill)
        {
            color = inputColor;
            width = inputWidth;
            LatLngPairs = inputLatLngPairs;
            fill = inputFill;
        }

        /// <summary>
        /// This is the function that returns the values in the correct order and format for the api to 'read' correctly.
        /// </summary>
        /// <returns>This function either returns nothing to the api or the values input by the user.</returns>
        public string returnEllipseString()
        {
            string emptyEllipse = "";
            string result = "";
            string outfill = "fill:";
            string outcolor = "color:";
            string outwidth = "width:";

            if (color == "" && width == 0 && LatLngPairs.Count == 0 && fill == "")
            {
                return emptyEllipse;
            }

            else
            {
                
                
                result= "&ellipse="+outfill + Convert.ToString(fill) + '|' + outcolor + Convert.ToString(color)
                    + '|' + outwidth + Convert.ToString(width) + '|';
                for (int index = 0; index < LatLngPairs.Count; ++index)
                {
                    result += Convert.ToString(LatLngPairs[index].lat) + ',' + Convert.ToString(LatLngPairs[index].lng);
                    if (LatLngPairs.Count < LatLngPairs.Count - 1)
                    {
                        result += ',';
                    }
                }
                return result;
            }
        }
    }
}
