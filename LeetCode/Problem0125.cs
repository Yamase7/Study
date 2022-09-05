using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// ���ׂĂ̑啶�����������ɕϊ����p�����ȊO�̕������폜������A
    /// �O�ƌ��̓ǂ݂������ł���΁A�񕶂ƂȂ�܂��B
    /// �p�����ɂ́A�����Ɛ������܂܂�܂��B
    /// ������ s ���^����ꂽ�Ƃ��񕶂ł��邩��Ԃ��B
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