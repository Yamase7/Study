using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Study
{
    public class Problem0047
    {
        [Fact]
        public void Case1()
        {
            PermuteUnique(new int[] { 1, 1, 2 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 1, 1, 2 },
                        new int[] { 1, 2, 1 },
                        new int[] { 2, 1, 1 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            PermuteUnique(new int[] { 1, 2, 3 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 1, 2, 3 },
                        new int[] { 1, 3, 2 },
                        new int[] { 2, 1, 3 },
                        new int[] { 2, 3, 1 },
                        new int[] { 3, 1, 2 },
                        new int[] { 3, 2, 1 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case3()
        {
            PermuteUnique(new int[] { 1 })[0][0]
                .Should().Be(1);
            PermuteUnique(new int[] { 1 })
                .Should().BeEquivalentTo(
                    new List<List<int>>()
                    {
                        new List<int>() { 1 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var list = new List<IList<int>>();
            Array.Sort(nums);
            // 全てのリストを管理するリスト, 並び替えに使用するリスト, 全ての値, 
            Backtrack(list, new List<int>(), nums, new bool[nums.Length]);
            return list;
        }

        private void Backtrack(List<IList<int>> list, IList<int> tempList, int[] nums, bool[] used)
        {
            // 並べ替えたリストに全ての値が入っていたら
            if (tempList.Count == nums.Length)
            {
                // 完成した値並び替えリストを追加する
                list.Add(new List<int>(tempList));
                return;
            }

            // 値を一つ入れる
            for (int i = 0; i < nums.Length; i++)
            {
                // すでに値を追加済み
                // もしくは、最初の値ではなく、前回と同じ数字で、ひとつ前が使用していない場合
                if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]))
                {
                    // 同じ値を追加する必要はないのでスキップする
                    continue;
                }

                // 追加していない値だったら
                // 並び替えリストに値を追加して追加済みとする
                tempList.Add(nums[i]);
                used[i] = true;

                // 次以降の値を全パターン確認する
                Backtrack(list, tempList, nums, used);

                // 追加した値のパターンは全パターン確認したので削除し追加済みを解除する
                tempList.RemoveAt(tempList.Count - 1);
                used[i] = false;

            }
        }
    }
}