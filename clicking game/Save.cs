using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace clicking_game
{
    class Save
    {
        string f;
        public Save(string file)
        {
            f = file;
        }
        public List<string> Dump()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(File.ReadAllText(f));
            List<string> starr = new List<string>();
            foreach (XmlNode node in xmldoc.DocumentElement.ChildNodes)
            {
                string text = node.InnerText; //or loop through its children as well
                starr.Add(text);
            }
            
            return starr;
        }
    }
}
