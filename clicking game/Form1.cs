using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clicking_game
{
    public partial class Form1 : Form
    {
        int multipl = 1;
        int count = 0;
        int autoclicker_speed = 5;
        bool owns_autoclicker = false;
        bool using_clicker = false;
        bool allow_unsafe_addons = false;

        public async void autoCheck()
        {
            while (true)
            {
                if (File.Exists("save/autosave.txt"))
                {
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
                    this.label2.Text = "Coins: " + count.ToString();
                    this.label3.Text = "Bonus: " + multipl.ToString();
                    this.label5.Text = "AutoClicker Speed: " + autoclicker_speed.ToString();
                    this.button3.Text = "Upgrade Multiplier ($" + (multipl * 2).ToString() + ")";
                    this.checkBox1.Checked = allow_unsafe_addons;
                }
                await Task.Delay(120);
            }
        }
        public async void autoSave()
        {
            while (true)
            {
                if (!Directory.Exists("save"))
                {
                    Directory.CreateDirectory("save");
                }
                StreamWriter f = File.CreateText("save/autosave.txt");
                f.WriteLine(count);
                f.WriteLine(multipl);
                f.WriteLine(allow_unsafe_addons);
                f.WriteLine(autoclicker_speed);
                f.WriteLine(owns_autoclicker);
                f.Close();

                await Task.Delay(10000);
                this.label8.Visible = true;
                await Task.Delay(10000);
                this.label8.Visible = false;
            }
        }

        public Form1()
        {
            InitializeComponent();

            this.Focus();
            if (File.Exists("save/autosave.txt"))
            {
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
                this.label2.Text = "Coins: " + count.ToString();
                this.label3.Text = "Bonus: " + multipl.ToString();
                this.label5.Text = "AutoClicker Speed: " + autoclicker_speed.ToString();
                this.button3.Text = "Upgrade Multiplier ($" + (multipl * 2).ToString() + ")";
                this.checkBox1.Checked = allow_unsafe_addons;
            }
            autoCheck();
            autoSave();
        }

        public void load_data(string file)
        {
            if (File.Exists(file))
            {
                string line1 = File.ReadLines(file).First(); // gets the first line from file.
                string line2 = File.ReadLines(file).ElementAt(1); // gets the first line from file.
                string line3 = File.ReadLines(file).ElementAt(2); // gets the first line from file.
                string line4 = File.ReadLines(file).ElementAt(3); // gets the first line from file.
                string line5 = File.ReadLines(file).ElementAt(4); // gets the first line from file.

                count += int.Parse(line1);
                multipl += int.Parse(line2);
                allow_unsafe_addons = bool.Parse(line3);
                autoclicker_speed = int.Parse(line4);
                owns_autoclicker = bool.Parse(line5);
                this.label2.Text = "Coins: " + count.ToString();
                this.label3.Text = "Bonus: " + multipl.ToString();
                this.label5.Text = "AutoClicker Speed: " + autoclicker_speed.ToString();
                this.button3.Text = "Upgrade Multiplier ($" + (multipl * 2).ToString() + ")";
                this.checkBox1.Checked = allow_unsafe_addons;
                update_data();
                save_data();

            }
        }
        public void replace_data(string file)
        {
            if (File.Exists(file))
            {
                string line1 = File.ReadLines(file).First(); // gets the first line from file.
                string line2 = File.ReadLines(file).ElementAt(1); // gets the first line from file.
                string line3 = File.ReadLines(file).ElementAt(2); // gets the first line from file.
                string line4 = File.ReadLines(file).ElementAt(3); // gets the first line from file.
                string line5 = File.ReadLines(file).ElementAt(4); // gets the first line from file.

                // fix: fix this
                count = int.Parse(line1);
                multipl = int.Parse(line2);
                allow_unsafe_addons = bool.Parse(line3);
                autoclicker_speed = int.Parse(line4);
                owns_autoclicker = bool.Parse(line5);
                this.label2.Text = "Coins: " + count.ToString();
                this.label3.Text = "Bonus: " + multipl.ToString();
                this.label5.Text = "AutoClicker Speed: " + autoclicker_speed.ToString();
                this.button3.Text = "Upgrade Multiplier ($" + (multipl * 2).ToString() + ")";
                this.checkBox1.Checked = allow_unsafe_addons;
                update_data();
                save_data();
            }
        }
        public void update_data()
        {
            this.label2.Text = "Coins: " + count.ToString();
            this.label3.Text = "Bonus: " + multipl.ToString();
            this.button3.Text = "Upgrade Multiplier ($" + (multipl * 2).ToString() + ")";
            this.checkBox1.Checked = allow_unsafe_addons;
        }
        public void save_data()
        {
            StreamWriter f = File.CreateText("save/autosave.txt");
            f.WriteLine(count);
            f.WriteLine(multipl);
            f.WriteLine(allow_unsafe_addons);
            f.WriteLine(autoclicker_speed);
            f.WriteLine(owns_autoclicker);
            f.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add realistic mining
            count += new Random().Next(1, 5) * multipl;
            this.label2.Text = "Coins: " + count.ToString();
            if (Directory.Exists("save"))
            {
                save_data();
                Console.WriteLine("Saved!");
            }
            else
            {
                Console.WriteLine("Creating directory 'save'");
                Directory.CreateDirectory("save");
                save_data();
            }

        }

        public async void poor_Shame()
        {
            this.label4.Visible = true;
            await Task.Delay(2000);
            this.label4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            save_data();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int mcfu = multipl * 2;
            if (count >= mcfu)
            {
                count -= mcfu;
                multipl += 2;
                update_data();
                save_data();
            }
            else
            {
                this.label4.Visible = true;
                await Task.Delay(2000);
                this.label4.Visible = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            allow_unsafe_addons = this.checkBox1.Checked;
            save_data();
            update_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Loading mod...");
            if (Directory.Exists("mods/" + this.richTextBox1.Text))
            {
                Console.WriteLine("Mod loaded. Checking for any appends...");
                if (Directory.Exists("mods/" + this.richTextBox1.Text + "/_append"))
                {
                    load_data("mods/" + this.richTextBox1.Text + "/_append/data.txt");
                }
                if (Directory.Exists("mods/" + this.richTextBox1.Text + "/_replace"))
                {
                    replace_data("mods/" + this.richTextBox1.Text + "/_replace/data.txt");
                }
            }

        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            if (count >= 100000)
            {
                multipl += count;
                count = 0;
                update_data();
                save_data();
            } else
            {
                poor_Shame();
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {

            if (owns_autoclicker)
            {
                using_clicker = true;
                while (using_clicker == true)
                {
                    count += 10 * multipl;
                    update_data();
                    save_data();
                    await Task.Delay(autoclicker_speed * 1000);
                }
            }
            else
            {
                if (count >= 10000 && !owns_autoclicker)
                {
                    count -= 10000;
                    owns_autoclicker = true;
                    update_data();
                    save_data();
                } else
                {
                    poor_Shame();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (count >= 100000)
            {
                if (autoclicker_speed != 1)
                {
                    autoclicker_speed -= 1;
                    update_data();
                    save_data();
                }
            } else
            {
                poor_Shame();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using_clicker = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            count = 0;
            multipl = 1;
            owns_autoclicker = false;
            autoclicker_speed = 5;
            update_data();
            save_data();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new DeepMine().Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new ShopUX().Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Credits c = new Credits();
            
            c.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MBuild mb = new MBuild();
            mb.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            string f = this.openFileDialog1.FileName;
            try
            {
                load_data(f);
            }
            catch (Exception)
            {
                Console.WriteLine("save not found");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (File.Exists("save/minedata.txt"))
            {
                int iron = int.Parse(File.ReadLines("save/minedata.txt").First());
                count += iron * 4;
                save_data();
            }
        }
    }
}
