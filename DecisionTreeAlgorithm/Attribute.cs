using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeAlgorithm
{
    public class Attribute
    {
        public static List<Attribute> AllAttributes = new List<Attribute>();
        public List<string> Values { get; set; }
        public string Name { get; set; }
        
        /// <summary>
        /// 0 based index 
        /// </summary>
        public int ColumnIndex { get; set; }

        public Attribute(string name, List<string> values, int columnIndex)
        {
            this.Name = name;
            this.Values = values;
            this.ColumnIndex = columnIndex;
            AllAttributes.Add(this);
        }

        public Attribute() { }
    }
}
