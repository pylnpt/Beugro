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
        public static Dictionary<int, string> olvassTxt = new Dictionary<int, string>();

        static HashSet<int> rnList(int db, int end)
        {
            var results = new HashSet<int>();
            while (results.Count < db)
            {
                results.Add(rn.Next(1, end));
            }

            return results;
        } 
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
                if (int.TryParse(key, out int result))
                {
                    olvassTxt.Add(int.Parse(key), value);
                }
                
            }
            sr.Close();
        }

        static List<string> searchedValues(HashSet<int> nums, Dictionary<int,string> dict)
        {
            List<string> results = new List<string>();
            int x; 

            foreach (KeyValuePair<int, string> key in dict)
            {
                foreach (var num in nums)
                {
                    if (num == key.Key)
                    {
                        if (int.TryParse(key.Value, out x) && 0 < x)
                            results.Add(key.Value);
                    }
                        
                }
            }
            return results;
        }
         
        static void Main(string[] args)
        {
            var list = rnList(10, 50);
            readTxt("olvass.txt");
            List<string>user_id_list = searchedValues(list, olvassTxt);
            foreach (var item in user_id_list)
            {
                Console.WriteLine(item);
            }

            

            Console.ReadKey();
        }
    }
}
