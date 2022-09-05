using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 整数配列numsが与えられたとき、最大の和を持つ連続した部分配列を見つけて和を返す。
    /// 部分配列は少なくとも1つの数を含む。
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

            // 最初の値を現時点の最大部分配列合計値とする
            dp[0] = nums[0];
            var max = dp[0];

            // 2番目の値から一つずつ確認する
            for (var i = 1; i < length; i++)
            {
                // 現時点までの配列で最大部分配列合計値を求める。
                // 現時点の値にひとつ前までの最大部分配列合計値が1以上であれば加算し違うのであれば加算しない
                dp[i] = nums[i] + (dp[i - 1] > 0 ? dp[i - 1] : 0);

                // 最大値を比較して更新
                max = Math.Max(max, dp[i]);
            }

            return max;
        }
    }
}