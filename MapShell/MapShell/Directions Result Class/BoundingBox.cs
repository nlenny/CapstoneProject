namespace MapShell.Directions_Result_Class
{
    /// <summary>
    /// BoundingBox contains the coordinates of the entire box.
    /// </summary>
    public class BoundingBox
    {
        /// <summary>
        /// Returns upper left hand side latlng
        /// </summary>
        public LatLng ul { get; set; } //upper left hand side coordinates

        /// <summary>
        /// Returns lower right hand side latlng
        /// </summary>
        public LatLng lr { get; set; } //lower right hand side coordinates

        public BoundingBox()
        {
            ul = new LatLng();
            lr = new LatLng();
        }

        public BoundingBox(LatLng upperLeft, LatLng lowerRight)
        {
            ul = upperLeft;
            lr = lowerRight;
        }
    }
}