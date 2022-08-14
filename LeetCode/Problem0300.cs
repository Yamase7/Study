using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 整数の配列numsが与えられたとき、厳密に増加する最も長い部分配列の長さを返す。
    /// 部分配列とは、配列から残りの要素の順序を変えずに、一部または全部の要素を削除して得られる配列のことです。
    /// 例えば、[3,6,2,7] は配列[0, 3, 1, 6, 2, 2, 7] の部分配列となります。
    /// </summary>
    public class Problem0300
    {
        [Fact]
        public void Case1()
        {
            LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 })
                .Is(4);
        }

        [Fact]
        public void Case2()
        {
            LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 })
                .Is(4);
        }

        [Fact]
        public void Case3()
        {
            LengthOfLIS(new int[] { 7, 7, 7, 7, 7, 7, 7 })
                .Is(1);
        }

        [Fact]
        public void Case4()
        {
            LengthOfLIS(new int[] { 8, 4, 5, 6, 3 })
                .Is(3);
        }

        [Fact]
        public void Case5()
        {
            LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 20, 18, 26, 35, 6, 70 })
                .Is(7);
        }

    public int LengthOfLIS(int[] nums)
    {
        // LISの末尾の内最小を長さ毎の配列に入れる配列を用意する
        int[] tails = new int[nums.Length];

        // 最大のLISの長さを計測するための変数を用意
        int tailsLength = 0;

        // 配列からLISの先頭とする値を一つずつ取り出す
        foreach (var currentNo in nums)
        {
            // LISの値を確認する初回の範囲を定める
            var lowIndex = 0;
            var highIndex = tailsLength;

            // 範囲が1になるまで繰り返す
            while (lowIndex != highIndex)
            {
                // LIS検索範囲の中央のインデックスを割り出す
                int tailsIndex = (lowIndex + highIndex) / 2;

                // 検索した中央の値が取り出した値の方が大きければ検索範囲を中央の次からに変更
                if (tails[tailsIndex] < currentNo)
                {
                    lowIndex = tailsIndex + 1;
                }
                // 小さければ中央までとする
                else
                {
                    highIndex = tailsIndex;
                }
            }

            // 範囲が一つになった箇所に番号を格納
            tails[lowIndex] = currentNo;

            // 上書きじゃなければLISの新規追加となるのでサイズをインクリメント
            if (lowIndex == tailsLength)
            {
                tailsLength++;

            }
        }
        return tailsLength;
    }
    }
}