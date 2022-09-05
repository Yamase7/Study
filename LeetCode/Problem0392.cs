using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 2�̕�����s��t���^����ꂽ�Ƃ��As��t�̕����z��ł����true���A�����łȂ����false��Ԃ��B
    /// ������̕����z��Ƃ́A���̕����񂩂�c��̕����̑��ΓI�Ȉʒu�𗐂����ƂȂ��A
    /// �������̕����i�Ȃ��Ă��悢�j���폜���Ăł����V����������̂��Ƃł���B
    /// (��: "ace" �� "abcde" �̕���������ł��邪�A"aec" �͕���������ł͂Ȃ�)�B
    /// </summary>
    public class Problem0392
    {
        [Fact]
        public void Case1()
        {
            IsSubsequence(
                "abc",
                "ahbgdc")
                .Should().BeTrue();
        }

        [Fact]
        public void Case2()
        {
            IsSubsequence(
                "axc",
                "ahbgdc")
                .Should().BeTrue();
        }

        public bool IsSubsequence(string s, string t)
        {
            return false;
        }
    }
}