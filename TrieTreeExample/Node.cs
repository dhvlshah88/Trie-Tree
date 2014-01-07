using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieTreeExample
{
    class Node
    {

        private readonly char letter;
        private readonly String word;
        private Dictionary<char, Node> children = new Dictionary<char, Node>();
        private bool validWord;
        private int occurrenceOfWord = 0;

        public Node(char letter, String word)
        {
            this.letter = letter;
            this.word = word;
            this.validWord = false;
        }

        // Accessor Methods
        public char getLetter
        {
            get
            {
                return letter;
            }
        }

        public String getWord
        {
            get
            {
                return word;
            }
        }

        public bool isWordValid
        {
            get
            {
                return validWord;
            }

            set
            {
                validWord = value;
                if (validWord)
                {
                    this.occurrenceOfWord += 1;
                }
            }
        }

        //Not in use.
        public int wordOccurrence
        {
            get
            {
                return occurrenceOfWord;
            }
        }

        //Gets child based on letter from parent node's dictionary.
        public Node getChild(char key)
        {
            Node node = null;
            this.children.TryGetValue(key, out node);
            return node;
        }

        //Checks whether child node exists or not.
        public bool containsChild(char key)
        {
            //Console.WriteLine(this.children.ContainsKey(key));
            return this.children.ContainsKey(key);
        }

        //Add child node in dictionary.
        public bool addChild(Node childNode)
        {
            char alphabet = childNode.getLetter;
            this.children.Add(alphabet, childNode);
            return true;
        }

        public override string ToString()
        {
            return word;
        }


    }
}
