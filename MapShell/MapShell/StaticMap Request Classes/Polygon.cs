using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MapShell.Directions_Result_Class;

// Ngwa T Leonard

namespace MapShell.StaticMap_Request_Classes
{
    /// <summary>
    /// This class creates a shape from the input of lat/lng pairs and shades in the shape with the requested color.
    /// color-color of the line creating the shape
    /// width-width of the line creating the shape
    /// LatLngPairs-this is the list of the points creating the shape. The points move in a clockwise direction from the start of the 
    /// list to the end of the list.
    /// fill-shades inside the shape to the specified color
    /// </summary>
    public class Polygon
    {
        Color color;
        int width;
        List<LatLng> LatLngPairs;
        Color fill;

        /// <summary>
        /// Default constructor for the Polygon class.
        /// The definitions from above apply here as well.
        /// </summary>
        public Polygon()
        {
            color = new Color(); // default color
            width = -1;
            LatLngPairs = new List<LatLng>(); // Initializing a non-primitive. Primitives are initialized like(int = 0;)
            fill = new Color();
        }

        /// <summary>
        /// Class constructor that accepts input from the front end in a correct format.
        /// </summary>
        /// <param name="inputColor">color of the line creating the shape in hexadecimal</param>
        /// <param name="inputWidth">width of the line creating the shape</param>
        /// <param name="inputFill">color of the shading of the shape in hexadecimal</param>
        /// <param name="inputLatLngPairs">list of points to create the shape</param>
        public Polygon(Color inputColor, int inputWidth, Color inputFill, List<LatLng> inputLatLngPairs)
        {
            color = inputColor;
            width = inputWidth;
            LatLngPairs = inputLatLngPairs;
            fill = inputFill;
        }

        /// <summary>
        /// Function that returns the values in a string format to the api for application on the map.
        /// </summary>
        /// <returns>color in hexadecimal, a width, lat/lng pairs for points of the shape, and color of the shading</returns>
       
        public string returnPolygonString()
        {
            string result = "";

            if (width == -1 || LatLngPairs.Count==0)
            {
                return result;
            }
            else
            {
                result = "color:0x" + color.A.ToString("X2") + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2") + '|' + "width:" + Convert.ToString(width) + '|' + "fill:0x" + fill.A.ToString("X2") + fill.R.ToString("X2") + fill.G.ToString("X2") + fill.B.ToString("X2")
                    + "|";
                for (int index = 0; index < LatLngPairs.Count; ++index)
                {
                    result += Convert.ToString(LatLngPairs[index].lat) + ',' + Convert.ToString(LatLngPairs[index].lng);
                    if (index < LatLngPairs.Count - 1)
                    {
                        result += ',';
                    }
                }
                return result;
            }
        }

    }
}
