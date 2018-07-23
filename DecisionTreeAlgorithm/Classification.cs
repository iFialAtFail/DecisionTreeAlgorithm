using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeAlgorithm
{
    public class Classification
    {
        public static List<string> Values { get; set; }
        public string Value { get; set; }
        public static void CreateClassification(List<string> values)
        {
            Values = values;
        }
        
    }
}
