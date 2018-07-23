using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTreeAlgorithm
{
    public class Node
    {
        public string[][] Data { get; set; }
        private List<Node> childNodes = new List<Node>();
        public Attribute AttributeForSplit;
        public Classification classification;
        private float acceptableFloatingPointError = .002f;
        public string Value { get; set; }

        public float Entropy { get; set; }
        public bool IsLeaf { get; set; }

        public Node(string[][] data)
        {
            this.Data = data;
            Entropy = Node.CalculateEntropy(data);
            CheckIfLeaf(Entropy);
        }

        public Node(string[][] data, string value) : this(data)
        {
            this.Value = value;
        }

        //add isLeaf property
        //entropy property

        public void Split()//string[][] subset)
        {
            setAttributeToSplitOn();
            if (AttributeForSplit != null)
                Console.WriteLine("Attribute to split on: " + AttributeForSplit.Name);
            createChildNodes(AttributeForSplit, Data);
            foreach (var child in childNodes)
            {
                if (child.IsLeaf) Console.WriteLine("New leaf with value of " + child.Value);
                else
                {
                    child.Split();
                }
            }
            //for each child (who has a separate value, call the subset method or whatever. Get them their specific data)
            //for each child, if pure STOP
            //else call Split with their new subsets or whatever
        }

        /// <summary>
        /// Creates the child nodes of the attribute, initialized with the appropriate data sets.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="dataToSplit"></param>
        private void createChildNodes(Attribute attribute, string[][] dataToSplit)
        {
            foreach (var value in attribute.Values)
            {
                var data = CreateSubset(dataToSplit, attribute, value);
                if (data == null || data.GetLength(0) == 0) continue;
                var child = new Node(data, value);
                childNodes.Add(child);
            }
        }

        /// <summary>
        /// Goes through all available attributes in the master list and 
        /// checks what the information gain is on them. It chooses the attribute
        /// with the highest gain and sets this node's attribute to split on to it.
        /// </summary>
        public void setAttributeToSplitOn()
        {
            Attribute attributeToSplitOn = null;
            float infoGain = int.MinValue;
            foreach (Attribute attr in Attribute.AllAttributes)
            {
                var currentGain = Gain(Data, attr);
                if (currentGain > infoGain)
                {
                    infoGain = currentGain;
                    attributeToSplitOn = attr;
                }
            }
            this.AttributeForSplit = attributeToSplitOn;
        }

        /// <summary>
        /// The information gain if we choose this attribute and split on it.
        /// </summary>
        /// <param name="subset"></param>
        /// <param name="att"></param>
        /// <returns></returns>
        public float Gain(string[][] subset, Attribute att)
        {
            if (subset.GetLength(0) == 0) return 0;
            var beforeSplitEntropy = Node.CalculateEntropy(subset);
            //summation
            float summation = 0;
            foreach (var value in att.Values)
            {
                //sv is the subset of the value of the attribute
                var Sv = CreateSubset(subset, att,value);
                if (Sv == null) continue;
                summation += (float)Sv.GetLength(0) / (float)subset.GetLength(0) * Node.CalculateEntropy(Sv);

            }
            return beforeSplitEntropy - summation;
        }

        public static float CalculateEntropy(string[][] subset)
        {

            float entropy = 0;
            float totalRecords = subset.GetLength(0);//data only contains rows of the AtributeValue of this node.
            if (totalRecords == 0) return 0;
            Dictionary<string, int> classifiedInstances = new Dictionary<string, int>();

            //Initialize count dictionary which is for each class possible (in this case yes/no)
            for (int i = 0; i < Classification.Values.Count; i++)
            {
                classifiedInstances.Add(Classification.Values[i], 0);
            }

            //for each classification type, count all of the rows grouped by classifier
            for (int i = 0; i < subset.GetLength(0); i++) // for every row of this nodes subset
            {

                var classifiedAs = subset[i][subset[i].Length - 1];

                classifiedInstances[classifiedAs] += 1; //for each row that is all this node's attribute, increment that value's count.

            }

            //use the counts to determine probability of the attribute value being of a certain class.
            foreach (var classifier in classifiedInstances)
            {
                float probabilityOfClass = (float)classifier.Value / (float)totalRecords;
                if (probabilityOfClass == 0)
                {
                    continue; //Don't add any entropy if we're pure on this classifier.
                }
                float logOfProb = (float)Math.Log(probabilityOfClass, 2);
                entropy -= (probabilityOfClass * logOfProb);
            }
            return entropy;

        }

        private void CheckIfLeaf(float entropy)
        {
            if (entropy < (0 + acceptableFloatingPointError))
            {
                classification = new Classification();
                classification.Value = Data[0][Data[0].Length - 1];// if we are pure, we know all the rows have the same classification. Just use that.
                IsLeaf = true;
            }
        }

        public string[][] CreateSubset(string[][] data, Attribute attr, string value)
        {
            if (data == null || data.GetLength(0) == 0) return null;
            //return all appropiate data for the new node.
            List<string[]> subset = new List<string[]>();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                if (data[i][attr.ColumnIndex].Equals(value))
                {
                    subset.Add(data[i]);
                }
            }
            if (subset.Count == 0) return null;
            return subset.ToArray();
        }

        public Classification Classify(string[] inputRecord)
        {
            //if (isLeaf) return classification;
            //if () check the new record for my attribute
            //and go to the child that has that value and call classify
            if (IsLeaf)
                return classification;

            if (this.AttributeForSplit == null)
            {
                Console.WriteLine("Not a leafe and attribute was null. Something bad happened here.");
                return null;
            }
            else
            {
                string value = inputRecord[AttributeForSplit.ColumnIndex];
                foreach (var child in childNodes)
                {
                    if (child.Value != null && child.Value == value)
                    {
                        return child.Classify(inputRecord);
                    }
                }
                return null;
            }


        }
    }
}
