using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Study
{
    /// <summary>
    /// ������ "PAYPALISHIRING" �́A���̂悤�ɗ^����ꂽ�s���ɃW�O�U�O�ɏ�����Ă��܂��i�ǂ݂₷�����邽�߂ɁA���̃p�^�[�����Œ�t�H���g�ŕ\������Ƃ悢�ł��傤
    /// P   A   H   N
    /// A P L S I I G
    /// Y   I   R
    /// �����āA��s���ǂ݂܂��B"pahnaplsiigyir"
    /// ��������󂯎��A�s�����^����ꂽ�炱�̕ϊ����s���R�[�h�������Ă��������B
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
            // 1�s�����������炻�̂܂ܕԂ�
            if (numRows <= 1) return s;

            // �����p��StringBuilder���s�����p�ӂ���
            var stringBuilders = new StringBuilder[numRows];
            for (int i = 0; i < stringBuilders.Length; i++) stringBuilders[i] = new StringBuilder();

            // �|�C���^��\���C���f�b�N�X�ԍ��Ɛi�s������p�ӂ���
            int idx = 0;
            var goDown = true;

            foreach (var c in s)
            {
                // �������Y���s�ɒǉ�
                stringBuilders[idx].Append(c);

                // �i�s�����̍s�Ƀ|�C���^��i�߂�
                idx += goDown ? 1 : -1;

                // �ŏ��������͍Ō�̍s��������i�s�����𔽓]����
                if (idx == 0 || idx == stringBuilders.Length - 1) goDown = !(goDown);
            }

            // �S�Ă�StringBuilder���������ĕԂ�
            var returnString = new StringBuilder();
            foreach (var stringBuilder in stringBuilders) returnString.Append(stringBuilder);

            return returnString.ToString();
        }
    }
}