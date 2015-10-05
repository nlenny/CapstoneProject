using System.Collections.Generic;

namespace MapShell.Directions_Result_Class
{
    class Result
    {
        #region Variables
        public List<Locations> locations { get; set; }
        #endregion

        public Result()
        {
            locations = new List<Locations>();
        }
    }
}