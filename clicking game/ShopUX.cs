using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clicking_game
{
    public partial class ShopUX : Form
    {
        public ShopUX()
        {
            InitializeComponent();
            UserDataAPI udapi = new UserDataAPI(); /// the NEW data API
            
            int[] data = udapi.handleSimpleVars(); // assign player data values to mutable variables.
            bool[] owns = udapi.handleConVars();
            this.label2.Text = "Available: " + data[0].ToString();

            UserManipAPI userManip = new UserManipAPI();

            userManip.LoadData();

            /*userManip.SwitchData(100, data[1], owns[0], data[2], owns[1]);*/
        }

        
    }
}
