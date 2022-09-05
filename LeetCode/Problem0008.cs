using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Study
{
    /// <summary>
    /// 文字列を32ビット符号付き整数に変換する myAtoi(string s) 関数を実装する（C/C++ の atoi 関数に似ている）。
    /// myAtoi(string s)のアルゴリズムは以下の通りである。
    /// 1. 読み込んで，先頭の空白文字は無視する。
    /// 2. 次の文字が（まだ文字列の末尾にない場合）'-' または '+' であるかどうかを調べる。
    ///    この文字がどちらかであれば、その文字を読み込む。
    ///    これにより、最終的な結果がそれぞれ負か正かが決定される。
    ///    どちらも存在しない場合、結果は正であると仮定する。
    /// 3. 次の数字以外の文字または入力の終端に達するまで，次の文字を読み込む。
    ///    残りの文字列は無視される。
    /// 4. これらの数字を整数に変換する（例："123"→123、"0032"→32）。
    ///    桁が読み取れなかった場合は、整数は0となります。
    ///    必要に応じて符号を変更します（手順2より）。
    /// 5. 整数が32ビット符号付き整数の範囲 [-2^31, 2^31 - 1] から外れている場合、整数がその範囲に収まるようにクランプする。
    ///    具体的には，-2^31 より小さい整数は -2^31 に，2^31 - 1 より大きい整数は 2^31 - 1 にクランプされる必要がある。
    /// 6. 結果としての整数を返す。
    /// 
    /// 注意
    /// 空白文字 ' ' だけが空白文字とみなされる。
    /// 先頭の空白文字や数字以降の文字列以外の文字は無視してはならない。
    /// </summary>
    public class Problem0008
    {
        [Fact]
        public void Case1()
        {
            MyAtoi("42")
                .Should().Be(42);
        }

        [Fact]
        public void Case2()
        {
            MyAtoi("   -42")
                .Should().Be(-42);
        }

        [Fact]
        public void Case3()
        {
            MyAtoi("4193 with words")
                .Should().Be(4193);
        }

        [Fact]
        public void Case4()
        {
            MyAtoi("")
                .Should().Be(0);
        }

        [Fact]
        public void Case5()
        {
            MyAtoi(" ")
                .Should().Be(0);
        }

        public int MyAtoi(string s)
        {
            if (s.Length == 0) return 0;

            int index = 0, sign = 1, num = 0;

            // 空白がなくなるまでインデックスを進める
            while (index < s.Length &&  s[index] == ' ') index++;

            if (index < s.Length && (s[index] == '+' || s[index] == '-'))
            {
                if (s[index] == '-') sign = -1;
                index++;
            }

            // 数字が続く限り繰り返す
            while (index < s.Length && s[index] >= '0' && s[index] <= '9')
            {
                // 最大値/10よりも大きければ もしくは 最大値/10と同じで1の位が7を超えたら
                if (num > int.MaxValue / 10 || (num == int.MaxValue / 10 && s[index] - '0' > 7))
                {
                    // 符号に合わせて範囲に収まるようにクランプして返す
                    return sign == 1 ? int.MaxValue: int.MinValue;
                }

                // 現在の数の桁を増やして数を加算する
                num = num * 10 + s[index] - '0';
                index++;
            }

            return num * sign;
        }
    }
}