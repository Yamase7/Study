using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0046
    {
        [Fact]
        public void Case1()
        {
            Permute(new int[] { 1, 2, 3 })
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
        public void Case2()
        {
            Permute(new int[] { 0, 1 })
                .Should().BeEquivalentTo(
                    new int[][]
                    {
                        new int[] { 0, 1 },
                        new int[] { 1, 0 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case3()
        {
            Permute(new int[] { 1 })[0][0]
                .Should().Be(1);
            Permute(new int[] { 1 })
                .Should().BeEquivalentTo(
                    new List<List<int>>()
                    {
                        new List<int>() { 1 },
                    },
                    options => options.ExcludingNestedObjects());
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            var list = new List<IList<int>>();
            // �S�Ẵ��X�g���Ǘ����郊�X�g, ���ёւ��Ɏg�p���郊�X�g, �S�Ă̒l
            Backtrack(list, new List<int>(), nums);
            return list;
        }

        private void Backtrack(List<IList<int>> list, IList<int> tempList, int[] nums)
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
                // ���łɒl���ǉ�����Ă�����
                if (tempList.Contains(nums[i]))
                {
                    // �����l��ǉ�����K�v�͂Ȃ��̂ŃX�L�b�v����
                    continue;
                }

                // �ǉ����Ă��Ȃ��l��������
                // ���ёւ����X�g�ɒl��ǉ�����
                tempList.Add(nums[i]);

                // ���ȍ~�̒l��S�p�^�[���m�F����
                Backtrack(list, tempList, nums);

                // �ǉ������l�̃p�^�[���͑S�p�^�[���m�F�����̂ō폜����
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}