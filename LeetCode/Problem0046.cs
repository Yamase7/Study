using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0046
    {
        [Fact]
        public void Case1()
        {
            Permute(new int[] { 1, 2, 3 })
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
        public void Case2()
        {
            Permute(new int[] { 0, 1 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 0, 1 },
                        new int[] { 1, 0 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case3()
        {
            Permute(new int[] { 1 })[0][0]
                .Should().Be(1);
            Permute(new int[] { 1 })
                .Should().BeEquivalentTo(
                    new List<List<int>>()
                    {
                        new List<int>() { 1 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var list = new List<IList<int>>();
            // 全てのリストを管理するリスト, 並び替えに使用するリスト, 全ての値
            Backtrack(list, new List<int>(), nums);
            return list;
        }

        private void Backtrack(List<IList<int>> list, IList<int> tempList, int[] nums)
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
                // すでに値が追加されていたら
                if (tempList.Contains(nums[i]))
                {
                    // 同じ値を追加する必要はないのでスキップする
                    continue;
                }

                // 追加していない値だったら
                // 並び替えリストに値を追加して
                tempList.Add(nums[i]);

                // 次以降の値を全パターン確認する
                Backtrack(list, tempList, nums);

                // 追加した値のパターンは全パターン確認したので削除する
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}