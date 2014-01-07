using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TrieTreeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<String> listOfWords = Program.getListOfWordFromFile();
            TrieTree tree = new TrieTree(listOfWords);
            Dictionary<String, int> dictWithLongestConcatedWords = tree.getWordMadeByValidWords(listOfWords);

            using (StreamWriter sw = new StreamWriter("D:\\result.txt"))
            {
                foreach (KeyValuePair<String, int> kvPair in dictWithLongestConcatedWords)
                {
                    sw.WriteLine(kvPair.Key + " " + kvPair.Key.Length + " " + kvPair.Value);
                }
            };
        }

        //Retrieves all lines and removes whitespace and empty lines from file.
        public static List<String> getListOfWordFromFile()
        {
            List<String> listOfStrings = new List<String>();

            String[] arrayOfWords = File.ReadAllLines("wordsforproblem.txt"); //).Cast<String>().ToList();
            foreach (String word in arrayOfWords)
            {
                //Console.WriteLine(word);
                if (word == String.Empty)
                {
                    continue;
                }

                listOfStrings.Add(word.Replace(" ", string.Empty).ToLower());
            }

            return listOfStrings;
        }
    }
}
