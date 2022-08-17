using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Study
{
    public class Problem0047
    {
        [Fact]
        public void Case1()
        {
            PermuteUnique(new int[] { 1, 1, 2 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 1, 1, 2 },
                        new int[] { 1, 2, 1 },
                        new int[] { 2, 1, 1 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            PermuteUnique(new int[] { 1, 2, 3 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 1, 2, 3 },
                        new int[] { 1, 3, 2 },
                        new int[] { 2, 1, 3 },
                        new int[] { 2, 3, 1 },
                        new int[] { 3, 1, 2 },
                        new int[] { 3, 2, 1 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case3()
        {
            PermuteUnique(new int[] { 1 })[0][0]
                .Should().Be(1);
            PermuteUnique(new int[] { 1 })
                .Should().BeEquivalentTo(
                    new List<List<int>>()
                    {
                        new List<int>() { 1 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            var list = new List<IList<int>>();
            Array.Sort(nums);
            // �S�Ẵ��X�g���Ǘ����郊�X�g, ���ёւ��Ɏg�p���郊�X�g, �S�Ă̒l, 
            Backtrack(list, new List<int>(), nums, new bool[nums.Length]);
            return list;
        }

        private void Backtrack(List<IList<int>> list, IList<int> tempList, int[] nums, bool[] used)
        {
            // ���בւ������X�g�ɑS�Ă̒l�������Ă�����
            if (tempList.Count == nums.Length)
            {
                // ���������l���ёւ����X�g��ǉ�����
                list.Add(new List<int>(tempList));
                return;
            }

            // �l��������
            for (int i = 0; i < nums.Length; i++)
            {
                // ���łɒl��ǉ��ς�
                // �������́A�ŏ��̒l�ł͂Ȃ��A�O��Ɠ��������ŁA�ЂƂO���g�p���Ă��Ȃ��ꍇ
                if (used[i] || (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]))
                {
                    // �����l��ǉ�����K�v�͂Ȃ��̂ŃX�L�b�v����
                    continue;
                }

                // �ǉ����Ă��Ȃ��l��������
                // ���ёւ����X�g�ɒl��ǉ����Ēǉ��ς݂Ƃ���
                tempList.Add(nums[i]);
                used[i] = true;

                // ���ȍ~�̒l��S�p�^�[���m�F����
                Backtrack(list, tempList, nums, used);

                // �ǉ������l�̃p�^�[���͑S�p�^�[���m�F�����̂ō폜���ǉ��ς݂���������
                tempList.RemoveAt(tempList.Count - 1);
                used[i] = false;

            }
        }
    }
}