using ChainingAssertion;
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
                .Is(7);
        }

        [Fact]
        public void Case2()
        {
            MaxProfit(new int[] { 1, 2, 3, 4, 5 })
                .Is(4);
        }

        [Fact]
        public void Case3()
        {
            MaxProfit(new int[] { 7, 6, 4, 3, 1 })
                .Is(0);
        }

        [Fact]
        public void Case4()
        {
            MaxProfit(new int[] { 7, 5, 6, 3, 7, 4 })
                .Is(5);
        }

        [Fact]
        public void Case5()
        {
            MaxProfit(new int[] { 8, 2, 3, 6, 5, 2, 1, 4, 3 })
                .Is(7);
        }

        [Fact]
        public void Case6()
        {
            MaxProfit(new int[] { 7 })
                .Is(0);
        }

        public int MaxProfit(int[] prices)
        {
            var currentDate = 0;
            var profit = 0;
            var days = prices.Length - 1;

            while (currentDate < days)
            {
                // Š”‰¿‚ªã‚ª‚é’¼‘O‚Ì“ú‚ðw“ü“ú‚Æ‚·‚é
                while (currentDate < days && prices[currentDate + 1] <= prices[currentDate])
                {
                    currentDate++;
                }
                var buyPrice = prices[currentDate];

                // w“ü“ú‚©‚çŽŸ‚ÉŠ”‰¿‚ª‰º‚ª‚é’¼‘O‚Ì“ú‚ð”„‹p“ú‚Æ‚·‚é
                while (currentDate < days && prices[currentDate + 1] > prices[currentDate])
                {
                    currentDate++;
                }
                var sellPrice = prices[currentDate];

                // ”„‹p‚µ‚Ä“¾‚½—˜‰v‚ð‰ÁŽZ‚·‚é
                profit += sellPrice - buyPrice;
            }

            return profit;
        }
    }
}