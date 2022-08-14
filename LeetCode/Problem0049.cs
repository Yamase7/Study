using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem0049
    {
        [TestMethod]
        public void Case1()
        {
            var result = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });

            result.Contains(new List<string>() { "bat" });
            result.Contains(new List<string>() { "nat", "tan" });
            result.Contains(new List<string>() { "ate", "eat", "tea" });
        }

        [TestMethod]
        public void Case2()
        {
            GroupAnagrams(new string[] { "" })
                .Contains(new List<string>() { "" });
        }

        [TestMethod]
        public void Case3()
        {
            GroupAnagrams(new string[] { "a" })
                .Contains(new List<string>() { "a" });
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // ���񂪂Ȃ������ꍇ�̗�O����
            if (strs == null || strs.Length == 0)
            {
                return new List<IList<string>>();
            }

            // �A�i�O�����̃O���[�v�������i�[�ꏊ��p��
            var dictionary = new Dictionary<string, List<string>>();

            // �n���ꂽ������������������
            foreach (var word in strs)
            {
                // ������������ɕ��בւ���
                char[] wordCharacters = word.ToCharArray();
                Array.Sort(wordCharacters);
                string sortedWord = new string(wordCharacters);

                // �Ώۂ̒P�ꂪ���o�̒P��̃A�i�O�����ł͂Ȃ������ꍇ���X�g���쐬
                if (!dictionary.ContainsKey(sortedWord))
                {
                    dictionary.Add(sortedWord, new List<string>());
                }

                // �P����A�i�O�����O���[�v�ɒǉ�
                dictionary[sortedWord].Add(word);
            }

            // �P��̃O���[�v�����X�g�����ĕԂ�
            return new List<IList<string>>(dictionary.Values);
        }
    }
}