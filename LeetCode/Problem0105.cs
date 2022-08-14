using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 2�̐����z��preorder��inorder���^����ꂽ�ۓ񕪖؂��\�z���ĕԂ��B
    /// preorder�͓񕪖؂̑O�u�����Ainorder�͓����񕪖؂̏���������\���B
    /// </summary>
    [TestClass]
    public class Problem0105
    {
        [TestMethod]
        public void Case1()
        {
            var tree = BuildTree(
                new int[] { 3, 9, 20, 15, 7 },
                new int[] { 9, 3, 15, 20, 7 });

            tree.val.Is(3);
            tree.left.val.Is(9);
            tree.right.val.Is(20);
            tree.left.left.IsNull();
            tree.left.right.IsNull();
            tree.right.left.val.Is(15);
            tree.right.right.val.Is(7);
        }

        [TestMethod]
        public void Case2()
        {
            var tree = BuildTree(
                new int[] { -1 },
                new int[] { -1 });

            tree.val.Is(-1);
            tree.left.IsNull();
            tree.right.IsNull();
        }

        private TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return BuildTree(0, 0, inorder.Length - 1, preorder, inorder);
        }

        private TreeNode BuildTree(
            int preStartIndex,
            int inStartIndex,
            int inEndIndex,
            int[] preorder,
            int[] inorder)
        {
            // �T���͈͂��͈͊O�ł����null��Ԃ�
            if (preStartIndex > preorder.Length - 1 || inStartIndex > inEndIndex)
            {
                return null;
            }

            // �n���ꂽ�͈͂ƃf�[�^���烋�[�g�ɂȂ�m�[�h��T��
            var node = new TreeNode(preorder[preStartIndex]);

            // ���݂̃m�[�h��inorder�̉��Ԗڂ���T���o��
            int inIndex = 0;
            for (int i = inStartIndex; i <= inEndIndex; i++)
            {
                if (inorder[i] == node.val)
                {
                    inIndex = i;
                }
            }

            // preStartIndex�͍���root�̃C���f�b�N�X���w��
            // inorder�̃C���f�b�N�X�͊J�n�ʒu���猻�݂̃m�[�h�̍��܂ł͈̔͂��w��
            node.left = BuildTree(
                preStartIndex + 1,
                inStartIndex,
                inIndex - 1,
                preorder,
                inorder);

            // preStartIndex�͉E��root�̃C���f�b�N�X���w��
            // inorder�̃C���f�b�N�X�͌��݂̃m�[�h����I���ʒu�͈̔͂��w��
            node.right = BuildTree(
                preStartIndex + inIndex - inStartIndex + 1,
                inIndex + 1,
                inEndIndex,
                preorder,
                inorder);
            return node;

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