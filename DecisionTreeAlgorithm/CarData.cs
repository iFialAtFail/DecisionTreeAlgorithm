using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeAlgorithm
{
    class CarData
    {
        public static string[][] GetData()
        {
            List<string[]> retData = new List<string[]>();
            string path = @"C:\Users\mmanl\Documents\CarData\car.data";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var tokens = line.Split(',');
                    retData.Add(tokens);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (retData.Count > 10)
                {
                    foreach (string item in retData[i])
                    {
                        Console.WriteLine(item + ", " );
                    }
                    Console.WriteLine();
                }
            }
            return retData.ToArray();
        }

        


    }
}
