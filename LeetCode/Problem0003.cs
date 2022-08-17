using ChainingAssertion;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// ������ s ���^����ꂽ�Ƃ��A�����̌J��Ԃ��̂Ȃ��Œ��̕���������̒��������߂�B
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
            // 0�����������ꍇ�͘A�����镶���͂Ȃ��̂�0��Ԃ�
            if (s.Length == 0)
            {
                return 0;
            }

            var dictionary = new Dictionary<char, int>();
            int max = 0;

            // �|�C���^���p�ӂ��ĕ���������̒T�����s��
            for (int right = 0, left = 0; right < s.Length; ++right)
            {
                // �Y���̕��������o�������ꍇ
                if (dictionary.ContainsKey(s[right]))
                {
                    // ���o�̕������Ō�Ɋm�F�����C���f�b�N�X�̎��𕔕�������̊J�n�Ƃ���
                    left = Math.Max(left, dictionary[s[right]] + 1);
                }

                // �Y���̕����̍ŏI�o���ʒu���X�V����
                dictionary[s[right]] = right;

                // �E�̃C���f�b�N�X�ƍ��̃C���f�b�N�X�̍��𕶎����Ƃ��čő�l���X�V����
                max = Math.Max(max, right - left + 1);
            }

            return max;
        }
    }
}