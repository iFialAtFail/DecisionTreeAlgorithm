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

        private static string[] buyingValues = new string[] { "vhigh", "high", "med", "low" };
        private static Attribute buying = new Attribute("buying", buyingValues.ToList(), 0);

        private static string[] maintValues = new string[] { "vhigh", "high", "med", "low" };
        private static Attribute maint = new Attribute("maint", maintValues.ToList(), 1);

        private static string[] doorsValues = new string[] { "2", "3", "4", "5more" };
        private static Attribute doors = new Attribute("doors", doorsValues.ToList(), 2);

        private static string[] personsValues = new string[] { "2", "3", "more" };
        private static Attribute persons = new Attribute("persons", personsValues.ToList(), 3);

        private static string[] lug_boot_values = new string[] { "small", "med", "big" };
        private static Attribute lug_boot = new Attribute("lug_boot", lug_boot_values.ToList(), 4);

        private static string[] safetyValues = new string[] { "low", "med", "high" };
        private static Attribute safety = new Attribute("safety", safetyValues.ToList(), 5);


        static string[] classes = new string[] { "unacc", "acc", "good", "vgood" };

        static void Main(string[] args)
        {
            string[][] theData = CarData.GetData();
            DecisionTree decisionTree = new DecisionTree(classes, theData);
            decisionTree.CreateTree();
            Console.WriteLine(decisionTree.Classify(new string[] { "vhigh", "vhigh", "3" , "2", "med", "high"}));
            Console.ReadKey();
        }


    }
}
