using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// n�s�̕\(1-index)���쐬�����A1�s�ڂ�0�������B
    /// ���̍s�́A�O�̍s���Q�Ƃ��āA0��01�ɁA1��10�ɒu�������܂��B
    /// �Ⴆ�΁An = 3�ł́A1�s�ڂ�0�A2�s�ڂ�01�A3�s�ڂ�0110�ƂȂ�B
    /// 2�̐���n��k���^����ꂽ�Ƃ��An�s�̕\��n�s�ڂ�k�Ԗڂ́i1-�C���f�b�N�X�j�V���{����Ԃ��B
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
            // 1�s�ڂ�������0��Ԃ�
            if (n == 1)
            {
                return 0;
            }

            // �Ō�̍s����ċA�������n�߂�
            // �����Ԗڂ̒l��Ԃ��ꍇ
            if (k % 2 == 0)
            {
                // �����̐e�̔ԍ����m�F���A�����̐e��0��������1��Ԃ��A1��������0��Ԃ�
                return KthGrammar(n - 1, k / 2) == 0 ? 1 : 0;
            }
            // ��Ԗڂ̒l��Ԃ��ꍇ
            else
            {
                // �����̐e�̔ԍ����m�F���A�����̐e��1��������0��Ԃ��A0��������1��Ԃ�
                return KthGrammar(n - 1, (k + 1) / 2) == 0 ? 0 : 1;
            }
        }
    }
}