using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 異なる整数の候補の配列とターゲットとなる整数が与えられたとき、
    /// 選ばれた数値の合計がターゲットとなる候補のすべての
    /// ユニークな組み合わせのリストを返てください。
    /// 組み合わせはどのような順番で返してもよい。
    /// 候補の中から同じ数字が選ばれる回数は無制限である。
    /// 二つの組み合わせは、選ばれた数のうち少なくとも一つの頻度が異なる場合一意である。
    /// 与えられた入力に対して、合計がtargetになるユニークな組み合わせの数が150通り以下であることが保証される。
    /// </summary>
    public class Problem0039
    {
        [Fact]
        public void Case1()
        {
            CombinationSum(new int[] { 2, 3, 6, 7 }, 7)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 2, 2, 3 },
                        new int[] { 7 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            CombinationSum(new int[] { 2, 3, 5 }, 8)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 2, 2, 2, 2 },
                        new int[] { 2, 3, 3 },
                        new int[] { 3, 5 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case3()
        {
            CombinationSum(new int[] { 2 }, 1)
                .Should().BeEquivalentTo(
                    new int[][] { },
                    options => options.ExcludingNestedObjects());
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var list = new List<IList<int>>();
            Array.Sort(candidates);

            Backtrack(list, new List<int>(), candidates, 0, 0, target);

            return list;
        }

        private void Backtrack(List<IList<int>> allList, List<int> tempList, int[] candidates, int currentSum, int currentIndex, int target)
        {
            // 作成中のリストの合計値が目標値以上ならば
            if (currentSum > target)
            {
                // 新しく値を追加しないので返す
                return;
            }

            // 目標値と同じであれば
            if (currentSum == target)
            {
                // 組み合わせをリストに追加する
                allList.Add(new List<int>(tempList));

                // 新しく値を追加しないので返す
                return;
            }

            for (int i = currentIndex; i < candidates.Length; i++)
            {
                // 新しい値を追加して
                tempList.Add(candidates[i]);
                currentSum += candidates[i];
                // 検討する
                Backtrack(allList, tempList, candidates, currentSum, i, target);
                // ここまでの値で全パターン確認したので削除
                tempList.RemoveAt(tempList.Count - 1);
                currentSum -= candidates[i];
            }
        }
    }
}