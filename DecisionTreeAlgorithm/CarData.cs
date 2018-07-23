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
            string path = @"..\..\car.txt";
            if (File.Exists(path))
            {
                var lines = File.ReadAllLines(path);
                foreach (var line in lines)
                {
                    var tokens = line.Split(',');
                    retData.Add(tokens);
                }
            }
           
            return retData.ToArray();
        }

        


    }
}
