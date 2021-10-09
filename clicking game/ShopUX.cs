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
            /*int[] data = udapi.handleSimpleVars(); // assign player data values to mutable variables.
            bool[] owns = udapi.handleConVars();*/
            Player ply = new Player();
            this.label2.Text = "Available: " + ply.Coins();

            //UserManipAPI userManip = new UserManipAPI();

            /*userManip.LoadData(); <- add for data MANIPULATION, not data handling.*/
            /*userManip.SwitchData(100, data[1], owns[0], data[2], owns[1]);*/


        }

        
    }
}
