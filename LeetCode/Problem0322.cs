using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 異なる額面の硬貨を表す整数配列coinsと、総金額を表す整数amountが与えられる。
    /// その金額を構成するのに必要な最も少ない枚数のコインを返せ。
    /// もし、その金額がコインのどの組み合わせでも補えない場合は、-1を返せ。
    /// 各硬貨は無限にあると仮定してよい。
    /// </summary>
    [TestClass]
    public class Problem0322
    {
        [TestMethod]
        public void Case1()
        {
            CoinChange(new int[] { 1, 2, 5 }, 11)
                .Is(3);
        }

        [TestMethod]
        public void Case2()
        {
            CoinChange(new int[] { 2 }, 3)
                .Is(-1);
        }

        [TestMethod]
        public void Case3()
        {
            CoinChange(new int[] { 1 }, 0)
                .Is(0);
        }

        public int CoinChange(int[] coins, int amount)
        {
            // DPに使用する配列を生成
            var dp = new int[++amount];
            dp[0] = 0;

            // 硬貨の種類を昇順に並べ替え
            Array.Sort(coins);

            // 期待する金額までの全ての金額の必要最小数を求める
            for (int value = 1; value < amount; value++)
            {
                // DPに初期値を追加 (最小を求めるため初期値は大きい数にする)
                dp[value] = int.MaxValue;

                // 硬貨を一つずつ取り出して使用した場合を検証
                foreach (var coin in coins)
                {
                    // 取り出した硬貨が最小数を求めたい金額よりも大きければ次の金額を求める
                    if (coin > value)
                    {
                        break;
                    }

                    // 金額と取り出した硬貨の差分の金額について、必要最小数が分かっていれば
                    if (dp[value - coin] != int.MaxValue)
                    {
                        // 差分の必要数と取り出した硬貨の1枚を足して、現在の金額の必要数とする
                        dp[value] = Math.Min(dp[value - coin] + 1, dp[value]);
                    }
                }
            }

            // 求めたい金額を渡された効果の種類では出せなければ-1、出せるのであれば最小必要数を返す
            return dp[--amount] == int.MaxValue ? -1 : dp[amount];
        }
    }
}