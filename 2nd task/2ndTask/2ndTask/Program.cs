using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2ndTask
{
    class Program
    {
        static Random rn = new Random();
        public static Dictionary<string, string> olvassTxt = new Dictionary<string, string>();

        static HashSet<int> rnList(int db, int end)
        {
            var results = new HashSet<int>();
            while (results.Count < db)
            {
                results.Add(rn.Next(1, end));
            }

            return results;
        } // I have used HashSet because in this way I don't have to worry about duplicates because it removes them.

        static void readTxt(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string row;
            string key;
            string value;
            while ((row = sr.ReadLine()) != null)
            {
                string[] data = row.Split('|');
                key = data[0];
                value = data[1];
                olvassTxt.Add(key, value);
            }
            sr.Close();
        }

            static void Main(string[] args)
        {
            var list = rnList(10, 50);
            readTxt("olvass.txt");
            

            Console.ReadKey();
        }
    }
}
