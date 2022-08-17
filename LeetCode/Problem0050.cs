using FluentAssertions;
using Xunit;

namespace LeetCode
{
    public class Problem0050
    {
        [Fact]
        public void Case1()
        {
            MyPow(2.0, 10)
                .Should().Be(1024.0);
        }

        [Fact]
        public void Case2()
        {
            Assert.Equal(9.261, MyPow(2.1, 3), 3);
        }

        [Fact]
        public void Case3()
        {
            MyPow(2.0, -2)
                .Should().Be(0.25);
        }

        public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            // 指数がマイナスだったら
            if (n < 0)
            {
                // 基数の値を分数に変更して指数をプラスに修正し再帰的に計算処理を実行(オーバーフロー回避)
                return 1 / x * MyPow(1 / x, -(n + 1));
            }

            // 指数が偶数ならば二乗した基数と指数の半分を使用して再帰的に実行する
            // 指数が基数ならばさらに基数を掛ける
            return n % 2 == 0 ? MyPow(x * x, n / 2) : x * MyPow(x * x, n / 2);
        }
    }
}