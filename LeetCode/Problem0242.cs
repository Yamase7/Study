using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 2�̕�����s��t���^����ꂽ�Ƃ��At��s�̃A�i�O�����ł����true�������łȂ����false��Ԃ��B
    /// �A�i�O�����Ƃ͈قȂ�P���t���[�Y�̕�������בւ��č��ꂽ�P���
    /// �t���[�Y�̂��ƂŁA�ʏ�͌��̕��������ׂĈ�x�����g�p���܂��B
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

            // �A���t�@�x�b�g���g�p����Ă��鐔�𐔂��Č��炷
            foreach (char c in s) alphabet[c - 'a']++;
            foreach (char c in t) alphabet[c - 'a']--;

            // ���������g�p����Ă���΃A�i�O����
            foreach (int count in alphabet) if (count != 0) return false;
            return true;
        }
    }
}