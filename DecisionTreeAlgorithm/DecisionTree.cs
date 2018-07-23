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

        public DecisionTree(string[] classes, string[][] data)
        {
            this.classes = classes;
            this.data = data;
            
        }

        public Node CreateTree()
        {
            Classification.Values = classes.ToList();
            Node root = new Node(data);
            root.Split();
            this.root = root;
            return root;
        }

        public string Classify(string[] record)
        {
            return root.Classify(record).Value;
        }
        
    }
}
