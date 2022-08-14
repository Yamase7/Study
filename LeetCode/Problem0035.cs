using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0035
    {
        [Fact]
        public void Case1()
        {
            SearchInsert(new int[] { 1, 3, 5, 6 }, 5)
                .Is(2);
        }

        [Fact]
        public void Case2()
        {
            SearchInsert(new int[] { 1, 3, 5, 6 }, 2)
                .Is(1);
        }

        [Fact]
        public void Case3()
        {
            SearchInsert(new int[] { 1, 3, 5, 6 }, 7)
                .Is(4);
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int center = start + (end - start) / 2;

                if (nums[center] == target)
                {
                    return center;
                }
                else if (nums[center] > target)
                {
                    end = center - 1;
                }
                else
                {
                    start = center + 1;
                }
            }

            return start;
        }
    }
}