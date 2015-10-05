using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Net;
using System;

namespace MapShell.Directions_Result_Class
{
    //Link for api reference: open.mapquestapi.com/directions
    //see route response: signs attribute

    /// <summary>
    /// Sign Class is used in storing data related to directional signs for a particular maneuver.
    /// Not peace signs, just road signs and related signs.
    /// </summary>
    public class Sign
    {
        #region Variables
        /// <summary>
        /// Returns the integer value for current said sign.
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// Returns the directional integer value for current sign. 
        /// Values:
        /// None = 0
        /// North = 1
        /// Northwest = 2
        /// Northeast = 3
        /// South = 4
        /// Southeast = 5
        /// Southwest = 6
        /// West  7
        /// East = 8
        /// </summary>
        public int direction { get; set; }

        /// <summary>
        /// Returns the url of the sign image.
        /// </summary>
        public string url { get; set; }
        [JsonIgnore]
        public Image directionImage
        {
            get
            {
                if (sign_ == null)
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                    HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    Stream stream = httpWebReponse.GetResponseStream();
                    sign_ = Image.FromStream(stream);
                    httpWebReponse.Dispose();
                }
                return sign_;
            }
            set
            {
                sign_ = value;
            }
        }
        private Image sign_ { get; set; }
        /// <summary>
        /// Returns text name
        /// </summary>
        public string text { get; set; }

        /// <summary>
        /// Returns extra provided text
        /// </summary>
        public string extraText { get; set; }
        #endregion

        public Sign()
        {
            sign_ = null;

            type = 0;
            direction = 0;
            url = String.Empty;
            text = String.Empty;
            extraText = String.Empty;
        }
    }
}