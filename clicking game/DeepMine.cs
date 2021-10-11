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
    public partial class DeepMine : Form
    {
        int count = 0;
        int multipl = 1;
        bool allow_unsafe_addons = false;
        int autoclicker_speed = 5;
        bool owns_autoclicker = true;
        int myiron = 0;

        public async void SecretLoop()
        {
            while (true)
            {
                if (myiron > 600)
                {
                    this.button2.Visible = true;
                }
                await Task.Delay(2000);
            }
        }
        public DeepMine()
        {

            InitializeComponent();

           
            if (File.Exists("save/autosave.txt")) {
                /// initial preload sequence (player data)
                string line1 = File.ReadLines("save/autosave.txt").First(); // gets the first line from file.
                string line2 = File.ReadLines("save/autosave.txt").ElementAt(1); // gets the first line from file.
                string line3 = File.ReadLines("save/autosave.txt").ElementAt(2); // gets the first line from file.
                string line4 = File.ReadLines("save/autosave.txt").ElementAt(3); // gets the first line from file.
                string line5 = File.ReadLines("save/autosave.txt").ElementAt(4); // gets the first line from file.

                count = int.Parse(line1);
                multipl = int.Parse(line2);
                allow_unsafe_addons = bool.Parse(line3);
                autoclicker_speed = int.Parse(line4);
                owns_autoclicker = bool.Parse(line5);
            }

            // ore resources

            if (File.Exists("save/minedata.txt"))
            {
                string iron = File.ReadLines("save/minedata.txt").First();
                myiron = int.Parse(iron);
            } else
            {
                File.CreateText("save/minedata.txt").Write(myiron);
            }
            this.label3.Text = "Iron: " + myiron.ToString();
            SecretLoop();
        }
        
        public void save_data()
        {
            StreamWriter f = new StreamWriter("save/autosave.txt");
            f.WriteLine(count);
            f.WriteLine(multipl);
            f.WriteLine(allow_unsafe_addons);
            f.WriteLine(autoclicker_speed);
            f.WriteLine(owns_autoclicker);
            f.Close();

            StreamWriter ores = new StreamWriter("save/minedata.txt");
            ores.WriteLine(myiron);
            ores.Close();
        }

        public void update_data()
        {
            this.label3.Text = "Iron: " + myiron.ToString();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            int earend = new Random().Next(0, 12);
            myiron += earend;
            this.label2.Text = "You earned " + earend.ToString() + " Iron from your mine!";
            update_data();
            this.label2.Visible = true;
            await Task.Delay(2000);
            this.label2.Visible = false;
            save_data();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SecRoom().Show();
        }
    }
}
