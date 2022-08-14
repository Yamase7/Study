using ChainingAssertion;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0695
    {
        [Fact]
        public void Case1()
        {
            MaxAreaOfIsland(
                new int[][]
                {
                    new int[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                    new int[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
                    new int[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }
                })
                .Is(6);
        }

        [Fact]
        public void Case2()
        {
            MaxAreaOfIsland(
                new int[][]
                {
                    new int[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                })
                .Is(0);
        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxIslandSize = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    // 確認箇所が陸地だった場合
                    if (grid[i][j] == 1)
                    {
                        // DFS探索を行い陸地がどこまで続いているか確認
                        maxIslandSize = Math.Max(maxIslandSize, AreaOfIsland(grid, i, j));
                    }
                }
            }
            return maxIslandSize;
        }

        private int AreaOfIsland(int[][] grid, int i, int j)
        {
            // 探索対象が異常値だった場合探索しない
            if (i < 0 || j < 0)
            {
                return 0;
            }

            // 探索対象が異常値だった場合探索しない
            if (i >= grid.Length || j >= grid[0].Length)
            {
                return 0;
            }

            // 陸地ではなかった場合探索しない
            if (grid[i][j] != 1)
            {
                return 0;
            }


            // 探索済み箇所にする
            grid[i][j] = 2;
            
            // 島の広さを数える
            var areaCount = 1;
            // 隣接地が陸地かどうか確認するために再帰的に処理を実行する
            areaCount += AreaOfIsland(grid, i + 1, j);
            areaCount += AreaOfIsland(grid, i - 1, j);
            areaCount += AreaOfIsland(grid, i, j + 1);
            areaCount += AreaOfIsland(grid, i, j - 1);

            return areaCount;
        }
    }
}