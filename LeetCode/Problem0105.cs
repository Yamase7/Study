using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 2つの整数配列preorderとinorderが与えられた際二分木を構築して返せ。
    /// preorderは二分木の前置走査、inorderは同じ二分木の順序走査を表す。
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
            // 探索範囲が範囲外であればnullを返す
            if (preStartIndex > preorder.Length - 1 || inStartIndex > inEndIndex)
            {
                return null;
            }

            // 渡された範囲とデータからルートになるノードを探す
            var node = new TreeNode(preorder[preStartIndex]);

            // 現在のノードがinorderの何番目かを探し出す
            int inIndex = 0;
            for (int i = inStartIndex; i <= inEndIndex; i++)
            {
                if (inorder[i] == node.val)
                {
                    inIndex = i;
                }
            }

            // preStartIndexは左のrootのインデックスを指定
            // inorderのインデックスは開始位置から現在のノードの左までの範囲を指定
            node.left = BuildTree(
                preStartIndex + 1,
                inStartIndex,
                inIndex - 1,
                preorder,
                inorder);

            // preStartIndexは右のrootのインデックスを指定
            // inorderのインデックスは現在のノードから終了位置の範囲を指定
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