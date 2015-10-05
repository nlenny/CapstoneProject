using System.Collections.Generic;

namespace MapShell.Directions_Result_Class
{
    class LocationsRootObject
    {
        #region Variables
        public List<Result> results { get; set; }
        #endregion

        public LocationsRootObject()
        {
            results = new List<Result>();
        }
    }
}