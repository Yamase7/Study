using ChainingAssertion;
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
                .Is(6);
        }

        [Fact]
        public void Case2()
        {
            MaxSubArray(new int[] { 1 })
                .Is(1);
        }

        [Fact]
        public void Case3()
        {
            MaxSubArray(new int[] { 5, 4, -1, 7, 8 })
                .Is(23);
        }

        [Fact]
        public void Case4()
        {
            MaxSubArray(new int[] { -2, 3, -1, 1, -91, 2, 1, -5, -1 })
                .Is(3);
        }

        [Fact]
        public void Case5()
        {
            MaxSubArray(new int[] { 1, 1, 1, -1, 2 })
                .Is(4);
        }

        public int MaxSubArray(int[] nums)
        {
            // �����z��̍��v�l�L�^�p�ϐ�
            var temp = nums[0];

            // �ő�̕����z�񍇌v�l�p�ϐ�
            var maxSum = nums[0];

            // 2�Ԗڂ���T������
            for (int i = 1; i < nums.Length; i++)
            {
                // ���o�����l�����v�l�Ƃ��ĉ��Z
                temp += nums[i];

                // ���v�l��-�ɂȂ�Ȃ���΍ő升�v�l�Ɣ�r���čő�l���X�V����
                if (temp >= 0)
                {
                    maxSum = Math.Max(maxSum, temp);
                }
                // -�ł���΍ő升�v�l�����߂�̂Ɏז��ɂȂ�̂ŕ����z��̍��v�l�����Z�b�g����
                else
                {
                    temp = 0;
                }
            }

            return maxSum;
        }
    }
}