using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// �񕪖؂̃��[�g���^����ꂽ�Ƃ��A���ꂪ�L���ȓ񕪖ؒT���؁iBST�j�ł��邩�ǂ����𔻒f����B
    /// �L����BST�͈ȉ��̂悤�ɒ�`�����B
    /// �m�[�h�̍��T�u�c���[�ɂ́A���̃m�[�h�̃L�[��菬�����L�[�����m�[�h�݂̂��܂܂��B
    /// �m�[�h�̉E�T�u�c���[�ɂ́A���̃m�[�h�̃L�[���傫���L�[�����m�[�h ���܂܂��B
    /// �܂��A���T�u�c���[�ƉE�T�u�c���[�̗������񕪒T���؂łȂ���΂Ȃ�Ȃ��B
    /// </summary>
    [TestClass]
    public class Problem098
    {
        [TestMethod]
        public void Case1()
        {
            IsValidBST(
                new TreeNode(
                    2,
                    new TreeNode(1),
                    new TreeNode(3)))
                .IsTrue();
        }

        [TestMethod]
        public void Case2()
        {
            IsValidBST(
                new TreeNode(
                    5,
                    new TreeNode(1),
                    new TreeNode(
                        4,
                        new TreeNode(3),
                        new TreeNode(6))))
                .IsFalse();
        }

        [TestMethod]
        public void Case3()
        {
            IsValidBST(
                new TreeNode(
                    2,
                    new TreeNode(2),
                    new TreeNode(2)))
                .IsFalse();
        }

        [TestMethod]
        public void Case4()
        {
            IsValidBST(
                new TreeNode(
                    5,
                    new TreeNode(4),
                    new TreeNode(
                        6,
                        new TreeNode(3),
                        new TreeNode(7))))
                .IsFalse();
        }

        private bool IsValidBST(TreeNode root)
        {
            // DFS�T�����J�n���Ċe�m�[�h�̍\�����񕪒T���؂ɂȂ��Ă��邩
            return IsValidBSTWithDFS(root, long.MinValue, long.MaxValue);
        }

        private bool IsValidBSTWithDFS(TreeNode node, long min, long max)
        {
            // 
            if (node is null)
            {
                return true;
            }

            if(node.val >= max || node.val <= min)
            {
                return false;
            }

            return IsValidBSTWithDFS(node.left, min, node.val) && IsValidBSTWithDFS(node.right, node.val, max);
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