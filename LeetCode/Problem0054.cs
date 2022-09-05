using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0054
    {
        [Fact]
        public void Case1()
        {
            SpiralOrder(
                new int[][]
                {
                    new int[] { 1, 2, 3 },
                    new int[] { 4, 5, 6 },
                    new int[] { 7, 8, 9 },
                })
                .Should().Equal(
                    new int[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 });
        }

        [Fact]
        public void Case2()
        {
            SpiralOrder(
                new int[][]
                {
                    new int[] { 1, 2, 3, 4 },
                    new int[] { 5, 6, 7, 8 },
                    new int[] { 9, 10, 11, 12 },
                })
                .Should().Equal(
                    new int[] { 1, 2, 3, 4, 8, 12, 11, 10, 9, 5, 6, 7 });
        }

        /// <summary>
        /// □□□      111
        /// □□□      452
        /// □□□      462
        /// □□□  ->  462
        /// □□□      462
        /// □□□      472
        /// □□□      333
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public IList<int> SpiralOrder(int[][] matrix)
        {
            var list = new List<int>();
            if (matrix is null || matrix.Length == 0) return list;
            
            int n = matrix.Length, m = matrix[0].Length;
            int rowStart = 0, rowEnd = n - 1;
            int colStart = 0, colEnd = m - 1;

            // matrixの全ての数がリストに追加されるまで繰り返す
            while (list.Count < n * m)
            {
                // 最終列手前まで右に進む
                for (int col = colStart; col <= colEnd && list.Count < n * m; col++)
                    list.Add(matrix[rowStart][col]);

                // 最終行手前まで下に進む
                for (int row = rowStart + 1; row <= rowEnd - 1 && list.Count < n * m; row++)
                    list.Add(matrix[row][colEnd]);

                // 開始位置を1つ左にずらし開始列まで左に進む
                for (int col = colEnd; col >= colStart && list.Count < n * m; col--)
                    list.Add(matrix[rowEnd][col]);

                // 開始位置を1つ上にずらし開始行の1行下まで上に進む
                for (int row = rowEnd - 1; row >= rowStart + 1 && list.Count < n * m; row--)
                    list.Add(matrix[row][colStart]);

                // 一周したので1マスずつ狭める
                rowStart++; rowEnd--; colStart++; colEnd--;
            }

            return list;
        }
    }
}