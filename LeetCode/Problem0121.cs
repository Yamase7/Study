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
                // ���v���o��Ȃ��
                if (prices[buyDate] < prices[sellDate])
                {
                    // ���̓��������ꍇ�̗��v�ƍō����v���r���č��������ō����v�Ƃ���
                    var profit = prices[sellDate] - prices[buyDate];
                    maxProfit = Math.Max(maxProfit, profit);
                }
                else
                {
                    // ����Ɉ������ɍw�������ꍇ�ŒT���ĊJ
                    buyDate = sellDate;
                }

                // ���p�������̓��ɐi�߂�
                sellDate++;
            }

            return maxProfit;
        }
    }
}