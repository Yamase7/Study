using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0560
    {
        [Fact]
        public void Case1()
        {
            SubarraySum(
                new int[] { 1, 1, 1 },
                2)
                .Should().Be(2);
        }

        [Fact]
        public void Case2()
        {
            SubarraySum(
                new int[] { 1, 2, 3 },
                3)
                .Should().Be(2);
        }

        [Fact]
        public void Case3()
        {
            SubarraySum(
                new int[] { 1, 2, 1, 2, 1 },
                3)
                .Should().Be(4);
        }

        public int SubarraySum(int[] nums, int k)
        {
            int sum = 0, ans = 0;
            // 確認した合計値をカウントするためのDictionaryを作成
            var dictionary = new Dictionary<int, int>()
            {
                // 後の処理のために合計数0を1として初期値を指定する
                {0, 1},
            };


            // numsから数字を一つずつ取り出す
            for (int i = 0; i < nums.Length; i++)
            {
                // 先頭からの合計値に取り出した数を加算する
                sum += nums[i];

                // 期待値と合計値との差の数を合計値として過去に出現したか確認
                if (dictionary.ContainsKey(sum - k))
                {
                    // 出現回数を回答に加算する
                    ans += dictionary[sum - k];
                }

                // 合計値の出現回数を加算する
                dictionary[sum] = dictionary.GetValueOrDefault(sum) + 1;
            }

            return ans;
        }
    }
}