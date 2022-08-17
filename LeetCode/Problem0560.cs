using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0560
    {
        [Fact]
        public void Case1()
        {
            SubarraySum(
                new int[] { 1, 1, 1 },
                2)
                .Should().Be(2);
        }

        [Fact]
        public void Case2()
        {
            SubarraySum(
                new int[] { 1, 2, 3 },
                3)
                .Should().Be(2);
        }

        [Fact]
        public void Case3()
        {
            SubarraySum(
                new int[] { 1, 2, 1, 2, 1 },
                3)
                .Should().Be(4);
        }

        public int SubarraySum(int[] nums, int k)
        {
            int sum = 0, ans = 0;
            // �m�F�������v�l���J�E���g���邽�߂�Dictionary���쐬
            var dictionary = new Dictionary<int, int>()
            {
                // ��̏����̂��߂ɍ��v��0��1�Ƃ��ď����l���w�肷��
                {0, 1},
            };


            // nums���琔����������o��
            for (int i = 0; i < nums.Length; i++)
            {
                // �擪����̍��v�l�Ɏ��o�����������Z����
                sum += nums[i];

                // ���Ғl�ƍ��v�l�Ƃ̍��̐������v�l�Ƃ��ĉߋ��ɏo���������m�F
                if (dictionary.ContainsKey(sum - k))
                {
                    // �o���񐔂��񓚂ɉ��Z����
                    ans += dictionary[sum - k];
                }

                // ���v�l�̏o���񐔂����Z����
                dictionary[sum] = dictionary.GetValueOrDefault(sum) + 1;
            }

            return ans;
        }
    }
}