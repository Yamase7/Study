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
                    // �m�F�ӏ������n�������ꍇ
                    if (grid[i][j] == '1')
                    {
                        // DFS�T�����s�����n���ǂ��܂ő����Ă��邩�m�F
                        DFSMarking(grid, i, j);
                        count++;
                    }
                }
            }
            return count;
        }

        private void DFSMarking(char[][] grid, int i, int j)
        {
            // �T���Ώۂ��ُ�l�������ꍇ�T�����Ȃ�
            if (i < 0 || j < 0)
            {
                return;
            }

            // �T���Ώۂ��ُ�l�������ꍇ�T�����Ȃ�
            if (i >= grid.Length || j >= grid[0].Length)
            {
                return;
            }

            // ���n�ł͂Ȃ������ꍇ�T�����Ȃ�
            if (grid[i][j] != '1')
            {
                return;
            }

            // �T���ς݉ӏ��ɂ���
            grid[i][j] = '#';

            // �אڒn�����n���ǂ����m�F���邽�߂ɍċA�I�ɏ��������s����
            DFSMarking(grid, i + 1, j);
            DFSMarking(grid, i - 1, j);
            DFSMarking(grid, i, j + 1);
            DFSMarking(grid, i, j - 1);
        }
    }
}