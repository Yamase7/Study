using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 画像はm×nの整数の格子状の画像で表現され、image[i][j]は画像の画素値を表す。
    /// また，3つの整数 sr, sc, color が与えられる。
    /// 
    /// 画素 image[sr][sc] から始まる画像に対して洪水塗りつぶしを行う必要がある。
    /// 洪水塗りつぶしを行うには、開始画素と、開始画素と同じ色で4方向につながっている画素と、
    /// その画素と同じ色で4方向につながっている画素、といった具合に考えます。
    /// 前述のすべての画素の色を色に置き換えます。
    /// 
    /// 洪水塗りつぶしを行った後の修正画像を返します。
    /// </summary>
    public class Problem0733
    {
        [Fact]
        public void Case1()
        {
            FloodFill(
                new int[][]
                {
                    new int[] { 1, 1, 1 },
                    new int[] { 1, 1, 0 },
                    new int[] { 1, 0, 1 },
                },
                1,
                1,
                2)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 2, 2, 2 },
                        new int[] { 2, 2, 0 },
                        new int[] { 2, 0, 1 },
                    },
                    options => options.WithoutStrictOrdering());
        }

        [Fact]
        public void Case2()
        {
            FloodFill(
                new int[][]
                {
                    new int[] { 0, 0, 0 },
                    new int[] { 0, 0, 0 },
                },
                0,
                0,
                0)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 0, 0, 0 },
                        new int[] { 0, 0, 0 },
                    },
                    options => options.WithoutStrictOrdering());
        }

        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image is null || image.Length == 0) return null;
            if (image[sr][sc] == color) return image;

            DFSFill(image, sr, sc, image[sr][sc], color);

            return image;
        }

        private void DFSFill(int[][] image, int row, int column, int targetColor, int newColor)
        {
            // 範囲外に出る、もしくは現在地の色が対象の色ではなくなった場合は塗り替え対象外なため終了
            if (row < 0 || row >= image.Length || column < 0 || column >= image[0].Length || image[row][column] != targetColor) return;
            // 現在地を塗り替え
            image[row][column] = newColor;

            // 上下左右を確認してその先を塗りつぶす
            DFSFill(image, row + 1, column, targetColor, newColor);
            DFSFill(image, row, column + 1, targetColor, newColor);
            DFSFill(image, row - 1, column, targetColor, newColor);
            DFSFill(image, row, column - 1, targetColor, newColor);
        }
    }
}