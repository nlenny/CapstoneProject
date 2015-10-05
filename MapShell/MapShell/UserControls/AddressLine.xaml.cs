using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MapShell.UserControls
{
    /// <summary>
    /// Interaction logic for AddressLine.xaml
    /// </summary>
    public partial class AddressLine : UserControl
    {
        //jyoder 3/28
        public enum StateEnum
        {
            [Description("Alabama")]
            AL,

            [Description("Alaska")]
            AK,

            [Description("Arkansas")]
            AR,

            [Description("Arizona")]
            AZ,

            [Description("California")]
            CA,

            [Description("Colorado")]
            CO,

            [Description("Connecticut")]
            CT,

            [Description("D.C.")]
            DC,

            [Description("Delaware")]
            DE,

            [Description("Florida")]
            FL,

            [Description("Georgia")]
            GA,

            [Description("Hawaii")]
            HI,

            [Description("Iowa")]
            IA,

            [Description("Idaho")]
            ID,

            [Description("Illinois")]
            IL,

            [Description("Indiana")]
            IN,

            [Description("Kansas")]
            KS,

            [Description("Kentucky")]
            KY,

            [Description("Louisiana")]
            LA,

            [Description("Massachusetts")]
            MA,

            [Description("Maryland")]
            MD,

            [Description("Maine")]
            ME,

            [Description("Michigan")]
            MI,

            [Description("Minnesota")]
            MN,

            [Description("Missouri")]
            MO,

            [Description("Mississippi")]
            MS,

            [Description("Montana")]
            MT,

            [Description("North Carolina")]
            NC,

            [Description("North Dakota")]
            ND,

            [Description("Nebraska")]
            NE,

            [Description("New Hampshire")]
            NH,

            [Description("New Jersey")]
            NJ,

            [Description("New Mexico")]
            NM,

            [Description("Nevada")]
            NV,

            [Description("New York")]
            NY,

            [Description("Ohio")]
            OH,

            [Description("Oklahoma")]
            OK,

            [Description("Oregon")]
            OR,

            [Description("Pennsylvania")]
            PA,

            [Description("Rhode Island")]
            RI,

            [Description("South Carolina")]
            SC,

            [Description("South Dakota")]
            SD,

            [Description("Tennessee")]
            TN,

            [Description("Texas")]
            TX,

            [Description("Utah")]
            UT,

            [Description("Virginia")]
            VA,

            [Description("Vermont")]
            VT,

            [Description("Washington")]
            WA,

            [Description("Wisconsin")]
            WI,

            [Description("West Virginia")]
            WV,

            [Description("Wyoming")]
            WY

        }

        public IEnumerable<StateEnum?> StateEnumValues
        {
            get
            {
                return Enum.GetValues(typeof(StateEnum)).Cast<StateEnum?>();
            }
        }
        //jyoder 3/28

        public AddressLine()
        {
            InitializeComponent();
            DataContext = this;

            //jyoder 4/9 set the selected item to the first enum
            State.SelectedItem = StateEnum.AK;
        }

        private void OnFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(AddressLine1) && AddressLine1.Text == "Address Line 1")
            {
                AddressLine1.Text = "";
                AddressLine1.Opacity = 1;
            }


            if (e.Source.Equals(AddressLine2) && AddressLine2.Text == "Address Line 2")
            {
                AddressLine2.Text = "";
                AddressLine2.Opacity = 1;
            }


            if (e.Source.Equals(City) && City.Text == "City")
            {
                City.Text = "";
                City.Opacity = 1;
            }


            if (e.Source.Equals(ZIP) && ZIP.Text == "Zip Code")
            {
                ZIP.Text = "";
                ZIP.Opacity = 1;
            }
                
        }

        private void OutFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source.Equals(AddressLine1) && AddressLine1.Text == "")
            {
                    AddressLine1.Text = "Address Line 1";
                    AddressLine1.Opacity = .7;
            }


            if (e.Source.Equals(AddressLine2) && AddressLine2.Text == "")
            {
                    AddressLine2.Text = "Address Line 2";
                    AddressLine2.Opacity = .7;
            }


            if (e.Source.Equals(City) && City.Text == "")
            {
                    City.Text = "City";
                    City.Opacity = .7;
            }

            if (e.Source.Equals(ZIP) && ZIP.Text == "")
            {
                    ZIP.Text = "Zip Code";
                    ZIP.Opacity = .7;
            }
                
        }
        //jyoder 4/7 REFERENCE: IV B 1
        private void Remove(object sender, RoutedEventArgs e)
        {
            ((ItemsControl)this.Parent).Items.Remove(this);
        }
    }
}
