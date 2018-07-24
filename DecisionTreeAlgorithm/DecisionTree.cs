using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeAlgorithm
{
    public class DecisionTree
    {
        private string[] classes;
        private string[][] data;
        private Dictionary<string, int> attributeToIndex = new Dictionary<string, int>();
        private Node root;

        public static List<Node> leaves = new List<Node>();

        public DecisionTree(string[] classes, string[][] data)
        {
            this.classes = classes;
            this.data = data;
            
        }

        public Node CreateTree()
        {
            Classification.Values = classes.ToList();
            Node root = new Node(data);
            root.TreeLevel = 0;
            root.Split();
            this.root = root;
            return root;
        }

        public string Classify(string[] record)
        {
            return root.Classify(record).Value;
        }

        public void PrintErrors()
        {
            Console.WriteLine("The number of leaves of this tree are: " + leaves.Count);
            int deepestLevel = int.MinValue;
            foreach (var leaf in leaves)
            {
                if (leaf.TreeLevel > deepestLevel)
                {
                    deepestLevel = leaf.TreeLevel;
                }
            }
            Console.WriteLine("The deepest level of this tree is: " + deepestLevel);

            int levelsTotal = 0;
            foreach (var leaf in leaves)
            {
                levelsTotal += leaf.TreeLevel;
            }
            float averageLevelLeaf = (float)levelsTotal / (float)leaves.Count;
            Console.WriteLine("The average level of this tree is: " + averageLevelLeaf);


        }
        
    }
}
