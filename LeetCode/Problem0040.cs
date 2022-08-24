using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// ���ԍ��̏W�܂�i���j�ƖڕW�ԍ��i�ڕW�j������Ƃ��A
    /// ���ԍ��̘a���ڕW�ɂȂ�悤�Ȍ��̒��̃��j�[�N�ȑg�ݍ��킹�����ׂċ��߂�B
    /// ���̊e�����͑g�ݍ��킹�̒��ň�x�����g�p���邱�Ƃ��ł���B
    /// ���ӁF���W���ɂ͏d������g�������܂�ł͂Ȃ�Ȃ��B
    /// </summary>
    public class Problem0040
    {
        [Fact]
        public void Case1()
        {
            CombinationSum(new int[] { 10, 1, 2, 7, 6, 1, 5 }, 8)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 1, 1, 6 },
                        new int[] { 1, 2, 5 },
                        new int[] { 1, 7 },
                        new int[] { 2, 6 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            CombinationSum(new int[] { 2, 5, 2, 1, 2 }, 5)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 1, 2, 2 },
                        new int[] { 5 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case3()
        {
            CombinationSum(new int[] { 2 }, 1)
                .Should().BeEquivalentTo(
                    new int[][] { },
                    options => options.ExcludingNestedObjects());
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var list = new List<IList<int>>();
            Array.Sort(candidates);

            Backtrack(list, new List<int>(), candidates, 0, 0, target);

            return list;
        }

        private void Backtrack(List<IList<int>> allList, List<int> tempList, int[] candidates, int currentSum, int currentIndex, int target)
        {
            // �쐬���̃��X�g�̍��v�l���ڕW�l�ȏ�Ȃ��
            if (currentSum > target)
            {
                // �V�����l��ǉ����Ȃ��̂ŕԂ�
                return;
            }

            // �ڕW�l�Ɠ����ł����
            if (currentSum == target)
            {
                // �g�ݍ��킹�����X�g�ɒǉ�����
                allList.Add(new List<int>(tempList));

                // �V�����l��ǉ����Ȃ��̂ŕԂ�
                return;
            }

            for (int i = currentIndex; i < candidates.Length; i++)
            {
                // �A����������������2�Ԗڈȍ~�������� (�]�����鏇�ԂɋC��t����)
                if (i > currentIndex && candidates[i] == candidates[i - 1])
                {
                    // �����p�^�[��������Ă��܂����߃X�L�b�v����
                    continue;
                }

                // �V�����l��ǉ�����
                tempList.Add(candidates[i]);
                currentSum += candidates[i];
                // ��������
                Backtrack(allList, tempList, candidates, currentSum, i + 1, target);
                // �����܂ł̒l�őS�p�^�[���m�F�����̂ō폜
                tempList.RemoveAt(tempList.Count - 1);
                currentSum -= candidates[i];
            }
        }
    }
}