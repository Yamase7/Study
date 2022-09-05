using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �����z��nums���^����ꂽ�Ƃ��A�ő�̘a�����A�����������z��������Ęa��Ԃ��B
    /// �����z��͏��Ȃ��Ƃ�1�̐����܂ށB
    /// </summary>
    public class Problem0053
    {
        [Fact]
        public void Case1()
        {
            MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 })
                .Should().Be(6);
        }

        [Fact]
        public void Case2()
        {
            MaxSubArray(new int[] { 1 })
                .Should().Be(1);
        }

        [Fact]
        public void Case3()
        {
            MaxSubArray(new int[] { 5, 4, -1, 7, 8 })
                .Should().Be(23);
        }

        [Fact]
        public void Case4()
        {
            MaxSubArray(new int[] { -2, 3, -1, 1, -91, 2, 1, -5, -1 })
                .Should().Be(3);
        }

        [Fact]
        public void Case5()
        {
            MaxSubArray(new int[] { 1, 1, 1, -1, 2 })
                .Should().Be(4);
        }

        [Fact]
        public void Case6()
        {
            MaxSubArray(new int[] { -2, 1 })
                .Should().Be(1);
        }

        public int MaxSubArray(int[] nums)
        {
            var length = nums.Length;
            var dp = new int[length];

            // �ŏ��̒l�������_�̍ő啔���z�񍇌v�l�Ƃ���
            dp[0] = nums[0];
            var max = dp[0];

            // 2�Ԗڂ̒l�������m�F����
            for (var i = 1; i < length; i++)
            {
                // �����_�܂ł̔z��ōő啔���z�񍇌v�l�����߂�B
                // �����_�̒l�ɂЂƂO�܂ł̍ő啔���z�񍇌v�l��1�ȏ�ł���Ή��Z���Ⴄ�̂ł���Ή��Z���Ȃ�
                dp[i] = nums[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);

                // �ő�l���r���čX�V
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
    }
}