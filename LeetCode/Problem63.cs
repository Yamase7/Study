using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem63
    {
        [TestMethod]
        public void Case1()
        {
            UniquePathsWithObstacles(new int[][]
            {
                new int[] { 0,0,0 },
                new int[] { 0,1,0 },
                new int[] { 0,0,0 },
            }).Is(2);
        }

        [TestMethod]
        public void Case2()
        {
            UniquePathsWithObstacles(new int[][]
            {
                new int[] { 0,1 },
                new int[] { 0,0 },
            }).Is(1);
        }

        [TestMethod]
        public void Case3()
        {
            UniquePathsWithObstacles(new int[][]
            {
                new int[] { 1 },
            }).Is(0);
        }

        [TestMethod]
        public void Case4()
        {
            UniquePathsWithObstacles(new int[][]
            {
                new int[] { 1 },
                new int[] { 0 },
            }).Is(0);
        }

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var width = obstacleGrid[0].Length;
            var patternCounts = new int[width];
            patternCounts[0] = 1;

            foreach (var row in obstacleGrid)
            {
                for (int i = 0; i < width; i++)
                {
                    // �Ώۂ̃}�X����Q����������0�p�^�[���Ƃ���
                    if (row[i] == 1)
                    {
                        patternCounts[i] = 0;
                    }
                    // 1�񂾂����ꍇ�͍��𑫂��Ȃ��̂ŏ��O����
                    else if (i > 0)
                    {
                        patternCounts[i] += patternCounts[i - 1];
                    }
                }
            }

            return patternCounts[width - 1];
        }

        public int UniquePathsWithObstaclesSelf(int[][] obstacleGrid)
        {
            var patternCounts = new int[obstacleGrid[0].Length];
            patternCounts[0] = 1;

            // ��Q�������������L�^����t���O��p��
            var obstacleFound = false;

            // 1�s�ڂ̃p�^�[����p��
            for (int i = 1; i < obstacleGrid[0].Length; i++)
            {
                // �ʂ����}�X�ŏ�Q���������Ă����炻�̐�͐i�߂Ȃ��̂�0
                if (obstacleFound)
                {
                    patternCounts[i] = 0;
                    continue;
                }

                // �ʂ��}�X�ł���΂����܂ł�1�p�^�[���Œʂ��
                if (obstacleGrid[0][i] == 0)
                {
                    patternCounts[i] = 1;

                }
                // �ʂ�Ȃ��̂ł����0�p�^�[���Ƃ��A���������Ƃ��L�^
                else
                {
                    patternCounts[i] = 0;
                    obstacleFound = true;
                }
            }

            // �s���ƂɃ��[�v
            for (int i = 1; i < obstacleGrid.Length; i++)
            {
                // �񂲂ƂɃ��[�v
                for (int j = 1; j < obstacleGrid[0].Length; j++)
                {
                    // ��Q���̂���}�X�łȂ���΍��Ə�̃}�X�̃p�^�[���������v
                    // ��Q���ł����0�p�^�[���Ƃ���
                    patternCounts[j] = obstacleGrid[i][j] == 0
                        ? patternCounts[j] + patternCounts[j - 1]
                        : 0;
                }
            }

            return patternCounts.Last();
        }
    }
}