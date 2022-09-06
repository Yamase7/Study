using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �摜��m�~n�̐����̊i�q��̉摜�ŕ\������Aimage[i][j]�͉摜�̉�f�l��\���B
    /// �܂��C3�̐��� sr, sc, color ���^������B
    /// 
    /// ��f image[sr][sc] ����n�܂�摜�ɑ΂��č^���h��Ԃ����s���K�v������B
    /// �^���h��Ԃ����s���ɂ́A�J�n��f�ƁA�J�n��f�Ɠ����F��4�����ɂȂ����Ă����f�ƁA
    /// ���̉�f�Ɠ����F��4�����ɂȂ����Ă����f�A�Ƃ�������ɍl���܂��B
    /// �O�q�̂��ׂẲ�f�̐F��F�ɒu�������܂��B
    /// 
    /// �^���h��Ԃ����s������̏C���摜��Ԃ��܂��B
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
            // �͈͊O�ɏo��A�������͌��ݒn�̐F���Ώۂ̐F�ł͂Ȃ��Ȃ����ꍇ�͓h��ւ��ΏۊO�Ȃ��ߏI��
            if (row < 0 || row >= image.Length || column < 0 || column >= image[0].Length || image[row][column] != targetColor) return;
            // ���ݒn��h��ւ�
            image[row][column] = newColor;

            // �㉺���E���m�F���Ă��̐��h��Ԃ�
            DFSFill(image, row + 1, column, targetColor, newColor);
            DFSFill(image, row, column + 1, targetColor, newColor);
            DFSFill(image, row - 1, column, targetColor, newColor);
            DFSFill(image, row, column - 1, targetColor, newColor);
        }
    }
}