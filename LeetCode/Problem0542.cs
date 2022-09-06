using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// m x n ��2�l�s�� mat ���^����ꂽ�Ƃ��C�e�Z���ɍł��߂� 0 �̋�����Ԃ��D
    /// �אڂ���2�̃Z���Ԃ̋�����1�ł���B
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
            // m, n �ő勗��
            int m = mat.Length, n = mat[0].Length, max = m + n;

            // ���ォ��E/�������ɑS�}�X�m�F����
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    // 0�̃}�X�͖�������
                    if (mat[row][col] == 0) continue;

                    int top = max, left = max;
                    // �ŏ��̍s�łȂ���Ώ�̐����L�^���A�ŏ��̗�łȂ���΍��̐����L�^
                    if (row > 0) top = mat[row - 1][col];
                    if (col > 0) left = mat[row][col - 1];
                    // ��ƍ��̒l���r�������������l��1�𑫂��đΏۂ̃}�X�ɓ����
                    mat[row][col] = Math.Min(top, left) + 1;
                }
            }

            // ���ォ�獶/������ɑS�}�X�m�F����
            for (int row = m - 1; row >= 0; row--)
            {
                for (int col = n - 1; col >= 0; col--)
                {
                    // 0�̃}�X�͖�������
                    if (mat[row][col] == 0) continue;

                    int bottom = max, right = max;
                    // �ŏI�s�łȂ���Ή��̐����L�^���A�ŏI��łȂ���ΉE�̐����L�^
                    if (row + 1 < m) bottom = mat[row + 1][col];
                    if (col + 1 < n) right = mat[row][col + 1];
                    // �u�Ώۂ̃}�X�v�Ɓu���ƉE�̏��������̒l��1�𑫂����l�v���r�������������l��Ώۂ̃}�X�ɓ����
                    mat[row][col] = Math.Min(mat[row][col], Math.Min(bottom, right) + 1);
                }
            }

            return mat;
        }
    }
}