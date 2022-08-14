using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// ベルトコンベアには、ある港から別の港へ数日以内に出荷しなければならない荷物があります。
    /// ベルトコンベア上のi番目の荷物はweights[i] の重さを持っています。
    /// 毎日、ベルトコンベア上の荷物を船に積み込みます。（渡された重量リストの順番で）
    /// 船の最大積載重量を超える荷物を積むことはできません．
    /// ベルトコンベア上のすべての荷物が数日以内に出荷されるような、
    /// 最も重量が少ない船の容量を返しなさい。
    /// </summary>
    [TestClass]
    public class Problem1011
    {
        [TestMethod]
        public void Case1()
        {
            ShipWithinDays(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5)
                .Is(15);
        }

        [TestMethod]
        public void Case2()
        {
            ShipWithinDays(new int[] { 3, 2, 2, 4, 1, 4 }, 3)
                .Is(6);
        }

        [TestMethod]
        public void Case3()
        {
            ShipWithinDays(new int[] { 1, 2, 3, 1, 1 }, 4)
                .Is(3);
        }

        public int ShipWithinDays(int[] weights, int days)
        {
            // 荷物よりも船が小さいと運べなくなってしまうので、最小の船の積載重量は一番重い荷物と同じ。
            int left = weights.Max();

            // 一日で運ぶには船に全ての荷物の合計以上の積載重量が必要となる。
            // 最も重量が少ない船の容量を返す問題なので、船の積載重量はすべての荷物の合計の重量とする。
            int right = weights.Sum();

            // 積載重量の範囲が定まったら、指定された日数で返せる最小積載重量を二分探索する
            while (left < right)
            {
                // 二分探索をするための中央値を出す。
                int mid = left + (right - left) / 2;

                // 運搬日数 (最低でも1日)
                int needDays = 1;
                int cur = 0;

                // 船に荷物の搬入を開始する
                foreach (int w in weights)
                {
                    // 対象の荷物を積み込んだら積載重量を超える場合
                    if (cur + w > mid)
                    {
                        // 次の日に運搬する
                        needDays += 1;
                        cur = 0;
                    }

                    // 荷物を積み込む
                    cur += w;
                }

                // 全て運ぶのに必要な日数が指定の日数を超えていれば
                if (needDays > days)
                {
                    // 探索範囲を変えてさらに大きな積載重量を探索する
                    left = mid + 1;
                }
                else
                {
                    // 探索範囲を変えてさらに小さな積載重量を探索する
                    right = mid;
                }
            }

            // 探索結果を返す
            return left;
        }
    }
}