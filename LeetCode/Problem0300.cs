using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �����̔z��nums���^����ꂽ�Ƃ��A�����ɑ�������ł����������z��̒�����Ԃ��B
    /// �����z��Ƃ́A�z�񂩂�c��̗v�f�̏�����ς����ɁA�ꕔ�܂��͑S���̗v�f���폜���ē�����z��̂��Ƃł��B
    /// �Ⴆ�΁A[3,6,2,7] �͔z��[0, 3, 1, 6, 2, 2, 7] �̕����z��ƂȂ�܂��B
    /// </summary>
    public class Problem0300
    {
        [Fact]
        public void Case1()
        {
            LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 })
                .Is(4);
        }

        [Fact]
        public void Case2()
        {
            LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 })
                .Is(4);
        }

        [Fact]
        public void Case3()
        {
            LengthOfLIS(new int[] { 7, 7, 7, 7, 7, 7, 7 })
                .Is(1);
        }

        [Fact]
        public void Case4()
        {
            LengthOfLIS(new int[] { 8, 4, 5, 6, 3 })
                .Is(3);
        }

        [Fact]
        public void Case5()
        {
            LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 20, 18, 26, 35, 6, 70 })
                .Is(7);
        }

    public int LengthOfLIS(int[] nums)
    {
        // LIS�̖����̓��ŏ��𒷂����̔z��ɓ����z���p�ӂ���
        int[] tails = new int[nums.Length];

        // �ő��LIS�̒������v�����邽�߂̕ϐ���p��
        int tailsLength = 0;

        // �z�񂩂�LIS�̐擪�Ƃ���l��������o��
        foreach (var currentNo in nums)
        {
            // LIS�̒l���m�F���鏉��͈̔͂��߂�
            var lowIndex = 0;
            var highIndex = tailsLength;

            // �͈͂�1�ɂȂ�܂ŌJ��Ԃ�
            while (lowIndex != highIndex)
            {
                // LIS�����͈͂̒����̃C���f�b�N�X������o��
                int tailsIndex = (lowIndex + highIndex) / 2;

                // �������������̒l�����o�����l�̕����傫����Ό����͈͂𒆉��̎�����ɕύX
                if (tails[tailsIndex] < currentNo)
                {
                    lowIndex = tailsIndex + 1;
                }
                // ��������Β����܂łƂ���
                else
                {
                    highIndex = tailsIndex;
                }
            }

            // �͈͂���ɂȂ����ӏ��ɔԍ����i�[
            tails[lowIndex] = currentNo;

            // �㏑������Ȃ����LIS�̐V�K�ǉ��ƂȂ�̂ŃT�C�Y���C���N�������g
            if (lowIndex == tailsLength)
            {
                tailsLength++;

            }
        }
        return tailsLength;
    }
    }
}