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
                    // 対象のマスが障害物だったら0パターンとする
                    if (row[i] == 1)
                    {
                        patternCounts[i] = 0;
                    }
                    // 1列だった場合は左を足せないので除外する
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

            // 障害物を見つけたか記録するフラグを用意
            var obstacleFound = false;

            // 1行目のパターンを用意
            for (int i = 1; i < obstacleGrid[0].Length; i++)
            {
                // 通ったマスで障害物を見つけていたらその先は進めないので0
                if (obstacleFound)
                {
                    patternCounts[i] = 0;
                    continue;
                }

                // 通れるマスであればそこまでは1パターンで通れる
                if (obstacleGrid[0][i] == 0)
                {
                    patternCounts[i] = 1;

                }
                // 通れないのであれば0パターンとし、見つけたことを記録
                else
                {
                    patternCounts[i] = 0;
                    obstacleFound = true;
                }
            }

            // 行ごとにループ
            for (int i = 1; i < obstacleGrid.Length; i++)
            {
                // 列ごとにループ
                for (int j = 1; j < obstacleGrid[0].Length; j++)
                {
                    // 障害物のあるマスでなければ左と上のマスのパターン数を合計
                    // 障害物であれば0パターンとする
                    patternCounts[j] = obstacleGrid[i][j] == 0
                        ? patternCounts[j] + patternCounts[j - 1]
                        : 0;
                }
            }

            return patternCounts.Last();
        }
    }
}