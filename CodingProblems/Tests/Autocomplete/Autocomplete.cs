using System;
using NUnit.Framework;

namespace CodingProblems.Tests.Autocomplete
{
    /// <summary>
    /// Implement an autocomplete system.
    /// That is, given a query string s and a set of all possible query strings,
    /// return all strings in the set that have s as a prefix.
    ///
    /// For example, given the query string de and the set of strings [dog, deer, deal], return [deer, deal].
    /// </summary>
    [TestFixture]
    public class Autocomplete
    {
        [Test]
        public void Test()
        {
            var words = new[] {"dog", "deer", "deal"};
            var searchTree = new TernaryTree();
            AddWords(searchTree, words);
            
            var result = searchTree.GetAutocompleteWords("de");
            Assert.True(result.Count == 2 && result.Contains("deer") && result.Contains("deal"));
            
            result = searchTree.GetAutocompleteWords("do");
            Assert.True(result.Count == 1 && result.Contains("dog"));
            
            result = searchTree.GetAutocompleteWords("d");
            Assert.True(result.Count == 3 && result.Contains("dog") && result.Contains("deer") &&
                        result.Contains("deal"));
        }

        private void AddWords(TernaryTree tree, string[] words)
        {
            foreach (var word in words)
            {
                tree.Add(word);
            }
        }
    }
}