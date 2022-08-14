using ChainingAssertion;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0198
    {
        [Fact]
        public void Case1()
        {
            Rob(new int[] { 1, 2, 3, 1 })
                .Is(4);
        }

        [Fact]
        public void Case2()
        {
            Rob(new int[] { 2, 7, 9, 3, 1 })
                .Is(12);
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            int prev1 = 0;
            int prev2 = 0;

            foreach (var num in nums)
            {
                int tmp = prev1;
                prev1 = Math.Max(prev2 + num, prev1);
                prev2 = tmp;
            }

            return prev1;
        }
    }
}