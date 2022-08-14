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
                    // �m�F�ӏ������n�������ꍇ
                    if (grid[i][j] == 1)
                    {
                        // DFS�T�����s�����n���ǂ��܂ő����Ă��邩�m�F
                        maxIslandSize = Math.Max(maxIslandSize, AreaOfIsland(grid, i, j));
                    }
                }
            }
            return maxIslandSize;
        }

        private int AreaOfIsland(int[][] grid, int i, int j)
        {
            // �T���Ώۂ��ُ�l�������ꍇ�T�����Ȃ�
            if (i < 0 || j < 0)
            {
                return 0;
            }

            // �T���Ώۂ��ُ�l�������ꍇ�T�����Ȃ�
            if (i >= grid.Length || j >= grid[0].Length)
            {
                return 0;
            }

            // ���n�ł͂Ȃ������ꍇ�T�����Ȃ�
            if (grid[i][j] != 1)
            {
                return 0;
            }


            // �T���ς݉ӏ��ɂ���
            grid[i][j] = 2;
            
            // ���̍L���𐔂���
            var areaCount = 1;
            // �אڒn�����n���ǂ����m�F���邽�߂ɍċA�I�ɏ��������s����
            areaCount += AreaOfIsland(grid, i + 1, j);
            areaCount += AreaOfIsland(grid, i - 1, j);
            areaCount += AreaOfIsland(grid, i, j + 1);
            areaCount += AreaOfIsland(grid, i, j - 1);

            return areaCount;
        }
    }
}