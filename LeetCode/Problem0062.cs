using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0062
    {
        [Fact]
        public void Case1()
        {
            UniquePathsWithDPFix2(3, 7)
                .Is(28);
        }

        [Fact]
        public void Case2()
        {
            UniquePathsWithDPFix2(3, 2)
                .Is(3);
        }

        public int UniquePathsWithDPFix1(int m, int n)
        {
            // 直前の行と現在の行
            var previous = new int[n];
            var current = new int[n];

            // 最初の行に1を入れる
            for (int i = 0; i < n; i++)
            {
                previous[i] = 1;
            }

            // 一番最初の列は1なのでcurrent[0]に1を入れる
            current[0] = 1;


            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    // 直前の行の同じ列と現在の行の直前の列を足す
                    current[j] = previous[j] + current[j - 1];
                }
                current.CopyTo(previous, 0);
            }

            return current[n - 1];
        }

        public int UniquePathsWithDPFix2(int m, int n)
        {
            // 最初の行を配列に入れる
            var nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    // 直前のデータを対象のマスに加算する
                    nums[j] += nums[j - 1];
                }
            }

            return nums[n - 1];
        }

        public int UniquePathsWithDP(int m, int n)
        {
            // 空のDPテーブル作成
            var dp = new int[m, n];

            // 1パターンとなるデータを1で埋める
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }

            // 行ごとのループ
            for (int i = 1; i < m; i++)
            {
                // 列ごとのループ
                for (int j = 1; j < n; j++)
                {
                    // 対象のマスに左と上のマスを合計値を入れる
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            // ゴールのマスの値を返す
            return dp[m - 1, n - 1];
        }
    }
}