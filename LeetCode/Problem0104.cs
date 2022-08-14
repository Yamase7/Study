using ChainingAssertion;
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
    public class Problem0104
    {
        [Fact]
        public void Case1()
        {
            MaxDepth(
                new TreeNode(
                    3,
                    new TreeNode(9),
                    new TreeNode(
                        20,
                        new TreeNode(15),
                        new TreeNode(7))))
                .Is(3);
        }

        [Fact]
        public void Case2()
        {
            MaxDepth(
                new TreeNode(
                    1,
                    null,
                    new TreeNode(2)))
                .Is(2);
        }

        private int MaxDepth(TreeNode root)
        {
            if(root == null)
            {
                return 0;
            }

            int maxLeft = MaxDepth(root.left);
            int maxRight = MaxDepth(root.right);
            return Math.Max(maxLeft, maxRight) + 1;
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