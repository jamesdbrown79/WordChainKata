using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChainKata
{
    public class WordChain
    {
        private string firstWord;
        private string lastWord;
        private WordGraph graph;

        public WordChain(List<string> dictionary, string firstWord, string lastWord)
        {
            this.firstWord = firstWord;
            this.lastWord = lastWord;
            this.graph = new WordGraph(dictionary);
        }

        public List<string> GetChain()
        {
            return graph.FindShortestPath(firstWord, lastWord);
        }
    }
}
