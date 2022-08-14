using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem0347
    {
        [TestMethod]
        public void Case1()
        {
            var result = TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);
            result.Contains(1).IsTrue();
            result.Contains(2).IsTrue();
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            // �e�����̏o���񐔂𐔂���
            var counter = new SortedList<int, int>();
            foreach (var num in nums)
            {
                // �Ώۂ̐������L�[���m�F���A�d�����Ă��Ȃ����1�A�d�����Ă����+1�ŏ㏑��
                counter[num] = counter.GetValueOrDefault(num) + 1;
            }

            // min heap
            var priorityQueue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => x - y));
            foreach (var pair in counter)
            {
                // �����Əo���񐔂��y�A�ɂ��ėD��x�L���[�ɒǉ�
                priorityQueue.Enqueue(pair.Key, pair.Value);

                // �o���񐔂��Ⴂ�i�D��x���Ⴂ�j���̂��폜
                if (priorityQueue.Count > k)
                {
                    priorityQueue.Dequeue();
                }
            }

            // �o���񐔂��Ⴂ���̂��珇�ɔz��ɒǉ�
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = priorityQueue.Dequeue();
            }

            return result;
        }
    }
}