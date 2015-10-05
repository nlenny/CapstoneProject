using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MapShell.Directions_Result_Class;
using MapShell.Directions_Request_Class;
using MapShell.UserControls;
using System.IO;
using System.Windows.Media.Animation;

namespace MapShell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region DataMembers

        //jyoder26 4/16 Reference: IV E 1

        private double SidebarWidth;
        private double CollapsedSidebarWidth;
        private bool Collapsed;

        private ObservableCollection<string> _Narative;
        public ObservableCollection<string> Narrative
        {
            get { return _Narative; }
            set { _Narative = value; }
        }

        private double _Distance;
        public double Distance
        {
            get { return _Distance; }
            set { _Distance = value; NotifyPropertyChanged("Distance"); }
        }

        private string _Time;
        public string Time
        {
            get { return _Time; }
            set { _Time = value; NotifyPropertyChanged("Time"); }
        }

        private ObservableCollection<Maneuver> _UserManeuvers;
        public ObservableCollection<Maneuver> UserManeuvers
        {
            get { return _UserManeuvers; }
            set { _UserManeuvers = value; NotifyPropertyChanged("UserManeuvers"); }
        }

        private System.Drawing.Image MainMap;
        public System.Drawing.Image _MainMap
        {
            get { return MainMap; }
            set { MainMap = value; }
        }

        //aarnold
        private DirectionsRequest.RouteType routeType { get; set; }
        private List<DirectionsRequest.Avoids> toAvoid { get; set; }
        public bool highways { get; set; }
        public bool tollRoads { get; set; }
        public bool unPaved { get; set; }
        public bool shortestTime { get; set; }
        public bool shortestDistance { get; set; }
        //aarnold 4/16
        StaticMap_Request_Classes.StaticMap.MapType typeOfMap { get; set; }
        public bool mapOnly { get; set; }
        public bool satellite { get; set; }
        public bool hybrid { get; set; }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Narrative = new ObservableCollection<string>();
            UserManeuvers = new ObservableCollection<Maneuver>();
            Time = null;
            Distance = 0;

            //aarnold
            routeType = DirectionsRequest.RouteType.Fastest;
            toAvoid = new List<DirectionsRequest.Avoids>();
            highways = false;
            tollRoads = false;
            unPaved = false;
            shortestTime = true;
            shortestDistance = false;
			//end aarnold
            //aarnold 4/16
            typeOfMap = StaticMap_Request_Classes.StaticMap.MapType.map;
            mapOnly = true;
            satellite = false;
            hybrid = false;
            //end aarnold 4/16
            SidebarWidth = 300;
            CollapsedSidebarWidth = 50;
            Collapsed = false;
        }

        //aarnold 4/23 start PDT: IV.D.2
        private async void Submit_Highlighting_Data(object sender, RoutedEventArgs e)
        {
            Loading();
            List<LatLng> latLongPoints = new List<LatLng>();
            /*List<LatLng> TempLoc = new List<LatLng>();
            
            int counter = 0;
            double totalLat = 0;
            double totalLng = 0;

            double HighestLat = -2000;
            double LowestLng = -2000;

            double HighestLng = -2000;
            double LowestLat = -2000;
            */
            foreach (LatLngControl items in LatLongPoints.ItemContainerGenerator.Items)
            {
                latLongPoints.Add(new LatLng(Convert.ToDouble(items.Latitude.Text), Convert.ToDouble(items.Longitude.Text)));
               /* 
                double lat=0;
                double lng=0;
                //high lat low lng farthest left


                lat = Convert.ToDouble(items.Latitude.Text);
                if(HighestLat == -2000 || lat > HighestLat)
                    HighestLat = lat;
                if (LowestLat == -2000 || lat < LowestLat)
                    LowestLat = lat;
                totalLat += lat;
                lng = Convert.ToDouble(items.Longitude.Text);
                if (HighestLng == -2000 || lng > HighestLng) 
                    HighestLng = lng;
                if (LowestLng == -2000 || lng < LowestLng)
                    LowestLng = lng;
                totalLng += lng;
                
                latLongPoints.Add(new LatLng(lat, lng));
                counter++;*/
            }
            /*
            LatLng FartheestPoint =await Task.Run(() => new LatLng(HighestLat, LowestLng));
            LatLng ClosestPoint = await Task.Run(() =>new LatLng(LowestLat, HighestLng));*/

            StaticMap_Request_Classes.StaticMap HighlightMap = await Task.Run(() => new StaticMap_Request_Classes.StaticMap(latLongPoints, System.Drawing.Color.FromArgb(100, 142, 165, 233), System.Drawing.Color.FromArgb(100, 142, 165, 233)));
            /*HighlightMap.polygon = await Task.Run(() => new StaticMap_Request_Classes.Polygon(System.Drawing.Color.Black, 0, System.Drawing.Color.Black, latLongPoints));
            totalLat = totalLat / counter;
            totalLng = totalLng / counter;
            HighlightMap.Bbox = await Task.Run(() => new Directions_Result_Class.BoundingBox(FartheestPoint, ClosestPoint));*/


            //end aarnold 4/2
            if (HighlightMap.map != null)
            {
                try
                {
                    MainMap = HighlightMap.map;
                    MemoryStream ms = new MemoryStream();
                    await Task.Run(() => MainMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png));
                    ms.Position = 0;
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = ms;
                    bi.EndInit();
                    image.Source = bi;
                }
                catch 
                {

                }
            }
            NotLoading();
        }
        //aarnold 4/23 end PDT: IV.D.2

       
        private async void Submit_Data(object sender, RoutedEventArgs e)
        {
            Loading();
            Distance = 0;
            Time = null;
            DistancePlace.Text = null;
            TotalTime.Text = null;
            toAvoid.Clear();
            
            //checking settings window to update directions request
            //aarnold 4/16
            if (mapOnly == true)
            {
                typeOfMap = StaticMap_Request_Classes.StaticMap.MapType.map;
            }
            else if (satellite == true)
            {
                typeOfMap = StaticMap_Request_Classes.StaticMap.MapType.sat;
            }
            else if (hybrid == true)
            {
                typeOfMap = StaticMap_Request_Classes.StaticMap.MapType.hyb;
            }
            //end aarnold 4/16
            if (shortestTime == true)
            {
                routeType = DirectionsRequest.RouteType.Shortest;
            }
            if (tollRoads == true)
            {
                toAvoid.Add(DirectionsRequest.Avoids.TollRoad);
            }
            if (unPaved == true)
            {
                toAvoid.Add(DirectionsRequest.Avoids.Unpaved);
            }
            //Limited access is highways
            if (highways == true)
            {
                toAvoid.Add(DirectionsRequest.Avoids.LimitedAccess);
            }
            //end aarnold 4/16

            UserManeuvers.Clear();
            //Causes the loading icon to appear
            

            List<Maneuver> TempManeuver = await GetDataAsync(shortestTime, toAvoid, typeOfMap);

            //this may not work!
            foreach (var item in TempManeuver)
                UserManeuvers.Add(item);

            //Causes theloading icon to diappear
            NotLoading();
        }

        //aarnold start 4/9
        private async void GetPinpoints_Click(object sender, RoutedEventArgs e)
        {
            //Causes the loading icon to appear
            Loading();
            UserManeuvers.Clear();

            List<Locations> Loc = new List<Locations>();
            List<Locations> TempLoc = new List<Locations>();
            foreach (AddressLine items in Addresses.ItemContainerGenerator.Items)
            {
                if (items.AddressLine1.Text == "Address Line 1") items.AddressLine1.Text = "";
                if (items.City.Text == "City") items.City.Text = "";
                if (items.ZIP.Text == "Zip Code") items.ZIP.Text = "";
                Address tempAddress = new Address(items.AddressLine1.Text, items.City.Text, items.State.Text, items.ZIP.Text);
                Task<List<Locations>> TLoc = tempAddress.getLocations();
                TempLoc = await TLoc;
                if (TempLoc.Count > 0)
                {
                    Loc.Add(TempLoc[0]);
                }                
            }

            if (Loc.Count != 0)
            {
                StaticMap_Request_Classes.StaticMap pinpointMap = await Task.Run(() =>new StaticMap_Request_Classes.StaticMap(Loc));
                MainMap = pinpointMap.map;

                MemoryStream ms = new MemoryStream();
                await Task.Run(() =>MainMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png));
                ms.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                image.Source = bi;
            }
            

            int a = await GetPinPointsAsync();

            ////Causes theloading icon to diappear
            //NotLoading();

            //UserManeuvers.Clear();
            //Narrative.Clear();
            NotLoading();
        }

        private async Task<int> GetPinPointsAsync()
        {
            List<Locations> Loc = new List<Locations>();
            List<Locations> TempLoc = new List<Locations>();
            foreach (AddressLine items in Addresses.ItemContainerGenerator.Items)
            {
                if (items.AddressLine1.Text == "Address Line 1") items.AddressLine1.Text = "";
                if (items.City.Text == "City") items.City.Text = "";
                if (items.ZIP.Text == "Zip Code") items.ZIP.Text = "";
                Address tempAddress = new Address(items.AddressLine1.Text, items.City.Text, items.State.Text, items.ZIP.Text);
                Task<List<Locations>> TLoc = tempAddress.getLocations();
                TempLoc = await TLoc;
                if (TempLoc.Count > 0)
                {
                    Loc.Add(TempLoc[0]);
                }                
            }

            if (Loc.Count != 0)
            {
                StaticMap_Request_Classes.StaticMap pinpointMap = await Task.Run(() => new StaticMap_Request_Classes.StaticMap(Loc));
                MainMap = pinpointMap.map;

                MemoryStream ms = new MemoryStream();
                await Task.Run(() =>MainMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png));
                ms.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                image.Source = bi;
            }
            return 1;
        }
        //aarnold 4/9

        //asynchronous method that will cause the data to be sent and receive asyn. 
        //tsage 4/2 PDT I.B.1.h.(4)
        private async Task<List<Maneuver>> GetDataAsync(bool shortestTime, List<DirectionsRequest.Avoids> toAvoid, StaticMap_Request_Classes.StaticMap.MapType typeOfMap) {
            //aarnold 4/2 Project Dev Tree - II.E.1 and 2 
            Loading();
            UserManeuvers.Clear();
            Narrative.Clear();

            List<Locations> Loc = new List<Locations>();
            List<Locations> TempLoc = new List<Locations>();
            foreach (AddressLine items in Addresses.ItemContainerGenerator.Items)
            {
                if (items.AddressLine1.Text == "Address Line 1") items.AddressLine1.Text = "";
                if (items.City.Text == "City") items.City.Text = "";
                if (items.ZIP.Text == "Zip Code") items.ZIP.Text = "";
                Address tempAddress = new Address(items.AddressLine1.Text, items.City.Text, items.State.Text, items.ZIP.Text);
                Task<List<Locations>> TLoc = tempAddress.getLocations();
                TempLoc = await TLoc;
                if (TempLoc.Count > 0)
                {
                    Loc.Add(TempLoc[0]);
                }                
            }

            //tsage end 4/2
            Directions UserInput = new Directions();

            if(Loc.Count != 0)
                if (shortestTime == true)
                {
                    //aarnold 4/16
                    UserInput = await Task.Run(() =>DirectionsRequest.getDirections(Loc, typeOfMap, DirectionsRequest.RouteType.Fastest, DirectionsRequest.DrivingStyle.Normal, toAvoid));
                }
                else
                {
                    //aarnold 4/16
                    UserInput = await Task.Run(() =>DirectionsRequest.getDirections(Loc, typeOfMap, DirectionsRequest.RouteType.Shortest, DirectionsRequest.DrivingStyle.Normal, toAvoid));
                }

            //end aarnold 4/2
            if (UserInput.legs.Count != 0)
            {
                try
                {
                    MainMap = UserInput.mainMap;
                    MemoryStream ms = new MemoryStream();
                    await Task.Run(() => MainMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png));
                    ms.Position = 0;
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = ms;
                    bi.EndInit();
                    image.Source = bi;
                }
                catch (System.Net.WebException e)
                {
                    
                }
            } 


            List<Maneuver> TempManeuvers = new List<Maneuver>();
            List<Maneuver> Temp = new List<Maneuver>();
            foreach (Leg items in UserInput.legs)
            {
                if (items.maneuvers.Count == 0) return TempManeuvers;
                Temp = items.maneuvers;
                foreach (var item in Temp)
                {
                    TempManeuvers.Add(item);
                }
            }
            if (UserInput.legs.Count != 0)
            {
                Distance = UserInput.distance;
                Time = UserInput.formattedTime;
            }
            

            DistancePlace.Text = Convert.ToString(Distance);

            TotalTime.Text = Time;

            if (Loc.Count == 0 || Loc.Count == 1)
                TempManeuvers.Clear();

            NotLoading();
            return TempManeuvers;

            //foreach (var item in TempManeuvers)
            //    UserManeuvers.Add(item);

            //Jyoder 3/12
            //List<Locations> Loc = Locations.getLocations()
            //List<Locations> Loc1 = Locations.getLocations(AddressLine1.Text, City1.Text, State1.Text, ZIP1.Text);
            //List<Locations> Loc2 = Locations.getLocations(AddressLineOne.Text, City2.Text, State2.Text, ZIP2.Text);
            //Directions UserInput = Directions.getDirections(Loc1[0], Loc2[0]);
            //string test = UserInput.legs[0].maneuvers[3].getMap();
            //List<Maneuver> TempManeuvers = UserInput.legs[0].maneuvers;

            //string var = TempManeuvers[0].iconUrl;

            //foreach (var item in TempManeuvers)
            //    UserManeuvers.Add(item);

            //foreach (var items in UserManeuvers)
            //    Narrative.Add(items.narrative);
            //////////////////////////////////
           
        }


        private void Loading()
        {
            ProgressBar.Visibility = Visibility.Visible;
            bool temp = ProgressBar.IsVisible;
                
        }

        private void NotLoading()
        {
            ProgressBar.Visibility = Visibility.Collapsed;
        }


        //aarnold 3/19
        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.DataContext = this;
            settingsWindow.Show();
        }


        //TODO last iteration
        private void ShowMap(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            var IS = sender as ItemsControl;
            var type = e.OriginalSource;
        }

        private void AddAddresses(object sender, RoutedEventArgs e)
        {
            Addresses.Items.Add(new AddressLine());
        }

        //jyoder26 4/16 Reference: IV E 1

        private void ToggleSideBar(object sender, RoutedEventArgs e)
        {
            if (Collapsed == true)
            {
                //Show
                Storyboard sb = new Storyboard();

                DoubleAnimation slide = new DoubleAnimation();
                DoubleAnimation slideTab = new DoubleAnimation();
                slide.To = SidebarWidth;
                slide.From = Sidebar.Width;
                slideTab.To = SidebarWidth;
                slideTab.From = Side.Width;
                slide.Duration = new Duration(TimeSpan.FromMilliseconds(200.0));
                slideTab.Duration = new Duration(TimeSpan.FromMilliseconds(200.0));

                //Set Target
                Storyboard.SetTarget(slide, Sidebar);
                Storyboard.SetTargetProperty(slide, new PropertyPath("Width"));
                Storyboard.SetTarget(slideTab, Side);
                Storyboard.SetTargetProperty(slideTab, new PropertyPath("Width"));

                //Start Animation
                sb.Children.Add(slide);
                sb.Children.Add(slideTab);
                
                sb.Begin();
                Sidebar.Width = CollapsedSidebarWidth;
                HighLightButtons.Visibility = Visibility.Visible;
                PointsGrids.Visibility = Visibility.Visible;
                AddressGrid.Visibility = Visibility.Visible;
                Buttons.Visibility = Visibility.Visible;
                Directions.Visibility = Visibility.Visible;
                DrivingDirections.Visibility = Visibility.Visible;
                Collapsed = false;
            }
            else
            {

                //Collapse
                Storyboard sb = new Storyboard();

                DoubleAnimation slide = new DoubleAnimation();
                DoubleAnimation slideTab = new DoubleAnimation();
                slide.To = 50;
                slide.From = 300;
                slideTab.To = 50;
                slideTab.From = 300;
                slide.Duration = new Duration(TimeSpan.FromMilliseconds(200.0));
                slideTab.Duration = new Duration(TimeSpan.FromMilliseconds(200.0));

                Storyboard.SetTarget(slide, Sidebar);
                Storyboard.SetTargetProperty(slide, new PropertyPath("Width"));
                Storyboard.SetTarget(slideTab, Side);
                Storyboard.SetTargetProperty(slideTab, new PropertyPath("Width"));

                //Start Animation
                sb.Children.Add(slide);
                sb.Children.Add(slideTab);
                

                sb.Begin();
                Sidebar.Width = SidebarWidth;
                HighLightButtons.Visibility = Visibility.Collapsed;
                PointsGrids.Visibility = Visibility.Collapsed;
                AddressGrid.Visibility = Visibility.Collapsed;
                Buttons.Visibility = Visibility.Collapsed;
                Directions.Visibility = Visibility.Collapsed;
                DrivingDirections.Visibility = Visibility.Collapsed;
                Collapsed = true;
            }
        }

        private void AddLatLng(object sender, RoutedEventArgs e)
        {
            LatLongPoints.Items.Add(new LatLngControl());
        }

    }
}​
