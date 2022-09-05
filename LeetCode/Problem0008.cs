using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Study
{
    /// <summary>
    /// �������32�r�b�g�����t�������ɕϊ����� myAtoi(string s) �֐�����������iC/C++ �� atoi �֐��Ɏ��Ă���j�B
    /// myAtoi(string s)�̃A���S���Y���͈ȉ��̒ʂ�ł���B
    /// 1. �ǂݍ���ŁC�擪�̋󔒕����͖�������B
    /// 2. ���̕������i�܂�������̖����ɂȂ��ꍇ�j'-' �܂��� '+' �ł��邩�ǂ����𒲂ׂ�B
    ///    ���̕������ǂ��炩�ł���΁A���̕�����ǂݍ��ށB
    ///    ����ɂ��A�ŏI�I�Ȍ��ʂ����ꂼ�ꕉ�����������肳���B
    ///    �ǂ�������݂��Ȃ��ꍇ�A���ʂ͐��ł���Ɖ��肷��B
    /// 3. ���̐����ȊO�̕����܂��͓��͂̏I�[�ɒB����܂ŁC���̕�����ǂݍ��ށB
    ///    �c��̕�����͖��������B
    /// 4. �����̐����𐮐��ɕϊ�����i��F"123"��123�A"0032"��32�j�B
    ///    �����ǂݎ��Ȃ������ꍇ�́A������0�ƂȂ�܂��B
    ///    �K�v�ɉ����ĕ�����ύX���܂��i�菇2���j�B
    /// 5. ������32�r�b�g�����t�������͈̔� [-2^31, 2^31 - 1] ����O��Ă���ꍇ�A���������͈̔͂Ɏ��܂�悤�ɃN�����v����B
    ///    ��̓I�ɂ́C-2^31 ��菬���������� -2^31 �ɁC2^31 - 1 ���傫�������� 2^31 - 1 �ɃN�����v�����K�v������B
    /// 6. ���ʂƂ��Ă̐�����Ԃ��B
    /// 
    /// ����
    /// �󔒕��� ' ' �������󔒕����Ƃ݂Ȃ����B
    /// �擪�̋󔒕����␔���ȍ~�̕�����ȊO�̕����͖������Ă͂Ȃ�Ȃ��B
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

            // �󔒂��Ȃ��Ȃ�܂ŃC���f�b�N�X��i�߂�
            while (index < s.Length &&  s[index] == ' ') index++;

            if (index < s.Length && (s[index] == '+' || s[index] == '-'))
            {
                if (s[index] == '-') sign = -1;
                index++;
            }

            // ��������������J��Ԃ�
            while (index < s.Length && s[index] >= '0' && s[index] <= '9')
            {
                // �ő�l/10�����傫����� �������� �ő�l/10�Ɠ�����1�̈ʂ�7�𒴂�����
                if (num > int.MaxValue / 10 || (num == int.MaxValue / 10 && s[index] - '0' > 7))
                {
                    // �����ɍ��킹�Ĕ͈͂Ɏ��܂�悤�ɃN�����v���ĕԂ�
                    return sign == 1 ? int.MaxValue: int.MinValue;
                }

                // ���݂̐��̌��𑝂₵�Đ������Z����
                num = num * 10 + s[index] - '0';
                index++;
            }

            return num * sign;
        }
    }
}