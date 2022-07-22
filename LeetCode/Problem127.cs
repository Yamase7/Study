using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem127
    {
        [TestMethod]
        public void Case1()
        {
            LadderLength(
                "hit",
                "cog",
                new List<string>()
                {
                    "hot",
                    "dot",
                    "dog",
                    "lot",
                    "log",
                    "cog",
                })
                .Is(5);
        }

        [TestMethod]
        public void Case2()
        {
            LadderLength(
                "hit",
                "cog",
                new List<string>()
                {
                    "hot",
                    "dot",
                    "dog",
                    "lot",
                    "log",
                })
                .Is(0);
        }

        public int LadderLength(
            string beginWord,
            string endWord,
            IList<string> wordList)
        {
            var dict = new HashSet<string>(wordList);
            var vis = new HashSet<string>();
            var queue = new Queue<string>();
            queue.Enqueue(beginWord);
            for (int len = 1; queue.Count != 0; len++)
            {
                for (int i = queue.Count; i > 0; i--)
                {
                    string word = queue.Dequeue();
                    if (word.Equals(endWord)) return len;

                    for (int j = 0; j < word.Length; j++)
                    {
                        char[] ch = word.ToCharArray();
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (c == word[j]) continue;
                            ch[j] = c;
                            string nb = new string(ch);
                            if (dict.Contains(nb) && vis.Add(nb)) queue.Enqueue(nb);
                        }
                    }
                }
            }
            return 0;
        }
    }
}