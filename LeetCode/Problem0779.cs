using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// n行の表(1-index)を作成すし、1行目に0を書く。
    /// 次の行は、前の行を参照して、0を01に、1を10に置き換えます。
    /// 例えば、n = 3では、1行目は0、2行目は01、3行目は0110となる。
    /// 2つの整数nとkが与えられたとき、n行の表のn行目のk番目の（1-インデックス）シンボルを返せ。
    /// </summary>
    public class Problem0779
    {
        [Fact]
        public void Case1()
        {
            KthGrammar(1, 1)
                .Should().Be(0);
        }

        [Fact]
        public void Case2()
        {
            KthGrammar(1, 1)
                .Should().Be(0);
        }

        [Fact]
        public void Case3()
        {
            KthGrammar(2, 2)
                .Should().Be(1);
        }

        public int KthGrammar(int n, int k)
        {
            // 1行目だったら0を返す
            if (n == 1)
            {
                return 0;
            }

            // 最後の行から再帰処理を始める
            // 偶数番目の値を返す場合
            if (k % 2 == 0)
            {
                // 自分の親の番号を確認し、自分の親が0だったら1を返し、1だったら0を返す
                return KthGrammar(n - 1, k / 2) == 0 ? 1 : 0;
            }
            // 基数番目の値を返す場合
            else
            {
                // 自分の親の番号を確認し、自分の親が1だったら0を返し、0だったら1を返す
                return KthGrammar(n - 1, (k + 1) / 2) == 0 ? 0 : 1;
            }
        }
    }
}