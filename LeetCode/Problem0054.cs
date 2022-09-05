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
        /// ������      111
        /// ������      452
        /// ������      462
        /// ������  ->  462
        /// ������      462
        /// ������      472
        /// ������      333
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

            // matrix�̑S�Ă̐������X�g�ɒǉ������܂ŌJ��Ԃ�
            while (list.Count < n * m)
            {
                // �ŏI���O�܂ŉE�ɐi��
                for (int col = colStart; col <= colEnd && list.Count < n * m; col++)
                    list.Add(matrix[rowStart][col]);

                // �ŏI�s��O�܂ŉ��ɐi��
                for (int row = rowStart + 1; row <= rowEnd - 1 && list.Count < n * m; row++)
                    list.Add(matrix[row][colEnd]);

                // �J�n�ʒu��1���ɂ��炵�J�n��܂ō��ɐi��
                for (int col = colEnd; col >= colStart && list.Count < n * m; col--)
                    list.Add(matrix[rowEnd][col]);

                // �J�n�ʒu��1��ɂ��炵�J�n�s��1�s���܂ŏ�ɐi��
                for (int row = rowEnd - 1; row >= rowStart + 1 && list.Count < n * m; row--)
                    list.Add(matrix[row][colStart]);

                // ��������̂�1�}�X�����߂�
                rowStart++; rowEnd--; colStart++; colEnd--;
            }

            return list;
        }
    }
}