using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �����Ń\�[�g���ꂽ����n�̔z��1�񂩂�n���]�����Ƃ��܂��B
    /// �Ⴆ�΁A�z�� nums = [0,1,2,4,5,6,7] �̏ꍇ�͎��̂悤�ɂȂ�܂��B
    /// �E4���]�������[4, 5, 6, 7, 0, 1, 2] �ƂȂ�܂��B
    /// �E7���]�������[0, 1, 2, 4, 5, 6, 7] �ɂȂ�܂��D
    /// 
    /// �z��uA�v��1���]������Ɣz��uB�v�ɂȂ邱�Ƃɒ��ӂ��Ă��������B
    ///   A : [a[0], a[1], a[2], ..., a[n-1]]
    ///   B : [a[n-1], a[0], a[1], a[2], ..., a[n-2]]
    ///   
    /// ���j�[�N�ȗv�f������]�z�� nums ���^����ꂽ�Ƃ��A���̔z��̍ŏ��̗v�f��Ԃ��B
    /// 
    /// O(log n)���ԂŎ��s�����A���S���Y�����������ƁD
    /// </summary>
    public class Problem0153
    {
        [Fact]
        public void Case1()
        {
            FindMin(new int[] { 3, 4, 5, 1, 2 })
                .Is(1);
        }

        [Fact]
        public void Case2()
        {
            FindMin(new int[] { 4, 5, 6, 7, 0, 1, 2 })
                .Is(0);
        }

        [Fact]
        public void Case3()
        {
            FindMin(new int[] { 11, 13, 15, 17 })
                .Is(11);
        }

        public int FindMin(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var start = 0;
            var end = nums.Length - 1;

            while (start < end)
            {
                var center = start + (end - start) / 2;

                if (nums[center] > nums[end])
                {
                    start = center + 1;
                }
                else
                {
                    end = center;
                }
            }

            return nums[start];
        }
    }
}