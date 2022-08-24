using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 候補番号の集まり（候補）と目標番号（目標）があるとき、
    /// 候補番号の和が目標になるような候補の中のユニークな組み合わせをすべて求めよ。
    /// 候補の各数字は組み合わせの中で一度だけ使用することができる。
    /// 注意：解集合には重複する組合せを含んではならない。
    /// </summary>
    public class Problem0040
    {
        [Fact]
        public void Case1()
        {
            CombinationSum(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 1, 1, 6 },
                        new int[] { 1, 2, 5 },
                        new int[] { 1, 7 },
                        new int[] { 2, 6 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            CombinationSum(new int[] { 2, 5, 2, 1, 2 }, 5)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 1, 2, 2 },
                        new int[] { 5 },
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
                // 連続した同じ数字の2番目以降だったら (評価する順番に気を付ける)
                if (i > currentIndex && candidates[i] == candidates[i - 1])
                {
                    // 同じパターンを作ってしまうためスキップする
                    continue;
                }

                // 新しい値を追加して
                tempList.Add(candidates[i]);
                currentSum += candidates[i];
                // 検討する
                Backtrack(allList, tempList, candidates, currentSum, i + 1, target);
                // ここまでの値で全パターン確認したので削除
                tempList.RemoveAt(tempList.Count - 1);
                currentSum -= candidates[i];
            }
        }
    }
}