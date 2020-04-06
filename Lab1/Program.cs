using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ConsoleApp1
{
      class Program
    {
       static void Main(string[] args)
        {
            var data = ProcessCSV("data.csv");
            foreach (var ndata in data)
            {
                int result = String.Compare(ndata.msisdn_origin, Cost.num);
                if (result == 0)
                {
                    string x = ndata.call_duration;
                    x = x.Replace ('.',',');
                    float d = Convert.ToSingle(x);
                    float costt = (d * Cost.origin)-Cost.free;
                    if (costt > 0)
                    {
                        Console.WriteLine("Cost for phone:"+"\n"+ costt + "\n");
                        
                    }
                    string b = ndata.sms_number;
                    
                    float costs = Convert.ToSingle(b) * Cost.sms;
                    Console.WriteLine("Cost for sms:" + "\n" + costs);
                                
                   
                }
                
            }
            Console.ReadLine();
        }
        private static List<Data> ProcessCSV(string path)
        {
            return File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(Data.ParseRow).ToList();
        }
    }
    public class Data
    {
        public string timestamp { get; set; }
        public string msisdn_origin { get; set; }
        public string msisdn_dest { get; set; }
        public string call_duration { get; set; }
        public string sms_number { get; set; }

        internal static Data ParseRow (string row)
        {
            var columns = row.Split(',');
            
                return new Data()
                {
                    timestamp = columns[0],
                    msisdn_origin = columns[1],
                    msisdn_dest = columns[2],
                    call_duration = columns[3],
                    sms_number = columns[4]
                }; 
        }
    }
    public class Cost
    {
        internal const float origin = 2;
        internal const float sms = 2;
        internal const float free = 40;
        internal const string num = "915783624";

      

    }
    
}
