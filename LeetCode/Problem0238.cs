using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 整数配列numsが与えられたとき、answer[i]がnums[i]を除くnumsのすべての要素の積に等しくなるような配列answerを返す。
    /// numsの任意のプリフィックスまたはサフィックスの積は、32ビット整数に収まることが保証されています。
    /// あなたは、O(n)時間で、除算演算を使わずに実行されるアルゴリズムを書かなければならない。
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