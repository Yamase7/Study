using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �قȂ�z�ʂ̍d�݂�\�������z��coins�ƁA�����z��\������amount���^������B
    /// ���̋��z���\������̂ɕK�v�ȍł����Ȃ������̃R�C����Ԃ��B
    /// �����A���̋��z���R�C���̂ǂ̑g�ݍ��킹�ł��₦�Ȃ��ꍇ�́A-1��Ԃ��B
    /// �e�d�݂͖����ɂ���Ɖ��肵�Ă悢�B
    /// </summary>
    [TestClass]
    public class Problem0322
    {
        [TestMethod]
        public void Case1()
        {
            CoinChange(new int[] { 1, 2, 5 }, 11)
                .Is(3);
        }

        [TestMethod]
        public void Case2()
        {
            CoinChange(new int[] { 2 }, 3)
                .Is(-1);
        }

        [TestMethod]
        public void Case3()
        {
            CoinChange(new int[] { 1 }, 0)
                .Is(0);
        }

        public int CoinChange(int[] coins, int amount)
        {
            // DP�Ɏg�p����z��𐶐�
            var dp = new int[++amount];
            dp[0] = 0;

            // �d�݂̎�ނ������ɕ��בւ�
            Array.Sort(coins);

            // ���҂�����z�܂ł̑S�Ă̋��z�̕K�v�ŏ��������߂�
            for (int value = 1; value < amount; value++)
            {
                // DP�ɏ����l��ǉ� (�ŏ������߂邽�ߏ����l�͑傫�����ɂ���)
                dp[value] = int.MaxValue;

                // �d�݂�������o���Ďg�p�����ꍇ������
                foreach (var coin in coins)
                {
                    // ���o�����d�݂��ŏ��������߂������z�����傫����Ύ��̋��z�����߂�
                    if (coin > value)
                    {
                        break;
                    }

                    // ���z�Ǝ��o�����d�݂̍����̋��z�ɂ��āA�K�v�ŏ������������Ă����
                    if (dp[value - coin] != int.MaxValue)
                    {
                        // �����̕K�v���Ǝ��o�����d�݂�1���𑫂��āA���݂̋��z�̕K�v���Ƃ���
                        dp[value] = Math.Min(dp[value - coin] + 1, dp[value]);
                    }
                }
            }

            // ���߂������z��n���ꂽ���ʂ̎�ނł͏o���Ȃ����-1�A�o����̂ł���΍ŏ��K�v����Ԃ�
            return dp[--amount] == int.MaxValue ? -1 : dp[amount];
        }
    }
}