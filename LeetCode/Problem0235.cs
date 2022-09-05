using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0235
    {
        /// <summary>
        /// �񕪒T���؁iBST�j���^����ꂽ�Ƃ��A
        /// BST���̗^����ꂽ2�̃m�[�h�̍Œዤ�ʑc��iLCA�j�m�[�h�����߂�
        /// 
        /// �E�B�L�y�f�B�A��LCA�̒�`�ɂ���"2�̃m�[�hp��q�̊Ԃ̍ŏ����{���c��́A
        /// T�ɂ�����p��q�̗������q���Ƃ��Ď��ł��Ⴂ�m�[�h�ƒ�`�����
        /// �i�����ł̓m�[�h�͂��ꎩ�g�̎q���ƂȂ邱�Ƃ�F�߂�j�B
        /// </summary>
        [Fact]
        public void Case1()
        {
            LowestCommonAncestor(
                new TreeNode(
                    6,
                    new TreeNode(
                        2,
                        new TreeNode(0),
                        new TreeNode(
                            4,
                            new TreeNode(3),
                            new TreeNode(5))),
                    new TreeNode(
                        8,
                        new TreeNode(7),
                        new TreeNode(9))),
                new TreeNode(2),
                new TreeNode(8))
                .Should().Be(6);
        }

        [Fact]
        public void Case2()
        {
            LowestCommonAncestor(
                new TreeNode(
                    6,
                    new TreeNode(
                        2,
                        new TreeNode(0),
                        new TreeNode(
                            4,
                            new TreeNode(3),
                            new TreeNode(5))),
                    new TreeNode(
                        8,
                        new TreeNode(7),
                        new TreeNode(9))),
                new TreeNode(2),
                new TreeNode(4))
                .Should().Be(2);
        }

        [Fact]
        public void Case3()
        {
            LowestCommonAncestor(
                new TreeNode(
                    2,
                    new TreeNode(1)),
                new TreeNode(2),
                new TreeNode(1))
                .Should().Be(2);
        }

        private TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // p��q��root�̓��������ɑ��݂������J��Ԃ�
            while ((root.val - p.val) * (root.val - q.val) > 0)
                // p��root�����Ⴉ�����獶�����ɂ���̂ŁA����root�ɂ��čēx�T������
                root = p.val < root.val ? root.left : root.right;
            return root;
        }

        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}