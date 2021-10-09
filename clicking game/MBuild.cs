using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clicking_game
{
    public partial class MBuild : Form
    {
        public MBuild()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string coins = this.richTextBox1.Text;
            bool addons = this.checkBox2.Checked;
            bool autoclicker = this.checkBox1.Checked;
            string mul = this.richTextBox2.Text;
            string name = this.richTextBox3.Text;
            Directory.CreateDirectory("mods/" + name + "");
            Directory.CreateDirectory("mods/" + name + "/_append");
            StreamWriter file = File.CreateText("mods/" + name + "/_append/data.txt");
            file.WriteLine(coins);
            file.WriteLine(mul);
            file.WriteLine(addons);
            file.WriteLine("5");
            file.WriteLine(autoclicker);
            file.Close();
        }
    }
}
