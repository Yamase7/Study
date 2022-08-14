using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0387
    {
        [Fact]
        public void Case1()
        {
            FirstUniqChar("leetcode")
                .Is(0);
        }

        [Fact]
        public void Case2()
        {
            FirstUniqChar("loveleetcode")
                .Is(2);
        }

        [Fact]
        public void Case3()
        {
            FirstUniqChar("aabb")
                .Is(-1);
        }

        public int FirstUniqChar(string s)
        {
            // 出現回数を記録するためアルファベット分の配列を用意する
            int[] alphabetIndex = new int[26];

            // 一文字ずつ取り出して対象の文字の出現回数を増やして記録する
            for (int i = 0; i < s.Length; i++)
            {
                alphabetIndex[s[i] - 'a']++;
            }

            // アルファベット順に出現回数を確認する
            for (int i = 0; i < s.Length; i++)
            {
                // 出現回数が一回のみだった場合対象のインデックスを返す
                if (alphabetIndex[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}