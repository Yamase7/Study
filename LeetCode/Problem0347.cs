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
            // 各数字の出現回数を数える
            var counter = new SortedList<int, int>();
            foreach (var num in nums)
            {
                // 対象の数字をキーを確認し、重複していなければ1、重複していれば+1で上書き
                counter[num] = counter.GetValueOrDefault(num) + 1;
            }

            // min heap
            var priorityQueue = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => x - y));
            foreach (var pair in counter)
            {
                // 数字と出現回数をペアにして優先度キューに追加
                priorityQueue.Enqueue(pair.Key, pair.Value);

                // 出現回数が低い（優先度が低い）ものを削除
                if (priorityQueue.Count > k)
                {
                    priorityQueue.Dequeue();
                }
            }

            // 出現回数が低いものから順に配列に追加
            int[] result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = priorityQueue.Dequeue();
            }

            return result;
        }
    }
}