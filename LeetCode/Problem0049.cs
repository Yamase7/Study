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
            // 制約がなかった場合の例外処理
            if (strs == null || strs.Length == 0)
            {
                return new List<IList<string>>();
            }

            // アナグラムのグループ化した格納場所を用意
            var dictionary = new Dictionary<string, List<string>>();

            // 渡された文字列を一つずつ処理する
            foreach (var word in strs)
            {
                // 文字列を昇順に並べ替える
                char[] wordCharacters = word.ToCharArray();
                Array.Sort(wordCharacters);
                string sortedWord = new string(wordCharacters);

                // 対象の単語が既出の単語のアナグラムではなかった場合リストを作成
                if (!dictionary.ContainsKey(sortedWord))
                {
                    dictionary.Add(sortedWord, new List<string>());
                }

                // 単語をアナグラムグループに追加
                dictionary[sortedWord].Add(word);
            }

            // 単語のグループをリスト化して返す
            return new List<IList<string>>(dictionary.Values);
        }
    }
}