using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 2つの文字列sとtが与えられたとき、sがtの部分配列であればtrueを、そうでなければfalseを返す。
    /// 文字列の部分配列とは、元の文字列から残りの文字の相対的な位置を乱すことなく、
    /// いくつかの文字（なくてもよい）を削除してできた新しい文字列のことである。
    /// (例: "ace" は "abcde" の部分文字列であるが、"aec" は部分文字列ではない)。
    /// </summary>
    public class Problem0392
    {
        [Fact]
        public void Case1()
        {
            IsSubsequence(
                "abc",
                "ahbgdc")
                .Should().BeTrue();
        }

        [Fact]
        public void Case2()
        {
            IsSubsequence(
                "axc",
                "ahbgdc")
                .Should().BeTrue();
        }

        public bool IsSubsequence(string s, string t)
        {
            return false;
        }
    }
}