using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace _2ndTask
{
    class Program
    {
        static Random rn = new Random();
        public static Dictionary<int, string> olvassTxt = new Dictionary<int, string>();
        public const string connectionString = "server=localhost; port=3308; user id=root; password=; database=cs_beugro; CharSet=utf8;";
        static string fileName = @"C:\Users\Admin\Documents\GitHub\Beugro\2nd task\2ndTask\2ndTask\results.txt";
        static StreamWriter sw = new StreamWriter((new FileStream(fileName, FileMode.Open)),  Encoding.UTF8);

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
            
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            
            sw.WriteLine("Tulajdonos" + "\t" + "Márka" + "\t" + "Típus");
            for (int i = 0; i < user_id_list.Count; i++)
            {
                MySqlCommand cmd_database = new MySqlCommand(String.Format("SELECT user.name, car.brand, car.model FROM user, car, user_car WHERE user.id = user_car.user AND user_car.car = car.id AND user.id = {0}", user_id_list[i]), connection);
                MySqlDataReader dr = cmd_database.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                                sw.WriteLine(dr.GetString(0) + "\t" + dr.GetString(1) + "\t" + dr.GetString(2));
                                Console.WriteLine(dr.GetString(0) + "\t" + dr.GetString(1) + "\t" + dr.GetString(2));
                        
                    }
                }
                dr.Close();
            }
            sw.Close();
            Console.ReadKey();
        }
    }
}
