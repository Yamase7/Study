using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �����z��nums���^����ꂽ�Ƃ��Aanswer[i]��nums[i]������nums�̂��ׂĂ̗v�f�̐ςɓ������Ȃ�悤�Ȕz��answer��Ԃ��B
    /// nums�̔C�ӂ̃v���t�B�b�N�X�܂��̓T�t�B�b�N�X�̐ς́A32�r�b�g�����Ɏ��܂邱�Ƃ��ۏ؂���Ă��܂��B
    /// ���Ȃ��́AO(n)���ԂŁA���Z���Z���g�킸�Ɏ��s�����A���S���Y���������Ȃ���΂Ȃ�Ȃ��B
    /// </summary>
    public class Problem0238
    {
        [Fact]
        public void Case1()
        {
            ProductExceptSelf(new int[] { 1, 2, 3, 4 })
                .Should().Equal(24, 12, 8, 6);
        }

        [Fact]
        public void Case2()
        {
            ProductExceptSelf(new int[] { -1, 1, 0, -3, 3 })
                .Should().Equal(0, 0, 9, 0, 0);
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            int length = nums.Length;
            int[] result = new int[length];

            int left = 1;
            for (int i = 0; i < length; i++)
            {
                if (i > 0) left *= nums[i - 1];
                result[i] = left;
            }

            int right = 1;
            for (int i = length - 1; i >= 0; i--)
            {
                if (i < length - 1) right *= nums[i + 1];
                result[i] *= right;
            }

            return result;
        }
    }
}