using FluentAssertions;
using Xunit;

namespace LeetCode
{
    public class Problem0050
    {
        [Fact]
        public void Case1()
        {
            MyPow(2.0, 10)
                .Should().Be(1024.0);
        }

        [Fact]
        public void Case2()
        {
            Assert.Equal(9.261, MyPow(2.1, 3), 3);
        }

        [Fact]
        public void Case3()
        {
            MyPow(2.0, -2)
                .Should().Be(0.25);
        }

        public double MyPow(double x, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            // �w�����}�C�i�X��������
            if (n < 0)
            {
                // ��̒l�𕪐��ɕύX���Ďw�����v���X�ɏC�����ċA�I�Ɍv�Z���������s(�I�[�o�[�t���[���)
                return 1 / x * MyPow(1 / x, -(n + 1));
            }

            // �w���������Ȃ�Γ�悵����Ǝw���̔������g�p���čċA�I�Ɏ��s����
            // �w������Ȃ�΂���Ɋ���|����
            return n % 2 == 0 ? MyPow(x * x, n / 2) : x * MyPow(x * x, n / 2);
        }
    }
}