using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0090
    {
        [Fact]
        public void Case1()
        {
            SubsetsWithDup(new int[] { 1, 2, 2 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { },
                        new int[] { 1 },
                        new int[] { 1, 2 },
                        new int[] { 1, 2, 2 },
                        new int[] { 2 },
                        new int[] { 2, 2 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            SubsetsWithDup(new int[] { 0 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { },
                        new int[] { 0 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            var list = new List<IList<int>>();
            Array.Sort(nums);
            Backtrack(list, new List<int>(), nums, 0);
            return list;
        }

        private void Backtrack(List<IList<int>> list, List<int> tempList, int[] nums, int start)
        {
            list.Add(new List<int>(tempList));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }
                tempList.Add(nums[i]);
                Backtrack(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}