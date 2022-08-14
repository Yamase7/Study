using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 昇順でソートされた長さnの配列が1回からn回回転したとします。
    /// 例えば、配列 nums = [0,1,2,4,5,6,7] の場合は次のようになります。
    /// ・4回回転させると[4, 5, 6, 7, 0, 1, 2] となります。
    /// ・7回回転させると[0, 1, 2, 4, 5, 6, 7] になります．
    /// 
    /// 配列「A」を1回回転させると配列「B」になることに注意してください。
    ///   A : [a[0], a[1], a[2], ..., a[n-1]]
    ///   B : [a[n-1], a[0], a[1], a[2], ..., a[n-2]]
    ///   
    /// ユニークな要素を持つ回転配列 nums が与えられたとき、この配列の最小の要素を返せ。
    /// 
    /// O(log n)時間で実行されるアルゴリズムを書くこと．
    /// </summary>
    public class Problem0153
    {
        [Fact]
        public void Case1()
        {
            FindMin(new int[] { 3, 4, 5, 1, 2 })
                .Is(1);
        }

        [Fact]
        public void Case2()
        {
            FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 })
                .Is(0);
        }

        [Fact]
        public void Case3()
        {
            FindMin(new int[] { 11, 13, 15, 17 })
                .Is(11);
        }

        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var start = 0;
            var end = nums.Length - 1;

            while (start < end)
            {
                var center = start + (end - start) / 2;

                if (nums[center] > nums[end])
                {
                    start = center + 1;
                }
                else
                {
                    end = center;
                }
            }

            return nums[start];
        }
    }
}