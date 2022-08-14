using ChainingAssertion;
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
            // 部分配列の合計値記録用変数
            var temp = nums[0];

            // 最大の部分配列合計値用変数
            var maxSum = nums[0];

            // 2番目から探索する
            for (int i = 1; i < nums.Length; i++)
            {
                // 取り出した値を合計値として加算
                temp += nums[i];

                // 合計値が-にならなければ最大合計値と比較して最大値を更新する
                if (temp >= 0)
                {
                    maxSum = Math.Max(maxSum, temp);
                }
                // -であれば最大合計値を求めるのに邪魔になるので部分配列の合計値をリセットする
                else
                {
                    temp = 0;
                }
            }

            return maxSum;
        }
    }
}