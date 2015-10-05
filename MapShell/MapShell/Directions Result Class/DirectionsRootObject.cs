using Newtonsoft.Json;

namespace MapShell.Directions_Result_Class
{
    public class DirectionsRootObject
    {
        #region Variables
        public Directions route { get; set; }
        #endregion

        public DirectionsRootObject()
        {
            route = new Directions();
        }
    }
}