using ChainingAssertion;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 文字列 s が与えられたとき、文字の繰り返しのない最長の部分文字列の長さを求めよ。
    /// </summary>
    public class Problem0003
    {
        [Fact]
        public void Case1()
        {
            LengthOfLongestSubstring("abcabcbb")
                .Is(3);
        }

        [Fact]
        public void Case2()
        {
            LengthOfLongestSubstring("bbbbb")
                .Is(1);
        }

        [Fact]
        public void Case3()
        {
            LengthOfLongestSubstring("pwwkew")
                .Is(3);
        }

        public int LengthOfLongestSubstring(string s)
        {
            // 0文字だった場合は連続する文字はないので0を返す
            if (s.Length == 0)
            {
                return 0;
            }

            var dictionary = new Dictionary<char, int>();
            int max = 0;

            // ポインタを二つ用意して部分文字列の探索を行う
            for (int right = 0, left = 0; right < s.Length; ++right)
            {
                // 該当の文字が既出だった場合
                if (dictionary.ContainsKey(s[right]))
                {
                    // 既出の文字を最後に確認したインデックスの次を部分文字列の開始とする
                    left = Math.Max(left, dictionary[s[right]] + 1);
                }

                // 該当の文字の最終出現位置を更新する
                dictionary[s[right]] = right;

                // 右のインデックスと左のインデックスの差を文字数として最大値を更新する
                max = Math.Max(max, right - left + 1);
            }

            return max;
        }
    }
}