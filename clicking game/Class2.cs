using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace clicking_game
{
    
    class UserDataAPI
    {

        /// <summary>
        /// Handles the coins, multipliers, and autoclicker speed.
        /// Use handleBooleans for handling the 
        /// 
        /// handleSimplevars returns an array that looks something like this.
        /// 
        /// [coins, multiplier, autoclicker_speed]
        /// 
        /// handleSimpleConVars returns an array that looks like this.
        /// 
        /// [allow addons, owns autoclicker]
        /// </summary>
        /// <returns></returns>
        public int[] handleSimpleVars()
        {
            int c = 0; int m = 1; int aspe = 5;
            
            if (File.Exists("save/autosave.txt"))
            {
                /// initial preload sequence (player data)
                string line1 = File.ReadLines("save/autosave.txt").First(); // gets the first line from file.
                string line2 = File.ReadLines("save/autosave.txt").ElementAt(1); // gets the first line from file.
                string line3 = File.ReadLines("save/autosave.txt").ElementAt(2); // gets the first line from file.
                string line4 = File.ReadLines("save/autosave.txt").ElementAt(3); // gets the first line from file.
                string line5 = File.ReadLines("save/autosave.txt").ElementAt(4); // gets the first line from file.

                c = int.Parse(line1);
                m = int.Parse(line2);
                aspe = int.Parse(line4);
                
            }
            int[] array = { c, m, aspe };
            return array;
        }
        public bool[] handleConVars()
        {
            bool owns_auto_mutable=false; bool allow_addons_mutable=false;
            if (File.Exists("save/autosave.txt"))
            {
                /// initial preload sequence (player data)
                string line1 = File.ReadLines("save/autosave.txt").First(); // gets the first line from file.
                string line2 = File.ReadLines("save/autosave.txt").ElementAt(1); // gets the first line from file.
                string line3 = File.ReadLines("save/autosave.txt").ElementAt(2); // gets the first line from file.
                string line4 = File.ReadLines("save/autosave.txt").ElementAt(3); // gets the first line from file.
                string line5 = File.ReadLines("save/autosave.txt").ElementAt(4); // gets the first line from file.

                allow_addons_mutable = bool.Parse(line3);
          
                owns_auto_mutable = bool.Parse(line5);
            }
            bool[] arr = { allow_addons_mutable, owns_auto_mutable };
            return arr;
        }
    }
    class UserManipAPI
    {
        int count;
        int multi;
        bool allow_addons;
        int auto_speed;
        bool ownauto;
        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
        /// <summary>
        ///  Loads the data and adds it to cache
        ///  Use this before any data manipulation!
        /// </summary>
        public void LoadData()
        {
            count = int.Parse(File.ReadLines("save/autosave.txt").ElementAt(0));
            multi = int.Parse(File.ReadLines("save/autosave.txt").ElementAt(1));
            allow_addons = bool.Parse(File.ReadLines("save/autosave.txt").ElementAt(2));
            auto_speed = int.Parse(File.ReadLines("save/autosave.txt").ElementAt(3));
            ownauto = bool.Parse(File.ReadLines("save/autosave.txt").ElementAt(4));
        }
        public void SwitchData(int c = 0, int mul = 1, bool allowadds = false, int aspeed = 5, bool ownsauto = false)
        {
            File.Delete("save/autosave.txt");
            StreamWriter f = File.CreateText("save/autosave.txt");
                f.WriteLine(c + "\n" + mul + "\n" + allowadds.ToString() + "\n" + aspeed + "\n" + ownsauto);
            f.Close();

        }
        public void AddPoints(int add)
        {
            lineChanger((count + add).ToString(), "save/autosave.txt", 0);
        }
    }
}
