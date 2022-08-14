using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem0121
    {
        [TestMethod]
        public void Case1()
        {
            MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 })
                .Is(5);
        }

        [TestMethod]
        public void Case2()
        {
            MaxProfit(new int[] { 7, 6, 4, 3, 1 })
                .Is(0);
        }

        [TestMethod]
        public void Case3()
        {
            MaxProfit(new int[] { 7, 5, 6, 3, 7, 4 })
                .Is(4);
        }

        [TestMethod]
        public void Case4()
        {
            MaxProfit(new int[] { 7 })
                .Is(0);
        }

        public int MaxProfit(int[] prices)
        {
            var buyDate = 0;
            var sellDate = 1;
            var maxProfit = 0;

            while (sellDate < prices.Length)
            {
                // —˜‰v‚ªo‚é‚È‚ç‚Î
                if (prices[buyDate] < prices[sellDate])
                {
                    // ‚±‚Ì“ú”„‚Á‚½ê‡‚Ì—˜‰v‚ÆÅ‚—˜‰v‚ð”äŠr‚µ‚Ä‚‚¢•û‚ðÅ‚—˜‰v‚Æ‚·‚é
                    var profit = prices[sellDate] - prices[buyDate];
                    maxProfit = Math.Max(maxProfit, profit);
                }
                else
                {
                    // ‚³‚ç‚ÉˆÀ‚¢“ú‚Éw“ü‚µ‚½ê‡‚Å’TõÄŠJ
                    buyDate = sellDate;
                }

                // ”„‹p“ú‚ðŽŸ‚Ì“ú‚Éi‚ß‚é
                sellDate++;
            }

            return maxProfit;
        }
    }
}