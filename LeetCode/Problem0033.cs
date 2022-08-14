using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �����Ƀ\�[�g���ꂽ�����z�� nums ������܂��i���m�Ȓl�j�B
    /// �֐��ɓn���O�ɁAnums �͖��m�̃s�{�b�g�C���f�b�N�X k(1 <= k<nums.length) �ŉ�]����A
    /// ���ʂƂ��Ĕz���[nums[k], nums[k + 1], ..., nums[n - 1], nums[0], nums[1], ..., nums[k - 1]] (0-indexed) �ƂȂ�\��������܂��B
    /// �Ⴆ�΁A[0,1,2,4,5,6,7] �̓s�{�b�g�C���f�b�N�X3�ŉ�]���āA[4,5,6,7,0,1,2] �ƂȂ邩������Ȃ��B
    /// 
    /// ��]��̔z��nums�Ɛ�����target���^����ꂽ�Ƃ��Atarget��nums�̒��ɂ���΂��̃C���f�b�N�X���Anums�̒��ɂȂ����-1��Ԃ��܂��B
    /// ���s���v�Z�ʂ� O(log n) �ł���A���S���Y���������D
    /// </summary>
    [TestClass]
    public class Problem0033
    {
        [TestMethod]
        public void Case1()
        {
            Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)
                .Is(4);
        }

        [TestMethod]
        public void Case2()
        {
            Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3)
                .Is(-1);
        }

        [TestMethod]
        public void Case3()
        {
            Search(new int[] { 1 }, 0)
                .Is(-1);
        }

        [TestMethod]
        public void Case4()
        {
            Search(new int[] { 1 }, 1)
                .Is(0);
        }

        [TestMethod]
        public void Case5()
        {
            Search(new int[] { 7, 8, 9, 0, 1, 2, 4, 5, 6 }, 2)
                .Is(5);
        }

        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            var left = 0;
            var right = nums.Length;

            // �T���͈͂��t�]����܂ŒT�����J��Ԃ�
            while(left < right)
            {
                // �����̃C���f�b�N�X
                var center = left + (right - left) / 2;

                // �ŏ��̒l�̈ʒu�Ǝw��̒l�̈ʒu���͈͂̒������猩�ĉE���ɂ���ꍇ
                if (target < nums[0] && nums[0] < nums[center])
                {
                    left = center + 1;
                }
                // �ŏ��̒l�̈ʒu�Ǝw��̒l�̈ʒu���͈͂̒�������݂č����ɂ���ꍇ
                else if (target >= nums[0] && nums[0] > nums[center])
                {
                    right = center;
                }
                // �ŏ��̒l�̈ʒu�Ǝw��̒l�̈ʒu���قȂ�A�w��̒l�������̉E���ɂ����
                else if (nums[center] < target)
                {
                    // �T���͈͂̊J�n�ʒu��ύX���E�������̒T���͈͂Ƃ���
                    left = center + 1;
                }
                // �ŏ��̒l�̈ʒu�Ǝw��̒l�̈ʒu���قȂ�A�w��̒l�������̍����ɂ����
                else if (nums[center] > target)
                {
                    // �T���͈͂̏I���ʒu��ύX���E�������̒T���͈͂Ƃ���
                    right = center;
                }
                // �ŏ��̒l�̈ʒu�Ǝw��̒l�̈ʒu���قȂ�A�w��̒l���������w��̒l�ł����
                else
                {
                    // �����̃C���f�b�N�X��Ԃ�
                    return center;
                }
            }

            // �w��̒l��������Ȃ������̂�-1��Ԃ�
            return -1;
        }
    }
}