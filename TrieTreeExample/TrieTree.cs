using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrieTreeExample
{
    class TrieTree
    {
        private Node rootNode = new Node('\0', "");
        private Dictionary<String, List<String>> dictWithPrefixWord = new Dictionary<string, List<string>>();
        private Dictionary<String, int> dictWithPrefixCount = new Dictionary<string, int>();
        private int count;

        public TrieTree(List<String> listOfWords)
        {
            //count = 0;
            foreach (String word in listOfWords)
            {
                if (String.IsNullOrEmpty(word))
                {
                    Console.WriteLine("Empty String!!");
                    continue;
                }

                buildTree(word);
            }
            //Console.WriteLine(count);
        }

        //Build a Trie tree for list of words in file.
        private void buildTree(String singleWord)
        {
            char[] arrayOfLetters = singleWord.ToCharArray();
            char aLetter;
            Node currentNode = rootNode;
            Node nextNode = null;

            for (int i = 0; i < arrayOfLetters.Count(); i++)
            {
                aLetter = arrayOfLetters[i];

                //Conditions check whether the parent node has already a child node with given letter if not create new node with that letter
                //else get it from the parent node.
                if (!currentNode.containsChild(aLetter))
                {
                    nextNode = new Node(aLetter, String.Concat(currentNode.getWord, char.ToString(aLetter)));
                    currentNode.addChild(nextNode);
                }
                else
                {
                    nextNode = currentNode.getChild(aLetter);
                }

                currentNode = nextNode;
            }

            currentNode.isWordValid = true;
            //count++;
        }

        //Retrieves the last node with a valid word in the tree.
        private Node retrieveLastNode(String searchWord)
        {
            char[] arrayOfLetters = searchWord.ToCharArray();
            Node currentNode = rootNode;

            for (int i = 0; i < arrayOfLetters.Count(); i++)
            {
                currentNode = currentNode.getChild(arrayOfLetters[i]);

                if (currentNode == null)
                {
                    return null;
                }

                if (currentNode.isWordValid)
                {
                    return currentNode;
                }
            }

            return currentNode;
        }

        //Checks where word is valid or not, i.e. whether it is present in file as a whole word not a concated word.
        public bool containsValidPrefix(String word)
        {
            Node node = this.retrieveLastNode(word);
            return node != null && node.isWordValid;
        }

        //Returns the dictionary of <word, prefix count> by comparing & traversing the list of words in file to the trie tree.   
        public Dictionary<string, int> getWordMadeByValidWords(List<String> listOfAllWords)
        {
            foreach (String word in listOfAllWords)
            {
                int prefixCount = this.getPrefixCountForWord(word);

                //any word made up of more than one prefix is added to dictionary.
                if (prefixCount > 1)
                    dictWithPrefixCount.Add(word, prefixCount);
            }

            var sortDictWithPrefixCount = from kvPair in dictWithPrefixCount
                                          orderby kvPair.Key.Length descending
                                          select kvPair;

            return sortDictWithPrefixCount.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        //Returns the prefix count of a word given to it.
        private int getPrefixCountForWord(String word)
        {
            int prefixCount = 0;
            String value = String.Empty;
            //List<String> listOfPrefixInWord = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                value += Char.ToString(word[i]);
                if (this.containsValidPrefix(value))
                {
                    //listOfPrefixInWord.Add(value);
                    value = String.Empty;
                    prefixCount++;
                }
            }

            /*if (prefixCount > 1)
            {
                dictWithPrefixWord.Add(word, listOfPrefixInWord);
                Console.WriteLine("Word - " + word + " Count - " + prefixCount);
            }*/

            return prefixCount;
        }
    }
}
