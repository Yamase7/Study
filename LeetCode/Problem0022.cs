using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// n�̊��ʂ̑g���^����ꂽ�Ƃ��C
    /// ���`���ꂽ���ʂ̑g���������ׂĐ�������֐��������B
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
            // ���ʂ����ׂĎg�p������
            if (currentStr.Length == pairCount * 2)
            {
                // ���X�g�Ɍ��݂̑g�ݍ��킹��ǉ�
                list.Add(currentStr);
                return;
            }

            // ���ʊJ�����܂��g�p�ł�����
            if (openCount < pairCount)
            {
                // �J�����ʂ�ǉ����ĒT��
                Backtrack(list, currentStr + "(", openCount + 1, closeCount, pairCount);    
            }

            if (closeCount < openCount)
            {
                // �J�����ʂ�ǉ����ĒT��
                Backtrack(list, currentStr + ")", openCount, closeCount + 1, pairCount);
            }
        }
    }
}