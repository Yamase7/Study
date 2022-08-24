using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// n個の括弧の組が与えられたとき，
    /// 整形された括弧の組合せをすべて生成する関数を書け。
    /// </summary>
    public class Problem0022
    {
        [Fact]
        public void Case1()
        {
            GenerateParenthesis(3)
                .Should().BeEquivalentTo(
                    new string[]
                    {
                        "((()))",
                        "(()())",
                        "(())()",
                        "()(())",
                        "()()()",
                    },
                    options => options.ExcludingNestedObjects());
        }

        [Fact]
        public void Case2()
        {
            GenerateParenthesis(1)
                .Should().BeEquivalentTo(
                    new string[]
                    {
                        "()",
                    },
                    options => options.ExcludingNestedObjects());
        }

        public IList<string> GenerateParenthesis(int n)
        {
            var list = new List<string>();

            Backtrack(list, string.Empty, 0, 0, n);

            return list;
        }

        private void Backtrack(List<string> list, string currentStr, int openCount, int closeCount, int pairCount)
        {
            // 括弧をすべて使用したら
            if (currentStr.Length == pairCount * 2)
            {
                // リストに現在の組み合わせを追加
                list.Add(currentStr);
                return;
            }

            // 括弧開きがまだ使用できたら
            if (openCount < pairCount)
            {
                // 開き括弧を追加して探索
                Backtrack(list, currentStr + "(", openCount + 1, closeCount, pairCount);    
            }

            if (closeCount < openCount)
            {
                // 開き括弧を追加して探索
                Backtrack(list, currentStr + ")", openCount, closeCount + 1, pairCount);
            }
        }
    }
}