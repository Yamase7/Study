using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0062
    {
        [Fact]
        public void Case1()
        {
            UniquePathsWithDPFix2(3, 7)
                .Is(28);
        }

        [Fact]
        public void Case2()
        {
            UniquePathsWithDPFix2(3, 2)
                .Is(3);
        }

        public int UniquePathsWithDPFix1(int m, int n)
        {
            // ���O�̍s�ƌ��݂̍s
            var previous = new int[n];
            var current = new int[n];

            // �ŏ��̍s��1������
            for (int i = 0; i < n; i++)
            {
                previous[i] = 1;
            }

            // ��ԍŏ��̗��1�Ȃ̂�current[0]��1������
            current[0] = 1;


            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    // ���O�̍s�̓�����ƌ��݂̍s�̒��O�̗�𑫂�
                    current[j] = previous[j] + current[j - 1];
                }
                current.CopyTo(previous, 0);
            }

            return current[n - 1];
        }

        public int UniquePathsWithDPFix2(int m, int n)
        {
            // �ŏ��̍s��z��ɓ����
            var nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    // ���O�̃f�[�^��Ώۂ̃}�X�ɉ��Z����
                    nums[j] += nums[j - 1];
                }
            }

            return nums[n - 1];
        }

        public int UniquePathsWithDP(int m, int n)
        {
            // ���DP�e�[�u���쐬
            var dp = new int[m, n];

            // 1�p�^�[���ƂȂ�f�[�^��1�Ŗ��߂�
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }

            // �s���Ƃ̃��[�v
            for (int i = 1; i < m; i++)
            {
                // �񂲂Ƃ̃��[�v
                for (int j = 1; j < n; j++)
                {
                    // �Ώۂ̃}�X�ɍ��Ə�̃}�X�����v�l������
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            // �S�[���̃}�X�̒l��Ԃ�
            return dp[m - 1, n - 1];
        }
    }
}