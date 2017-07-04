using System;
using System.Collections.Generic;

namespace WordChainKata
{
    public class WordGraph
    {
        private List<string> wordList;

        public WordGraph(List<string> wordList)
        {
            this.wordList = wordList;
        }

         //Build graph on the fly and find shortest path between two words using a breadth-first search.
        public List<string> FindShortestPath(string fromWord, string toWord)
        {
            Queue<string> queue = new Queue<string>();
            IDictionary<string, string> previous = new Dictionary<string, string>();

            queue.Enqueue(fromWord);

            string word = null;
            while (queue.Count!=0 && !(word = queue.Dequeue()).Equals(toWord))
            {
                List<String> nextWords = GetNextWords(word);
                foreach (String nextWord in nextWords)
                {
                    if (!previous.ContainsKey(nextWord))
                    {
                        previous.Add(nextWord, word);
                        queue.Enqueue(nextWord);
                    }
                }
            }

            return GetPath(previous, fromWord, toWord);
        }

        
        //Get all words that can be reached from a given word by changing one letter.
        private List<string> GetNextWords(string word)
        {
            List<string> nextWords = new List<string>();

            foreach (string currentWord in wordList)
            {
                if (CountLetterDifferences(word, currentWord) == 1)
                {
                    nextWords.Add(currentWord);
                }
            }

            return nextWords;
        }

        //Counts the number of different letter between two words.
        private int CountLetterDifferences(string firstWord, string secondWord)
        {
            int count = 0;
            for (int index = 0; index < firstWord.Length; index++)
            {
                if (firstWord[index] != secondWord[index])
                {
                    count++;
                }
            }

            return count;
        }

        //Constructs a path from start word to end word, using predecessor data from a breadth-first search.
        private List<string> GetPath(IDictionary<string, string> previous, string fromWord, string toWord)
        {
            if (!previous.ContainsKey(toWord))
            {
                return null;
            }

            List<string> path = new List<string>();
            String word = toWord;
            while (!word.Equals(fromWord))
            {
                path.Add(word);
                word = previous[word];
            }

            path.Add(fromWord);
            return path;
        }
    }
}