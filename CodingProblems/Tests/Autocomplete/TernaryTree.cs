using System;
using System.Collections.Generic;
using System.Text;

namespace CodingProblems.Tests.Autocomplete
{
    public class TernaryTree
    {
        private Node _head;

        private void Add(string word, int index, ref Node node)
        {
            if (node == null)
            {
                node = new Node(word[index], false);
            }

            var cmp = word[index] - node.Value;
            if (cmp < 0)
            {
                Add(word, index, ref node.Left);
            }
            else if (cmp > 0)
            {
                Add(word, index, ref node.Right);
            }
            else
            {
                if (index + 1 == word.Length)
                {
                    node.StringEnd = true;
                }
                else
                {
                    Add(word, index + 1, ref node.Center);
                }
            }
        }

        public void Add(string word)
        {
            if (string.IsNullOrEmpty(word)) throw new ArgumentException("The string can't be null or an empty string");
            Add(word, 0, ref _head);
        }

        public List<string> GetAutocompleteWords(string str)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentException("The string can't be null or an empty string");
            var result = new List<string>();
            var node = GetStartingNode(str);
            AddWordsToList(str, result, node);
            return result;
        }


        private void AddWordsToList(string startString, List<string> wordList, Node node)
        {
            if (node == null) return;
            var word = new StringBuilder(startString);
            word.Append(node.Value);
            if (node.StringEnd) wordList.Add(word.ToString());
            AddWordsToList(startString, wordList, node.Left);
            AddWordsToList(startString, wordList, node.Right);
            node = node.Center;
            AddWordsToList(word.ToString(), wordList, node);
        }

        private Node GetStartingNode(string str)
        {
            if (string.IsNullOrEmpty(str)) throw new ArgumentException("The string can't be null or an empty string");
            var index = 0;
            var node = _head;
            while (node != null)
            {
                var cmp = str[index] - node.Value;
                if (cmp < 0)
                {
                    node = node.Left;
                }
                else if (cmp > 0)
                {
                    node = node.Right;
                }
                else
                {
                    if (++index == str.Length) return node.Center;
                    node = node.Center;
                }
            }

            return null;
        }
    }
}