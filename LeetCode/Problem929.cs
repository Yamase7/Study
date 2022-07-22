using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem929
    {
        [TestMethod]
        public void Case1()
        {
            NumUniqueEmails(
                new string[]
                {
                    "test.email+alex@leetcode.com",
                    "test.e.mail+bob.cathy@leetcode.com",
                    "testemail+david@lee.tcode.com"
                })
                .Is(2);
        }

        [TestMethod]
        public void Case2()
        {
            NumUniqueEmails(
                new string[]
                {
                    "a@leetcode.com",
                    "b@leetcode.com",
                    "c@leetcode.com"
                })
                .Is(3);
        }

    public int NumUniqueEmails(string[] emails)
    {
        // �d�����폜���邽�߂Ƀn�b�V���Z�b�g��p��
        var uniqueEmails = new HashSet<string>();
        foreach (string email in emails)
        {
            // ���[�J�����ƃh���C�����ɕ�����
            var parts = email.Split("@");
            var localName = parts[0];

            // ���[�J��������'+'�ȍ~�̕�������폜����
            localName = localName.Split("+")[0];
            // ���[�J��������'.'���폜����
            localName = localName.Replace(".", "");

            // �ύX�������[�J������@�ƃh���C�������Ȃ��ăn�b�V���Z�b�g�ɒǉ�����
            uniqueEmails.Add($"{localName}@{parts[1]}");
        }

        return uniqueEmails.Count;
    }
    }
}