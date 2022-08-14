using ChainingAssertion;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0213
    {
        [Fact]
        public void Case1()
        {
            Rob(new int[] { 2, 3, 2 })
                .Is(3);
        }

        [Fact]
        public void Case2()
        {
            Rob(new int[] { 1, 2, 3, 1 })
                .Is(4);
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            else if (nums.Length == 1)
            {
                return nums[0];
            }

            return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
        }

        public int Rob(int[] nums, int lowIndex, int highIndex)
        {
            int prev1 = 0;
            int prev2 = 0;

            for (int i = lowIndex; i <= highIndex; i++)
            {
                int tmp = prev1;
                prev1 = Math.Max(prev2 + nums[i], prev1);
                prev2 = tmp;
            }

            return prev1;
        }
    }
}