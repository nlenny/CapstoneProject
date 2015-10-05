using MapShell.Directions_Result_Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MapShell.StaticMap_Request_Classes
{
    public class StaticMap
    {
        #region Enums
        /// <summary>
        /// Indicates what type of map will be displayed.
        /// map: regular map view.
        /// hyb: hybrid of map and satalite view.
        /// sat: satalite view.
        /// </summary>
        public enum MapType { map, hyb, sat };

        /// <summary>
        /// All of the image types supported by the static map API.
        /// </summary>
        public enum ImageType { jpeg, jpg, gif, png }
        #endregion

        #region Variables
        public int zoom
        {
            get
            {
                return zoom_;
            }
            set
            {
                zoom_ = value;
                mapChanged = true;
            }
        }
        private int zoom_ { get; set; }
        public bool declutter
        {
            get
            {
                return declutter_;
            }
            set
            {
                declutter_ = value;
                mapChanged = true;
            }
        }
        private bool declutter_ { get; set; }
        public StaticMap.MapType mapType
        {
            get
            {
                return mapType_;
            }
            set
            {
                mapType_ = value;
                mapChanged = true;
            }
        }
        private StaticMap.MapType mapType_ { get; set; }
        public StaticMap.ImageType imageType
        {
            get
            {
                return imageType_;
            }
            set
            {
                imageType_ = value;
                mapChanged = true;
            }
        }
        private StaticMap.ImageType imageType_ { get; set; }
        public Size size
        {
            get
            {
                return size_;
            }
            set
            {
                size_ = value;
                mapChanged = true;
            }
        }
        private Size size_ { get; set; }
        public Center center
        {
            get
            {
                return center_;
            }
            set
            {
                center_ = value;
                mapChanged = true;
            }
        }
        private Center center_ { get; set; }
        public Center mCenter
        {
            get
            {
                return mCenter_;
            }
            set
            {
                mCenter_ = value;
                mapChanged = true;
            }
        }
        private Center mCenter_ { get; set; }
        public Center pCenter
        {
            get
            {
                return pCenter_;
            }
            set
            {
                pCenter_ = value;
                mapChanged = true;
            }
        }
        private Center pCenter_ { get; set; }
        public Center sCenter
        {
            get
            {
                return sCenter_;
            }
            set
            {
                sCenter_ = value;
                mapChanged = true;
            }
        }
        private Center sCenter_ { get; set; }
        public Center eCenter
        {
            get
            {
                return eCenter_;
            }
            set
            {
                eCenter_ = value;
                mapChanged = true;
            }
        }
        private Center eCenter_ { get; set; }
        public Polygon polygon
        {
            get
            {
                return polygon_;
            }
            set
            {
                polygon_ = value;
                mapChanged = true;
            }
        }
        private Polygon polygon_ { get; set; }
        public Ellipse ellipse
        {
            get
            {
                return ellipse_;
            }
            set
            {
                ellipse_ = value;
                mapChanged = true;
            }
        }
        private Ellipse ellipse_ { get; set; }
        public Polyline polyline
        {
            get
            {
                return polyline_;
            }
            set
            {
                polyline_ = value;
                mapChanged = true;
            }
        }
        private Polyline polyline_ { get; set; }
        public Directions_Result_Class.Shape shape
        {
            get
            {
                return shape_;
            }
            set
            {
                shape_ = value;
                mapChanged = true;
            }
        }
        private Directions_Result_Class.Shape shape_ { get; set; }
        public List<XIS> xis
        {
            get
            {
                return xis_;
            }
            set
            {
                xis_ = value;
                mapChanged = true;
            }
        }
        private List<XIS> xis_ { get; set; }
        public List<Center> stops
        {
            get
            {
                return stops_;
            }
            set
            {
                stops_ = value;
                mapChanged = true;
            }
        }
        private List<Center> stops_ { get; set; }
        public List<Center> pois
        {
            get
            {
                return pois_;
            }
            set
            {
                pois_ = value;
                mapChanged = true;
            }
        }
        private List<Center> pois_ { get; set; }
        public Image map
        {
            get
            {
                //Task<Image> tmp;
                if (map_ == null || mapChanged)
                {
                    //tsage 4/9 having trouble getting this to actually run async
                    //Dispatcher.Invoke(async () => {await Task.Run(() =>downloadMap());});
                    downloadMap();
                }

                mapChanged = false;
                return map_;
            }
            set
            {
                map_ = value;
            }
        }
        private Image map_ { get; set; }
        private bool mapChanged { get; set; }

        public string session
        {

            get
            {
                return session_;
            }

            set
            {
                session_ = value;
                mapChanged = true;
            }

        }
        private string session_;

        public BoundingBox Bbox {

            get {
                return bBox_;
            
            }
            set {
                bBox_ = value;
                mapChanged = true;
            }
        }
        private BoundingBox bBox_;
        #endregion

        #region Constructors

        // Ngwa T Leonard
        public StaticMap()
        {
            zoom_ = 0;
            declutter_ = false;
            mapType_ = StaticMap.MapType.map;
            imageType_ = StaticMap.ImageType.png;
            size_ = new Size(640, 480);
            map_ = null;
            center_ = null;
            mCenter_ = null;
            pCenter_ = null;
            sCenter_ = null;
            eCenter_ = null;
            stops_ = null;
            polygon_ = null;
            ellipse_ = null;
            polyline_ = null;
            shape_ = null;
            xis_ = null;
            pois_ = null;
            mapChanged = false;
            session_ = String.Empty;
            bBox_ = null;

        }

        // Ngwa T Leonard

        public StaticMap(LatLng location, int _zoom = 0, uint width = 640, uint height = 480, StaticMap.ImageType _imageType = StaticMap.ImageType.png, StaticMap.MapType _mapType = StaticMap.MapType.hyb, bool _declutter = false, List<XIS> _xis = null)
        {
            session_ = String.Empty;
            bBox_ = null;
            zoom_ = _zoom;
            imageType_ = _imageType;
            declutter_ = false;
            size_ = new Size(width, height);
            mapType_ = _mapType;
            center_ = new Center(location);
            mCenter_ = new Center(location);
            pCenter_ = null;
            sCenter_ = null;
            eCenter_ = null;
            stops_ = null;
            shape_ = null;
            ellipse_ = null;
            polyline_ = null;
            polygon_ = null;
            map_ = null;
            xis_ = _xis;
            pois_ = null;
            mapChanged = false;
        }

        // Ngwa T Leonard

        public StaticMap(List<Locations> locations, int _zoom = 0, uint width = 640, uint height = 480, StaticMap.ImageType _imageType = StaticMap.ImageType.png, StaticMap.MapType _mapType = StaticMap.MapType.hyb, bool _declutter = false, List<XIS> _xis = null)
        {
            session_ = String.Empty;
            bBox_ = null;
            zoom_ = _zoom;
            imageType_ = _imageType;
            declutter_ = false;
            size_ = new Size(width, height);
            mapType_ = _mapType;
            center_ = null;
            mCenter_ = null;
            pCenter_ = null;
            sCenter_ = null;
            eCenter_ = null;
            stops_ = null;
            shape_ = null;
            ellipse_ = null;
            polyline_ = null;
            polygon_ = null;
            map_ = null;
            xis_ = _xis;
            pois_ = new List<Center>();
            foreach (Locations l in locations)
            {
                pois_.Add(new Center(l.displayLatLng));
            }
            mapChanged = false;
        }


        public StaticMap(List<LatLng> highlightPoints, Color boarder, Color fill, BoundingBox bestFit = null, int polygonWidth = 0, uint width = 640, uint height = 480, StaticMap.ImageType _imageType = StaticMap.ImageType.png, StaticMap.MapType _mapType = StaticMap.MapType.hyb, bool _declutter = false, List<XIS> _xis = null)
        {
            session_ = String.Empty;
            if(bestFit == null && highlightPoints.Count > 0)
            {
                bBox_ = new BoundingBox(new LatLng(highlightPoints[0].lat, highlightPoints[0].lng), new LatLng(highlightPoints[0].lat, highlightPoints[0].lng));
                for(int i = 1; i < highlightPoints.Count; ++i){
                    if(bBox_.ul.lat < highlightPoints[i].lat)
                    {
                        bBox_.ul.lat = highlightPoints[i].lat;
                    }
                    if(bBox_.ul.lng > highlightPoints[i].lng)
                    {
                        bBox_.ul.lng = highlightPoints[i].lng;
                    }
                    if(bBox_.lr.lat > highlightPoints[i].lat)
                    {
                        bBox_.lr.lat = highlightPoints[i].lat;
                    }
                    if(bBox_.lr.lng < highlightPoints[i].lng)
                    {
                        bBox_.lr.lng = highlightPoints[i].lng;
                    }
                }
            }
            else
            {
                bBox_ = bestFit;
            }            
            zoom_ = 0;
            imageType_ = _imageType;
            declutter_ = false;
            size_ = new Size(width, height);
            mapType_ = _mapType;
            center_ = null;
            mCenter_ = null;
            pCenter_ = null;
            sCenter_ = null;
            eCenter_ = null;
            stops_ = null;
            shape_ = null;
            ellipse_ = null;
            polyline_ = null;
            polygon_ = new Polygon(boarder, polygonWidth, fill, highlightPoints);
            map_ = null;
            xis_ = _xis;
            pois_ = null;
        }

        // Leonard modified 04/30/2015

        public StaticMap(string sessionId, BoundingBox inbBox, Directions_Result_Class.Shape _shape, int _zoom = 0, uint width = 640, uint height = 480, StaticMap.ImageType _imageType = StaticMap.ImageType.png, StaticMap.MapType _mapType = StaticMap.MapType.hyb, bool _declutter = false, List<XIS> _xis = null) 
        {

            session_ = sessionId;
            bBox_ = inbBox;
            zoom_ = _zoom;
            imageType_ = _imageType;
            declutter_ = false;
            size_ = new Size(width, height);
            mapType_ = _mapType;
            center_ = null;
            mCenter_ = null;
            pCenter_ = null;
            sCenter_ = (_shape.shapePoints.Count > 1 ? new Center(_shape.shapePoints[0], _shape.shapePoints[1]) : null);
            eCenter_ = (sCenter == null ? null : new Center(_shape.shapePoints[_shape.shapePoints.Count - 2], _shape.shapePoints[_shape.shapePoints.Count - 1]));
            if (_shape.legIndexes.Count > 2)
            {
                stops_ = new List<Center>();
                char letter = 'A';
                for (int i = 1; i < _shape.legIndexes.Count - 1; ++i)
                {
                    stops_.Add(new Center(_shape.shapePoints[_shape.legIndexes[i] * 2], _shape.shapePoints[_shape.legIndexes[i] * 2 + 1], 0, 0, letter++));
                }
            }
            else
            {
                stops_ = null;
            }
            shape_ = null;
            ellipse_ = null;
            polyline_ = null;
            polygon_ = null;
            map_ = null;
            xis_ = _xis;
            pois_ = new List<Center>();
            mapChanged = false;

        
        }
        #endregion
        //tsage modified 4/8
        public async void downloadMap()
        {
            string url = ConfigurationManager.AppSettings["MapQuestStaticMapURl"] + ConfigurationManager.AppSettings["MapQuestAPIKey"] + "&scalebar=false"
                + (size_ == null ? "" : "&size=" + size_.returnSizeString())
                + (zoom_ == 0 ? "" : "&zoom=" + Convert.ToString(zoom_))
                + (center_ == null ? "" : "&center=" + center_.returnCenterString())
                + "&type=" + mapType.ToString() + "&imagetype=" + imageType_.ToString()
                + (mCenter_ == null ? "" : "&mcenter=" + mCenter_.returnCenterString())
                + (pCenter_ == null ? "" : "&pcenter=" + pCenter_.returnCenterString());
            if (xis_ != null)
            {
                url += "&xis=";
                for (int index = 0; index < xis_.Count; ++index)
                {
                    url += Convert.ToString(xis_[index].returnXISstring());
                    if (index < xis_.Count - 1)
                    {
                        url += ',';
                    }
                }
            }

            // Leonard modified 04/30/2015

            url += (bBox_ == null ? "" : "&bestfit=" + Convert.ToString(bBox_.ul.lat) + "," + Convert.ToString(bBox_.ul.lng) + "," + Convert.ToString(bBox_.lr.lat) + "," + Convert.ToString(bBox_.lr.lng));
            url += (session_ == String.Empty ? "" : "&session=" + session_);
            url += "&declutter=" + (declutter_ ? "true" : "false");
            url += (shape_ == null ? "" : shape_.getString());
            url += (ellipse_ == null ? "" : ellipse_.returnEllipseString());
            url += (polyline_ == null ? "" : polyline_.returnPolylineString());
            url += (polygon_ == null ? "" : "&polygon=" + polygon_.returnPolygonString());
            url += (sCenter_ == null ? "" : "&scenter=" + sCenter_.returnCenterString());
            url += (eCenter_ == null ? "" : "&ecenter=" + eCenter_.returnCenterString());
            if (stops_ != null)
            {
                url += "&stops=";
                for (int index = 0; index < stops_.Count; ++index)
                {
                    url += stops_[index].returnCenterString();
                    if (index < stops_.Count - 1)
                    {
                        url += '|';
                    }
                }
            }
            if (pois_ != null)
            {
                url += "&pois=";
                for (int index = 0; index < pois_.Count; ++index)
                {
                    url += Convert.ToString(index + 1) + "," + pois_[index].returnCenterString();
                    if (index < pois_.Count - 1)
                    {
                        url += '|';
                    }
                }
            }
            try
            {
                //tsage 4/9 the calls are now async but unfortunately it doesn't run async yet.
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse httpWebReponse = (HttpWebResponse) httpWebRequest.GetResponse();

                //tsage 4/15/15
                //HttpClient client = new HttpClient();
                //HttpResponseMessage response = await client.GetAsync(url);

                Stream stream = httpWebReponse.GetResponseStream();
                map_ = Image.FromStream(stream);
                httpWebReponse.Dispose();
            }
            catch (Exception)
            {
                map_ = null;
            }
            mapChanged = false;
            //return map_;
        }

    }
}