using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem0139
    {
        [TestMethod]
        public void Case1()
        {
            WordBreak("leetcode", new List<string>() { "leet", "code" })
                .IsTrue();
        }

        [TestMethod]
        public void Case2()
        {
            WordBreak("applepenapple", new List<string>() { "apple", "pen" })
                .IsTrue();
        }

        [TestMethod]
        public void Case3()
        {
            WordBreak("catsandog", new List<string>() { "cats", "dog", "sand", "and", "cat" })
                .IsFalse();
        }

        [TestMethod]
        public void Case4()
        {
            WordBreak("s", new List<string>() { "s" })
                .IsTrue();
        }

        [TestMethod]
        public void Case5()
        {
            WordBreak("andcatsdog", new List<string>() { "cats", "dog", "sand", "and", "cat" })
                .IsTrue();
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            var dp = new bool[s.Length + 1];
            dp[0] = true;

            for (int tail = 1; tail <= s.Length; tail++)
            {
                for (int head = 0; head < tail; head++)
                {
                    // head‚Ì’¼‘O‚Ü‚Å•ªŠ„‚É¬Œ÷‚©‚Âhead‚©‚çtail‚Ü‚Å‚Ì•¶Žš‚ª’PŒê‚Æ‚µ‚ÄŽ«‘‚É“o˜^‚³‚ê‚Ä‚¢‚é‚È‚ç‚Î
                    if (dp[head] && wordDict.Contains(s[head..tail]))
                    {
                        // Œ»Ý‚Ìtail‚Ü‚Å•ªŠ„¬Œ÷‚Æ‚µAtail‚ðL‚Î‚µ‚Ä‚¢‚­
                        dp[tail] = true;
                        break;
                    }
                }
            }

            return dp[s.Length];
        }
    }
}