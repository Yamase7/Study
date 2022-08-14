using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 昇順にソートされた整数配列 nums があります（明確な値）。
    /// 関数に渡す前に、nums は未知のピボットインデックス k(1 <= k<nums.length) で回転され、
    /// 結果として配列は[nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]] (0-indexed) となる可能性があります。
    /// 例えば、[0,1,2,4,5,6,7] はピボットインデックス3で回転して、[4,5,6,7,0,1,2] となるかもしれない。
    /// 
    /// 回転後の配列numsと整数のtargetが与えられたとき、targetがnumsの中にあればそのインデックスを、numsの中になければ-1を返します。
    /// 実行時計算量が O(log n) であるアルゴリズムを書け．
    /// </summary>
    [TestClass]
    public class Problem0033
    {
        [TestMethod]
        public void Case1()
        {
            Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)
                .Is(4);
        }

        [TestMethod]
        public void Case2()
        {
            Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3)
                .Is(-1);
        }

        [TestMethod]
        public void Case3()
        {
            Search(new int[] { 1 }, 0)
                .Is(-1);
        }

        [TestMethod]
        public void Case4()
        {
            Search(new int[] { 1 }, 1)
                .Is(0);
        }

        [TestMethod]
        public void Case5()
        {
            Search(new int[] { 7, 8, 9, 0, 1, 2, 4, 5, 6 }, 2)
                .Is(5);
        }

        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            var left = 0;
            var right = nums.Length;

            // 探索範囲が逆転するまで探索を繰り返す
            while(left < right)
            {
                // 中央のインデックス
                var center = left + (right - left) / 2;

                // 最小の値の位置と指定の値の位置が範囲の中央から見て右側にある場合
                if (target < nums[0] && nums[0] < nums[center])
                {
                    left = center + 1;
                }
                // 最小の値の位置と指定の値の位置が範囲の中央からみて左側にある場合
                else if (target >= nums[0] && nums[0] > nums[center])
                {
                    right = center;
                }
                // 最小の値の位置と指定の値の位置が異なり、指定の値が中央の右側にあれば
                else if (nums[center] < target)
                {
                    // 探索範囲の開始位置を変更し右側を次の探索範囲とする
                    left = center + 1;
                }
                // 最小の値の位置と指定の値の位置が異なり、指定の値が中央の左側にあれば
                else if (nums[center] > target)
                {
                    // 探索範囲の終了位置を変更し右側を次の探索範囲とする
                    right = center;
                }
                // 最小の値の位置と指定の値の位置が異なり、指定の値が中央が指定の値であれば
                else
                {
                    // 中央のインデックスを返す
                    return center;
                }
            }

            // 指定の値が見つからなかったので-1を返す
            return -1;
        }
    }
}