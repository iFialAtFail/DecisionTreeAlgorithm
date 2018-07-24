/*
 * This implementation of decision tree is created for Ferris State University
 * SENG 397 Machine Learning. I utilized the videos on youtube at the following
 * link: https://www.youtube.com/watch?v=eKD5gxPPeY0&list=PLBv09BD7ez_4temBw7vLA19p3tdQH6FYO
 * 
 * This implementation uses the dataset at the following link: https://archive.ics.uci.edu/ml/datasets/car+evaluation
 * 
 * This code is purely academic at this point and not optimized nor following best practices
 * please use this code at your own risk.
 * 
 * The dataset is about 1700 rows worth of data
 * and the tree that this generates is not pruned and
 * therefore most likely extremely over-fit to the data.
 * 
 * The number of leaves for this tree are 296 with the deepest
 * level being 14 levels deep. However, the average level of this tree is 8.41
 * levels deep, which gives me hope that it's got some sort of accuracy.
 * 
 * I've converted the dataset into something that weka can use and 
 * created a J48 tree from the data. The number of leaves for it's tree are 131
 * and the "size" of the tree is 182. The accuracy of the J48 tree is 92.36% using 10 fold
 * cross validation.
 */
namespace DecisionTreeAlgorithm
{
    using System;
    using System.Linq;
    class Program
    {
        /// <summary>
        /// Toy data set the tree was originally designed on. This was
        /// what I validated the tree on to be correct.
        /// </summary>
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

        private static string[] personsValues = new string[] { "2", "4", "more" };
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
            Console.WriteLine(decisionTree.Classify(new string[] { "vhigh", "vhigh", "3", "2", "med", "high" }));
            Console.WriteLine();
            Console.WriteLine();
            decisionTree.PrintErrors();
            Console.ReadKey();
        }


    }
}
