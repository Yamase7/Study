using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0349
    {
        [Fact]
        public void Case1()
        {
            var result = Intersection(
                new int[] { 1, 2, 2, 1 },
                new int[] { 2, 2 });
            result.Contains(2);
            result.Length.Is(1);
        }

        [Fact]
        public void Case2()
        {
            var result = Intersection(
                new int[] { 4, 9, 5 },
                new int[] { 9, 4, 9, 8, 4 });
            result.Contains(9);
            result.Contains(4);
            result.Length.Is(2);
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            // �n���ꂽ�z�񂩂�d�����폜����
            var numbers1 = new HashSet<int>(nums1);
            var numbers2 = new HashSet<int>(nums2);

            // �߂�l�p�̃n�b�V���Z�b�g��p�ӂ���
            var result = new HashSet<int>();

            // number2�̒l���ЂƂ��m�F��numbers1�Ɋ܂܂�Ă����ꍇ�߂�l�Ƃ���
            foreach (var number in numbers2)
            {
                if (numbers1.Contains(number))
                {
                    result.Add(number);
                }
            }

            // �z��ɂ��ĕԂ�
            return result.ToArray();
        }
    }
}