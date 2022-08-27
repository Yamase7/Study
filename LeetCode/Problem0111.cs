using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �񕪖؂̍����^����ꂽ�Ƃ��A���̍ő�[�x��Ԃ��B
    /// �񕪖؂̍ő�[�x�́A���[�g�m�[�h����
    /// �ŉ��̃��[�t�m�[�h�܂ł̍Œ��o�H�ɉ������m�[�h�̐��ł���B
    /// </summary>
    public class Problem0111
    {
        [Fact]
        public void Case1()
        {
            MinDepth(
                new TreeNode(
                    3,
                    new TreeNode(9),
                    new TreeNode(
                        20,
                        new TreeNode(15),
                        new TreeNode(7))))
                .Should().Be(2);
        }

        [Fact]
        public void Case2()
        {
            MinDepth(
                new TreeNode(
                    2,
                    null,
                    new TreeNode(
                        3,
                        null,
                        new TreeNode(
                            4,
                            null,
                            new TreeNode(
                                5,
                                null,
                                new TreeNode(
                                    6,
                                    null,
                                    null))))))
                .Should().Be(5);
        }

        private int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 0;
            // �[�����Ɋe�m�[�h���m�F
            while (queue.Count != 0)
            {
                // ���ݒT�����Ă���[�����L�^
                depth++;

                // ���݂̐[���̊m�F�Ώې�
                var currentTargetCount = queue.Count;

                // �m�F�Ώۂ����[�t�m�[�h���ǂ����m�F
                for (int i = 0; i < currentTargetCount; i++)
                {
                    var target = queue.Dequeue();

                    // �Ώۂ����[�t�m�[�h�ł���΍��̐[����Ԃ�
                    if (target.left is null && target.right is null)
                    {
                        return depth;
                    }

                    // ���̃m�[�h�����݂��Ă���΍��̃m�[�h��T���Ώۂɒǉ�
                    if (target.left != null)
                    {
                        queue.Enqueue(target.left);
                    }

                    // �E�̃m�[�h�����݂��Ă���ΉE�̃m�[�h��T���Ώۂɒǉ�
                    if (target.right != null)
                    {
                        queue.Enqueue(target.right);
                    }
                }
            }

            // �����ɂ��ǂ蒅������ُ�
            return depth;
        }

        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(
                int val = 0,
                TreeNode left = null,
                TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}