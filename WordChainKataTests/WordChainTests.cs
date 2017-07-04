using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChainKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WordChainKata.Tests
{
    [TestClass()]
    public class WordChainTests
    {
        [TestMethod()]
        public void should_return_word_chain_from_dictionary()
        {
            //setup
            List<string> dictionary = new List<string>();
            WordChain wordChain = new WordChain(dictionary, "lead", "gold");

            //act
            List<string> result = wordChain.GetChain();

            //assert
            Assert.AreEqual(result, "lead,load,goad,gold");
        }
    }
}