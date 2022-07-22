using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem373
    {
        [TestMethod]
        public void Case1()
        {
            var result = KSmallestPairs(
                new int[] { 1, 7, 11 },
                new int[] { 2, 4, 6 },
                3);
            result[0].Is(1, 2);
            result[1].Is(1, 4);
            result[2].Is(1, 6);
        }

        [TestMethod]
        public void Case2()
        {
            var result = KSmallestPairs(
                new int[] { 1, 1, 2 },
                new int[] { 1, 2, 3 },
                2);
            result[0].Is(1, 1);
            result[1].Is(1, 1);
        }

        [TestMethod]
        public void Case3()
        {
            var result = KSmallestPairs(
                new int[] { 1, 2 },
                new int[] { 3 },
                3);
            result[0].Is(1, 3);
            result[1].Is(2, 3);
        }

        public class IndexPair
        {
            public readonly int Index1;
            public readonly int Index2;
            public IndexPair(int index1, int index2)
            {
                Index1 = index1;
                Index2 = index2;
            }
        }

        public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            // �C���f�b�N�X���y�A�ɂ����f�[�^�ƍ��v��D��x�Ƃ��������l���쐬����
            var priorityQueue = new PriorityQueue<IndexPair, int>();
            for (int i = 0; i < nums1.Length && i < k; i++)
            {
                priorityQueue.Enqueue(new IndexPair(i, 0), nums1[i] + nums2[0]);
            }

            // �o�͗p���X�g���쐬
            IList<IList<int>> result = new List<IList<int>>();

            // �o�͗p���X�g��k���p�ӂł���܂� ���� �D��x�t���L���[�Ƀf�[�^������ꍇ�J��Ԃ�
            while (result.Count < k && priorityQueue.Count > 0)
            {
                // �D��x�t���L���[����C���f�b�N�X�����o�����C���f�b�N�X���g�p���ăy�A���o�͗p�f�[�^�Ƃ��Ēǉ�
                var dequeued = priorityQueue.Dequeue();
                int index1 = dequeued.Index1;
                int index2 = dequeued.Index2;
                result.Add(new List<int>() { nums1[index1], nums2[index2] });

                // num2�Ŏg�p�����C���f�b�N�X��+�P���Ď��̃y�A��D��x�L���[�ɒǉ�����
                index2++;
                if (index2 < nums2.Length)
                {
                    priorityQueue.Enqueue(new IndexPair(index1, index2), nums1[index1] + nums2[index2]);
                }
            }
            return result;
        }

        public IList<IList<int>> kSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            // �D��x�t���L���[���쐬����A�����Ƀ\�[�g
            var queue = new PriorityQueue<int[], int>(
                Comparer<int>.Create(
                    (a, b) => a - b));

            // �o�͗p���X�g�̍쐬
            var result = new List<int[]>();

            // �����f�[�^�Ƃ���num1[i]��num[0]���y�A�ɂ���k���L���[�ɒǉ�����
            for (int i = 0; i < nums1.Length && i < k; i++)
            {
                queue.Enqueue(new int[] { nums1[i], nums2[0] }, 0);
            }

            // k�񕪌J��Ԃ�
            while (k-- > 0)
            {
                // �L���[���獇�v����ԏ������f�[�^�����o��
                var data = queue.Dequeue();
                var sum = data[0] + data[1];
                // �f�[�^���o�͗p���X�g�ɒǉ�����
                result.Add(data);
                // ���v��num2�̌�-1���r���ē����ł����
                if (sum == nums2.Length - 1)
                {
                    continue;
                }
                queue.Enqueue(data, sum);
            }

            return (IList<IList<int>>)result;
        }
    }
}