using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0121
    {
        [Fact]
        public void Case1()
        {
            MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 })
                .Should().Be(5);
        }

        [Fact]
        public void Case2()
        {
            MaxProfit(new int[] { 7, 6, 4, 3, 1 })
                .Should().Be(0);
        }

        [Fact]
        public void Case3()
        {
            MaxProfit(new int[] { 7, 5, 6, 3, 7, 4 })
                .Should().Be(4);
        }

        [Fact]
        public void Case4()
        {
            MaxProfit(new int[] { 7 })
                .Should().Be(0);
        }

        public int MaxProfit(int[] prices)
        {
            var buyDate = 0;
            var sellDate = 1;
            var maxProfit = 0;

            while (sellDate < prices.Length)
            {
                // 利益が出るならば
                if (prices[buyDate] < prices[sellDate])
                {
                    // この日売った場合の利益と最高利益を比較して高い方を最高利益とする
                    var profit = prices[sellDate] - prices[buyDate];
                    maxProfit = Math.Max(maxProfit, profit);
                }
                else
                {
                    // さらに安い日に購入した場合で探索再開
                    buyDate = sellDate;
                }

                // 売却日を次の日に進める
                sellDate++;
            }

            return maxProfit;
        }
    }
}