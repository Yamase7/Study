using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �قȂ鐮���̌��̔z��ƃ^�[�Q�b�g�ƂȂ鐮�����^����ꂽ�Ƃ��A
    /// �I�΂ꂽ���l�̍��v���^�[�Q�b�g�ƂȂ���̂��ׂĂ�
    /// ���j�[�N�ȑg�ݍ��킹�̃��X�g��ԂĂ��������B
    /// �g�ݍ��킹�͂ǂ̂悤�ȏ��ԂŕԂ��Ă��悢�B
    /// ���̒����瓯���������I�΂��񐔂͖������ł���B
    /// ��̑g�ݍ��킹�́A�I�΂ꂽ���̂������Ȃ��Ƃ���̕p�x���قȂ�ꍇ��ӂł���B
    /// �^����ꂽ���͂ɑ΂��āA���v��target�ɂȂ郆�j�[�N�ȑg�ݍ��킹�̐���150�ʂ�ȉ��ł��邱�Ƃ��ۏ؂����B
    /// </summary>
    public class Problem0039
    {
        [Fact]
        public void Case1()
        {
            CombinationSum(new int[] { 2, 3, 6, 7 }, 7)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 2, 2, 3 },
                        new int[] { 7 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            CombinationSum(new int[] { 2, 3, 5 }, 8)
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 2, 2, 2, 2 },
                        new int[] { 2, 3, 3 },
                        new int[] { 3, 5 },
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
                // �V�����l��ǉ�����
                tempList.Add(candidates[i]);
                currentSum += candidates[i];
                // ��������
                Backtrack(allList, tempList, candidates, currentSum, i, target);
                // �����܂ł̒l�őS�p�^�[���m�F�����̂ō폜
                tempList.RemoveAt(tempList.Count - 1);
                currentSum -= candidates[i];
            }
        }
    }
}