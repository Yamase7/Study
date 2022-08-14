using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �x���g�R���x�A�ɂ́A����`����ʂ̍`�֐����ȓ��ɏo�ׂ��Ȃ���΂Ȃ�Ȃ��ו�������܂��B
    /// �x���g�R���x�A���i�Ԗڂ̉ו���weights[i] �̏d���������Ă��܂��B
    /// �����A�x���g�R���x�A��̉ו���D�ɐςݍ��݂܂��B�i�n���ꂽ�d�ʃ��X�g�̏��ԂŁj
    /// �D�̍ő�ύڏd�ʂ𒴂���ו���ςނ��Ƃ͂ł��܂���D
    /// �x���g�R���x�A��̂��ׂẲו��������ȓ��ɏo�ׂ����悤�ȁA
    /// �ł��d�ʂ����Ȃ��D�̗e�ʂ�Ԃ��Ȃ����B
    /// </summary>
    [TestClass]
    public class Problem1011
    {
        [TestMethod]
        public void Case1()
        {
            ShipWithinDays(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5)
                .Is(15);
        }

        [TestMethod]
        public void Case2()
        {
            ShipWithinDays(new int[] { 3, 2, 2, 4, 1, 4 }, 3)
                .Is(6);
        }

        [TestMethod]
        public void Case3()
        {
            ShipWithinDays(new int[] { 1, 2, 3, 1, 1 }, 4)
                .Is(3);
        }

        public int ShipWithinDays(int[] weights, int days)
        {
            // �ו������D���������Ɖ^�ׂȂ��Ȃ��Ă��܂��̂ŁA�ŏ��̑D�̐ύڏd�ʂ͈�ԏd���ו��Ɠ����B
            int left = weights.Max();

            // ����ŉ^�Ԃɂ͑D�ɑS�Ẳו��̍��v�ȏ�̐ύڏd�ʂ��K�v�ƂȂ�B
            // �ł��d�ʂ����Ȃ��D�̗e�ʂ�Ԃ����Ȃ̂ŁA�D�̐ύڏd�ʂ͂��ׂẲו��̍��v�̏d�ʂƂ���B
            int right = weights.Sum();

            // �ύڏd�ʂ͈̔͂���܂�����A�w�肳�ꂽ�����ŕԂ���ŏ��ύڏd�ʂ�񕪒T������
            while (left < right)
            {
                // �񕪒T�������邽�߂̒����l���o���B
                int mid = left + (right - left) / 2;

                // �^������ (�Œ�ł�1��)
                int needDays = 1;
                int cur = 0;

                // �D�ɉו��̔������J�n����
                foreach (int w in weights)
                {
                    // �Ώۂ̉ו���ςݍ��񂾂�ύڏd�ʂ𒴂���ꍇ
                    if (cur + w > mid)
                    {
                        // ���̓��ɉ^������
                        needDays += 1;
                        cur = 0;
                    }

                    // �ו���ςݍ���
                    cur += w;
                }

                // �S�ĉ^�Ԃ̂ɕK�v�ȓ������w��̓����𒴂��Ă����
                if (needDays > days)
                {
                    // �T���͈͂�ς��Ă���ɑ傫�Ȑύڏd�ʂ�T������
                    left = mid + 1;
                }
                else
                {
                    // �T���͈͂�ς��Ă���ɏ����Ȑύڏd�ʂ�T������
                    right = mid;
                }
            }

            // �T�����ʂ�Ԃ�
            return left;
        }
    }
}