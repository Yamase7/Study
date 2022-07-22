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
            // インデックスをペアにしたデータと合計を優先度とした初期値を作成する
            var priorityQueue = new PriorityQueue<IndexPair, int>();
            for (int i = 0; i < nums1.Length && i < k; i++)
            {
                priorityQueue.Enqueue(new IndexPair(i, 0), nums1[i] + nums2[0]);
            }

            // 出力用リストを作成
            IList<IList<int>> result = new List<IList<int>>();

            // 出力用リストがk個分用意できるまで かつ 優先度付きキューにデータがある場合繰り返す
            while (result.Count < k && priorityQueue.Count > 0)
            {
                // 優先度付きキューからインデックスを取り出したインデックスを使用してペアを出力用データとして追加
                var dequeued = priorityQueue.Dequeue();
                int index1 = dequeued.Index1;
                int index2 = dequeued.Index2;
                result.Add(new List<int>() { nums1[index1], nums2[index2] });

                // num2で使用したインデックスを+１して次のペアを優先度キューに追加する
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
            // 優先度付きキューを作成する、昇順にソート
            var queue = new PriorityQueue<int[], int>(
                Comparer<int>.Create(
                    (a, b) => a - b));

            // 出力用リストの作成
            var result = new List<int[]>();

            // 初期データとしてnum1[i]とnum[0]をペアにしてk個分キューに追加する
            for (int i = 0; i < nums1.Length && i < k; i++)
            {
                queue.Enqueue(new int[] { nums1[i], nums2[0] }, 0);
            }

            // k回分繰り返す
            while (k-- > 0)
            {
                // キューから合計が一番小さいデータを取り出す
                var data = queue.Dequeue();
                var sum = data[0] + data[1];
                // データを出力用リストに追加する
                result.Add(data);
                // 合計とnum2の個数-1を比較して同じであれば
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