using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 正の整数の配列 nums と正の整数の配列 target が与えられたとき、
    /// 連続する部分配列 [numsl, numsl+1, ..., numsr-1, numsr] のうち、
    /// その和が target 以上である部分の最小長さを返す。
    /// そのような部分配列が存在しない場合は、代わりに0を返す。
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
                // 右の値を加算して一つ右にずらす
                sum += nums[right++];

                // 合計値が目標値を超えたら
                while (sum >= target)
                {
                    // 長さを比較し短い方を記録する
                    minLength = Math.Min(minLength, right - left);
                    // 左の値を減算して一つ右にずらす
                    sum -= nums[left++];
                }
            }


            return minLength == int.MaxValue ? 0 : minLength;
        }
    }
}