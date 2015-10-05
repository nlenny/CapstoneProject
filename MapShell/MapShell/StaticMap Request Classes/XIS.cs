using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    public class XIS
    {
        public enum alignValues{C,TL,TC,TR,LC,RC,BL,BC,BR};
        public string uri;//this is the url for the site the image is coming from
        public int count;//An integer for how many times the particular image will be used on the map.

        public double LAT;
        public double LNG;
        public int OFFX;//This is the offset of the icon on the x axis. This is optional.
        public int OFFY;//This is the offset of the icon on the y axis. This is optional.
        public string ALIGN;//This sets an alignment for the icon. There are nine values that can be used.
        public int TWKOFFX;//This offset will be applied after the latitude/longitude, alignment, and offset.
                           //The main difference is this offset will have a line drawn from the position
                           //is should be in to where this offset tells it to be. This is optional.
        public int TWKOFFY;//same as above

        //Default constructor
        public XIS() 
        {
            //http://open.mapquestapi.com/media/images/money_sign.jpg
            uri = " ";//Default website^^^^^^^

            count = 0;
           
            LAT = 200.0;
            LNG = 200.0;
           
            OFFX = 0;
            OFFY = 0;
           
            TWKOFFX = 0;
            TWKOFFY = 0;
           
            ALIGN = "C";
                }

        public XIS(string inputUri,int inputCount,XIS.alignValues inputAlign,double inputLat, double inputLng,int inputTwkOffx,int inputTwkOffy,int inputOffX,int inputOffY)
        {
            uri = inputUri;
            count = inputCount;
            LAT = inputLat;
            LNG = inputLng;
            TWKOFFX = inputTwkOffx;
            TWKOFFY = inputTwkOffy;
            OFFX = inputOffX;
            OFFY = inputOffY;
           
            /* these are the nine values that can be accepted in ALIGN
                 C - center
                TL - top left
                TC - top center
                TR - top right
                LC - left center
                RC - right center
                BL - botton left
                BC - bottom center
                BR - bottom right
             */

            switch (inputAlign)
            { 
                case alignValues.TL:
                    ALIGN = "TL";
                    break;
                case alignValues.TC:
                    ALIGN = "TC";
                    break;
                case alignValues.TR:
                    ALIGN = "TR";
                    break;
                case alignValues.LC:
                    ALIGN = "LC";
                    break;
                case alignValues.RC:
                    ALIGN = "RC";
                    break; ;
                case alignValues.BL:
                    ALIGN = "BL";
                    break;
                case alignValues.BC:
                    ALIGN = "BC";
                    break; ;
                case alignValues.BR:
                    ALIGN = "BR";
                    break;
                default:
                    ALIGN = "C";
                    break;
 
            }

        }
        ////A function that creates a specific part of the Json that this XIS class refers to
        public string returnXISstring() 
        {

            string emptyXiS = "&xis=";

            if (uri == "" && count == 0)
            {
                return emptyXiS;

            }
            else
            {
                return Convert.ToString(uri) + ',' + Convert.ToString(count) + ',' + Convert.ToString(ALIGN) + ',' +
                    Convert.ToString(LAT) + ',' + Convert.ToString(LNG) + ',' + Convert.ToString(TWKOFFX) + ',' + Convert.ToString(TWKOFFY)
                    + ',' + Convert.ToString(OFFX) + ',' + Convert.ToString(OFFY);
            }
        }

    }
}
