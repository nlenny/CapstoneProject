using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    /// <summary>
    /// This class specifies the map 'mode'.
    /// This class accepts 3 different types of map modes.
    /// map-standard map mode
    /// sat-sattellite map mode
    /// hyb-hybrid map mode that integrates the two previous maps into one
    /// 
    /// </summary>
    public class Type
    {
        public string type;
        public enum TypeMap { map, hyb, sat };

        /// <summary>
        /// Default constructor
        /// </summary>

        public Type()
        {

            type = "map";

        }

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="input">checks the input type to set to user's request</param>

        public Type(Type.TypeMap input)
        {

            //there are 3 'types' map/hybrid/satellite  default is 'map'


            switch (input)
            {
                case TypeMap.hyb:
                    type = "hyb";
                    break;
                case TypeMap.sat:
                    type = "sat";
                    break;
                default:
                    type = "map";
                    break;

            }
        }
        /// <summary>
        /// Function that returns the type of map.
        /// </summary>
        /// <returns>a string of the type to the api</returns>
        public string returnType()
        {
            return Convert.ToString(type);
        }

    }
}
