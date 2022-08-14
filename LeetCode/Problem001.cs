using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem001
    {
        [TestMethod]
        public void Case1()
        {
            TwoSum(
                new int[] { 2, 7, 11, 15 },
                9)
                .Is(0, 1);
        }

        [TestMethod]
        public void Case2()
        {
            TwoSum(
                new int[] { 3, 2, 4 },
                6)
                .Is(1, 2);
        }

        [TestMethod]
        public void Case3()
        {
            TwoSum(
                new int[] { 3, 3 },
                6)
                .Is(0, 1);
        }

    public int[] TwoSum(int[] nums, int target)
    {
        // 確認済みの値とインデックスを記録するためのDictionaryを作成
        var dictionary = new Dictionary<int, int>();

        // numsの先頭から順に確認
        for (int i = 0; i < nums.Length; i++)
        {
            // 合計値をtargetと一致させるために必要な値が確認済みか
            if (dictionary.ContainsKey(target - nums[i]))
            {
                // インデックスを合わせて返す
                return new int[] { dictionary[target - nums[i]] , i};
            }
            // 確認したことのない値であればDictionaryに追加する
            else if (!dictionary.ContainsKey(nums[i]))
            {
                dictionary.Add(nums[i], i);
            }
        }
        return new int[2];
    }
    }
}