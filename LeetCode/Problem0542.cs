using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// m x n の2値行列 mat が与えられたとき，各セルに最も近い 0 の距離を返す．
    /// 隣接する2つのセル間の距離は1である。
    /// </summary>
    public class Problem0542
    {
        [Fact]
        public void Case1()
        {
            UpdateMatrix(
                new int[][]
                {
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 1, 0 },
                    new int[] { 0, 0, 0 },
                })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 1, 0 },
                        new int[] { 0, 0, 0 },
                    },
                    options => options.WithStrictOrdering());
        }

        [Fact]
        public void Case2()
        {
            UpdateMatrix(
                new int[][]
                {
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 1, 0 },
                    new int[] { 1, 1, 1 },
                })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 1, 0 },
                        new int[] { 1, 2, 1 },
                    },
                    options => options.WithStrictOrdering());
        }

        public int[][] UpdateMatrix(int[][] mat)
        {
            // m, n 最大距離
            int m = mat.Length, n = mat[0].Length, max = m + n;

            // 左上から右/下方向に全マス確認する
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    // 0のマスは無視する
                    if (mat[row][col] == 0) continue;

                    int top = max, left = max;
                    // 最初の行でなければ上の数を記録し、最初の列でなければ左の数を記録
                    if (row > 0) top = mat[row - 1][col];
                    if (col > 0) left = mat[row][col - 1];
                    // 上と左の値を比較し数が小さい値に1を足して対象のマスに入れる
                    mat[row][col] = Math.Min(top, left) + 1;
                }
            }

            // 左上から左/上方向に全マス確認する
            for (int row = m - 1; row >= 0; row--)
            {
                for (int col = n - 1; col >= 0; col--)
                {
                    // 0のマスは無視する
                    if (mat[row][col] == 0) continue;

                    int bottom = max, right = max;
                    // 最終行でなければ下の数を記録し、最終列でなければ右の数を記録
                    if (row + 1 < m) bottom = mat[row + 1][col];
                    if (col + 1 < n) right = mat[row][col + 1];
                    // 「対象のマス」と「下と右の小さい方の値に1を足した値」を比較し数が小さい値を対象のマスに入れる
                    mat[row][col] = Math.Min(mat[row][col], Math.Min(bottom, right) + 1);
                }
            }

            return mat;
        }
    }
}