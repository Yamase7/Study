using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0073
    {
        [Fact]
        public void Case1()
        {
            var matrix = new int[][]
            {
                new int[] { 1, 1, 1 },
                new int[] { 1, 0, 1 },
                new int[] { 1, 1, 1 },
            };

            SetZeroes(matrix);

            matrix[0].Should().Equal(1, 0, 1);
            matrix[1].Should().Equal(0, 0, 0);
            matrix[2].Should().Equal(1, 0, 1);
        }

        [Fact]
        public void Case2()
        {
            var matrix = new int[][]
            {
                new int[] { 0, 1, 2, 0 },
                new int[] { 3, 4, 5, 2 },
                new int[] { 1, 3, 1, 5 },
            };

            SetZeroes(matrix);

            matrix[0].Should().Equal(0, 0, 0, 0);
            matrix[1].Should().Equal(0, 4, 5, 0);
            matrix[2].Should().Equal(0, 3, 1, 0);
        }

        [Fact]
        public void Case3()
        {
            var matrix = new int[][]
            {
                new int[] { -4, -2147483648, 6, -7, 0 },
                new int[] { -8, 6, -8, -6, 0 },
                new int[] { 2147483647, 2, -9, -6, -10 },
            };

            SetZeroes(matrix);

            matrix[0].Should().Equal(0, 0, 0, 0, 0);
            matrix[1].Should().Equal(0, 0, 0, 0, 0);
            matrix[2].Should().Equal(2147483647, 2, -9, -6, 0);
        }
        
        public void SetZeroes(int[][] matrix)
        {
            bool isZeroCol = false;
            bool isZeroRow = false;

            // �ŏ��̍s��0�����邩�m�F
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    isZeroCol = true;
                    break;
                }
            }

            // �ŏ��̗��0�����邩�m�F
            for (int i = 0; i < matrix[0].Length; i++)
            {
                if (matrix[0][i] == 0)
                {
                    isZeroRow = true;
                    break;
                }
            }

            // �Ώۂ̍s�Ɨ��0�����邩�擪�s�E��������Ċm�F���擪�s�ɋL�^
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            // �擪�s�Ɨ��0������΂��̍s���}�X��S��0�ɕς���
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                    if (matrix[i][0] == 0 || matrix[0][j] == 0)
                        matrix[i][j] = 0;
            }

            // �ύX�O�̃}�g���b�N�X�̐擪�s�E���0����������擪�s�E����㏑������
            if (isZeroCol)
                for (int i = 0; i < matrix.Length; i++)
                    matrix[i][0] = 0;
            if (isZeroRow)
                for (int i = 0; i < matrix[0].Length; i++)
                    matrix[0][i] = 0;
        }
    }
}