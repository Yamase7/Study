using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Study
{
    /// <summary>
    /// 文字列 "PAYPALISHIRING" は、次のように与えられた行数にジグザグに書かれています（読みやすくするために、このパターンを固定フォントで表示するとよいでしょう
    /// P   A   H   N
    /// A P L S I I G
    /// Y   I   R
    /// そして、一行ずつ読みます。"pahnaplsiigyir"
    /// 文字列を受け取り、行数が与えられたらこの変換を行うコードを書いてください。
    /// </summary>
    public class Problem0006
    {
        [Fact]
        public void Case1()
        {
            Convert("PAYPALISHIRING", 3)
                .Should().Be("PAHNAPLSIIGYIR");
        }

        [Fact]
        public void Case2()
        {
            Convert("PAYPALISHIRING", 4)
                .Should().Be("PINALSIGYAHRPI");
        }

        [Fact]
        public void Case3()
        {
            Convert("A", 1)
                .Should().Be("A");
        }

        public string Convert(string s, int numRows)
        {
            // 1行未満だったらそのまま返す
            if (numRows <= 1) return s;

            // 結合用のStringBuilderを行数文用意する
            var stringBuilders = new StringBuilder[numRows];
            for (int i = 0; i < stringBuilders.Length; i++) stringBuilders[i] = new StringBuilder();

            // ポインタを表すインデックス番号と進行方向を用意する
            int idx = 0;
            var goDown = true;

            foreach (var c in s)
            {
                // 文字を該当行に追加
                stringBuilders[idx].Append(c);

                // 進行方向の行にポインタを進める
                idx += goDown ? 1 : -1;

                // 最初もしくは最後の行だったら進行方向を反転する
                if (idx == 0 || idx == stringBuilders.Length - 1) goDown = !(goDown);
            }

            // 全てのStringBuilderを結合して返す
            var returnString = new StringBuilder();
            foreach (var stringBuilder in stringBuilders) returnString.Append(stringBuilder);

            return returnString.ToString();
        }
    }
}