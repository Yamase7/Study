using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem001
    {
        [TestMethod]
        public void Case1()
        {
            TwoSum(
                new int[] { 2, 7, 11, 15 },
                9)
                .Is(0, 1);
        }

        [TestMethod]
        public void Case2()
        {
            TwoSum(
                new int[] { 3, 2, 4 },
                6)
                .Is(1, 2);
        }

        [TestMethod]
        public void Case3()
        {
            TwoSum(
                new int[] { 3, 3 },
                6)
                .Is(0, 1);
        }

    public int[] TwoSum(int[] nums, int target)
    {
        // �m�F�ς݂̒l�ƃC���f�b�N�X���L�^���邽�߂�Dictionary���쐬
        var dictionary = new Dictionary<int, int>();

        // nums�̐擪���珇�Ɋm�F
        for (int i = 0; i < nums.Length; i++)
        {
            // ���v�l��target�ƈ�v�����邽�߂ɕK�v�Ȓl���m�F�ς݂�
            if (dictionary.ContainsKey(target - nums[i]))
            {
                // �C���f�b�N�X�����킹�ĕԂ�
                return new int[] { dictionary[target - nums[i]] , i};
            }
            // �m�F�������Ƃ̂Ȃ��l�ł����Dictionary�ɒǉ�����
            else if (!dictionary.ContainsKey(nums[i]))
            {
                dictionary.Add(nums[i], i);
            }
        }
        return new int[2];
    }
    }
}