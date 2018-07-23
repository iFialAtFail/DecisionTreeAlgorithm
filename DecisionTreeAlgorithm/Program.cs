using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeAlgorithm
{
    class Program
    {
        static string[][] data = new string[][]
        {
            //             Size   , color,   shape,   class
            new string[] {"medium", "blue", "brick", "yes"},
            new string[] {"small", "red", "sphere", "yes"},
            new string[] {"large", "green", "pillar", "yes"},
            new string[] {"large", "green", "sphere", "yes"},
            new string[] {"large", "red", "pillar", "no"},
            new string[] {"large", "red", "wedge", "no"},
            new string[] {"small", "red", "wedge", "no"}
        };

        private static string[] sizeValues = new string[] { "small", "medium", "large" };
        private static Attribute size = new Attribute("size", sizeValues.ToList(), 0);

        private static string[] colorValues = new string[] { "blue", "red", "green", "brown" };
        private static Attribute color = new Attribute("color", colorValues.ToList(), 1);

        private static string[] shapeValues = new string[] { "brick", "sphere", "pillar", "wedge" };
        private static Attribute shape = new Attribute("shape", shapeValues.ToList(), 2);



        static string[] classes = new string[] { "yes", "no" };

        static void Main(string[] args)
        {

            DecisionTree decisionTree = new DecisionTree(classes, data);
            decisionTree.CreateTree();
            Console.WriteLine(decisionTree.Classify(new string[] { "medium", "green", "pillar" }));
            Console.ReadKey();
        }


    }
}
