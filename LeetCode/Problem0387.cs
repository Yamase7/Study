using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0387
    {
        [Fact]
        public void Case1()
        {
            FirstUniqChar("leetcode")
                .Is(0);
        }

        [Fact]
        public void Case2()
        {
            FirstUniqChar("loveleetcode")
                .Is(2);
        }

        [Fact]
        public void Case3()
        {
            FirstUniqChar("aabb")
                .Is(-1);
        }

        public int FirstUniqChar(string s)
        {
            // �o���񐔂��L�^���邽�߃A���t�@�x�b�g���̔z���p�ӂ���
            int[] alphabetIndex = new int[26];

            // �ꕶ�������o���đΏۂ̕����̏o���񐔂𑝂₵�ċL�^����
            for (int i = 0; i < s.Length; i++)
            {
                alphabetIndex[s[i] - 'a']++;
            }

            // �A���t�@�x�b�g���ɏo���񐔂��m�F����
            for (int i = 0; i < s.Length; i++)
            {
                // �o���񐔂����݂̂������ꍇ�Ώۂ̃C���f�b�N�X��Ԃ�
                if (alphabetIndex[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}