using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0200
    {
        [Fact]
        public void Case1()
        {
            NumIslands(
                new char[][]
                {
                    new char[] {'1', '1', '1', '1', '0'},
                    new char[] {'1', '1', '0', '1', '0'},
                    new char[] {'1', '1', '0', '0', '0'},
                    new char[] {'0', '0', '0', '0', '0'},
                })
                .Should().Be(1);
        }

        [Fact]
        public void Case2()
        {
            NumIslands(
                new char[][]
                {
                    new char[] {'1', '1', '0', '0', '0'},
                    new char[] {'1', '1', '0', '0', '0'},
                    new char[] {'0', '0', '1', '0', '0'},
                    new char[] {'0', '0', '0', '1', '1'},
                })
                .Should().Be(3);
        }

        [Fact]
        public void Case3()
        {
            NumIslands(
                new char[][]
                {
                    new char[] {'1', '0', '1', '0', '0'},
                    new char[] {'1', '1', '0', '0', '1'},
                    new char[] {'0', '0', '0', '1', '1'},
                    new char[] {'1', '0', '1', '1', '0'},
                    new char[] {'1', '0', '0', '1', '0'},
                })
                .Should().Be(4);
        }

        public int NumIslands(char[][] grid)
        {
            var count = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    // 確認箇所が陸地だった場合
                    if (grid[i][j] == '1')
                    {
                        // DFS探索を行い陸地がどこまで続いているか確認
                        DFSMarking(grid, i, j);
                        count++;
                    }
                }
            }
            return count;
        }

        private void DFSMarking(char[][] grid, int i, int j)
        {
            // 探索対象が異常値だった場合探索しない
            if (i < 0 || j < 0)
            {
                return;
            }

            // 探索対象が異常値だった場合探索しない
            if (i >= grid.Length || j >= grid[0].Length)
            {
                return;
            }

            // 陸地ではなかった場合探索しない
            if (grid[i][j] != '1')
            {
                return;
            }

            // 探索済み箇所にする
            grid[i][j] = '#';

            // 隣接地が陸地かどうか確認するために再帰的に処理を実行する
            DFSMarking(grid, i + 1, j);
            DFSMarking(grid, i - 1, j);
            DFSMarking(grid, i, j + 1);
            DFSMarking(grid, i, j - 1);
        }
    }
}