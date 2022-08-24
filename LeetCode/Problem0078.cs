using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0078
    {
        [Fact]
        public void Case1()
        {
            Subsets(new int[] { 1, 2, 3 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { },
                        new int[] { 1 },
                        new int[] { 2 },
                        new int[] { 1, 2 },
                        new int[] { 3 },
                        new int[] { 1, 3 },
                        new int[] { 2, 3 },
                        new int[] { 1, 2, 3 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            Subsets(new int[] { 0 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { },
                        new int[] { 0 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        public IList<IList<int>> Subsets(int[] nums)
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
                tempList.Add(nums[i]);
                Backtrack(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}