namespace MapShell.Directions_Result_Class
{
    /// <summary>
    /// Longitude and Latitude ADT class.
    /// </summary>
    public class LatLng
    {
        #region Variables
        /// <summary>
        /// Returns longitude value. 
        /// Default: 200 (not a valid longitude)
        /// </summary>
        public double lng { get; set; }

        /// <summary>
        /// Returns latitude value. 
        /// Default: 200 (not a valid latitude)
        /// </summary>
        public double lat { get; set; }
        #endregion

        #region Constructors
        public LatLng()
        {
            lng = 200.0;
            lat = 200.0;
        }

        public LatLng(double Latitude_, double Longitude_)
        {
            lat = Latitude_;
            lng = Longitude_;
        }
        #endregion
    }
}