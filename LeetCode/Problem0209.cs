using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// ���̐����̔z�� nums �Ɛ��̐����̔z�� target ���^����ꂽ�Ƃ��A
    /// �A�����镔���z�� [numsl, numsl+1, ..., numsr-1, numsr] �̂����A
    /// ���̘a�� target �ȏ�ł��镔���̍ŏ�������Ԃ��B
    /// ���̂悤�ȕ����z�񂪑��݂��Ȃ��ꍇ�́A�����0��Ԃ��B
    /// </summary>
    public class Problem0209
    {
        [Fact]
        public void Case1()
        {
            MinSubArrayLen(7, new int[]{ 2, 3, 1, 2, 4, 3 })
                .Should().Be(2);
        }

        [Fact]
        public void Case2()
        {
            MinSubArrayLen(4, new int[] { 1, 4, 4 })
                .Should().Be(1);
        }

        [Fact]
        public void Case3()
        {
            MinSubArrayLen(11, new int[] { 1, 1, 1, 1, 1, 1, 1, 1 })
                .Should().Be(0);
        }

        /// <summary>
        /// O(n)
        /// </summary>
        public int MinSubArrayLen(int target, int[] nums)
        {
            int left = 0, right = 0, sum = 0, minLength = int.MaxValue;

            while (right < nums.Length)
            {
                // �E�̒l�����Z���Ĉ�E�ɂ��炷
                sum += nums[right++];

                // ���v�l���ڕW�l�𒴂�����
                while (sum >= target)
                {
                    // �������r���Z�������L�^����
                    minLength = Math.Min(minLength, right - left);
                    // ���̒l�����Z���Ĉ�E�ɂ��炷
                    sum -= nums[left++];
                }
            }


            return minLength == int.MaxValue ? 0 : minLength;
        }
    }
}