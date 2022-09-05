using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// すべての大文字を小文字に変換し英数字以外の文字を削除した後、
    /// 前と後ろの読みが同じであれば、回文となります。
    /// 英数字には、文字と数字が含まれます。
    /// 文字列 s が与えられたとき回文であるかを返す。
    /// </summary>
    public class Problem0125
    {
        [Fact]
        public void Case1()
        {
            IsPalindrome("A man, a plan, a canal: Panama")
                .Should().BeTrue();
        }

        [Fact]
        public void Case2()
        {
            IsPalindrome("race a car")
                .Should().BeFalse();
        }

        [Fact]
        public void Case3()
        {
            IsPalindrome(" ")
                .Should().BeTrue();
        }

        [Fact]
        public void Case4()
        {
            IsPalindrome("0P")
                .Should().BeFalse();
        }

        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while (left < right && !char.IsLetterOrDigit(s[right])) right--;

                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}