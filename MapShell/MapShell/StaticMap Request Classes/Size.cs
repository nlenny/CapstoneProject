using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ngwa T Leonard

namespace MapShell.StaticMap_Request_Classes
{
    /// <summary>
    /// This class creates the size of the map to be created
    /// width-width of the map
    /// height-height of the map
    /// </summary>
    public class Size
    {
        public uint width;
        public uint height;

        /// <summary>
        /// Default constructor 
        /// </summary>
        public Size()
        {
            width = 400;
            height = 400;
        }

        /// <summary>
        /// Class constructor that lets user define map size.
        /// </summary>
        /// <param name="width_">unsigned integer (can only accept non negative integers)</param>
        /// <param name="height_">unsigned integer (can only accept non negative integers)</param>
        public Size(uint width_, uint height_)
        {
            //ternary implemetation --- ternary means it takes 3 things compare and if true returns the 1st 
            //value, and 2nd value if false

            width = (width_ > 3840 ? 3840 : width_);
            height = (height_ > 3840 ? 3840 : height_);

        }

        /// <summary>
        /// Function that converts width and height to string and returns it as a string
        /// </summary>
        /// <returns>width and height in a string format</returns>
        public string returnSizeString()
        {
            return Convert.ToString(width) + ',' + Convert.ToString(height);
        }

    }
}
