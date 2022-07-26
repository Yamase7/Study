using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0122
    {
        [Fact]
        public void Case1()
        {
            MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 })
                .Should().Be(7);
        }

        [Fact]
        public void Case2()
        {
            MaxProfit(new int[] { 1, 2, 3, 4, 5 })
                .Should().Be(4);
        }

        [Fact]
        public void Case3()
        {
            MaxProfit(new int[] { 7, 6, 4, 3, 1 })
                .Should().Be(0);
        }

        [Fact]
        public void Case4()
        {
            MaxProfit(new int[] { 7, 5, 6, 3, 7, 4 })
                .Should().Be(5);
        }

        [Fact]
        public void Case5()
        {
            MaxProfit(new int[] { 8, 2, 3, 6, 5, 2, 1, 4, 3 })
                .Should().Be(7);
        }

        [Fact]
        public void Case6()
        {
            MaxProfit(new int[] { 7 })
                .Should().Be(0);
        }

        public int MaxProfit(int[] prices)
        {
            var currentDate = 0;
            var profit = 0;
            var days = prices.Length - 1;

            while (currentDate < days)
            {
                // 株価が上がる直前の日を購入日とする
                while (currentDate < days && prices[currentDate + 1] <= prices[currentDate])
                {
                    currentDate++;
                }
                var buyPrice = prices[currentDate];

                // 購入日から次に株価が下がる直前の日を売却日とする
                while (currentDate < days && prices[currentDate + 1] > prices[currentDate])
                {
                    currentDate++;
                }
                var sellPrice = prices[currentDate];

                // 売却して得た利益を加算する
                profit += sellPrice - buyPrice;
            }

            return profit;
        }
    }
}