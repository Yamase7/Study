using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 2つの文字列sとtが与えられたとき、tがsのアナグラムであればtrueをそうでなければfalseを返す。
    /// アナグラムとは異なる単語やフレーズの文字を並べ替えて作られた単語や
    /// フレーズのことで、通常は元の文字をすべて一度だけ使用します。
    /// </summary>
    public class Problem0242
    {
        [Fact]
        public void Case1()
        {
            IsAnagram(
                "anagram",
                "nagaram")
                .Should().BeTrue();
        }

        [Fact]
        public void Case2()
        {
            IsAnagram(
                "rat",
                "car")
                .Should().BeFalse();
        }

        public bool IsAnagram(string s, string t)
        {
            int length = s.Length;
            int[] alphabet = new int[26];

            // アルファベットが使用されている数を数えて減らす
            foreach (char c in s) alphabet[c - 'a']++;
            foreach (char c in t) alphabet[c - 'a']--;

            // 同じ数が使用されていればアナグラム
            foreach (int count in alphabet) if (count != 0) return false;
            return true;
        }
    }
}