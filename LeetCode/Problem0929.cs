using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0929
    {
        [Fact]
        public void Case1()
        {
            NumUniqueEmails(
                new string[]
                {
                    "test.email+alex@leetcode.com",
                    "test.e.mail+bob.cathy@leetcode.com",
                    "testemail+david@lee.tcode.com"
                })
                .Should().Be(2);
        }

        [Fact]
        public void Case2()
        {
            NumUniqueEmails(
                new string[]
                {
                    "a@leetcode.com",
                    "b@leetcode.com",
                    "c@leetcode.com"
                })
                .Should().Be(3);
        }

    public int NumUniqueEmails(string[] emails)
    {
        // 重複を削除するためにハッシュセットを用意
        var uniqueEmails = new HashSet<string>();
        foreach (string email in emails)
        {
            // ローカル名とドメイン名に分ける
            var parts = email.Split("@");
            var localName = parts[0];

            // ローカル名から'+'以降の文字列を削除する
            localName = localName.Split("+")[0];
            // ローカル名から'.'を削除する
            localName = localName.Replace(".", "");

            // 変更したローカル名と@とドメイン名をつなげてハッシュセットに追加する
            uniqueEmails.Add($"{localName}@{parts[1]}");
        }

        return uniqueEmails.Count;
    }
    }
}