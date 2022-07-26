using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 二分木のルートが与えられたとき、それが有効な二分木探索木（BST）であるかどうかを判断する。
    /// 有効なBSTは以下のように定義される。
    /// ノードの左サブツリーには、そのノードのキーより小さいキーを持つノードのみが含まれる。
    /// ノードの右サブツリーには、そのノードのキーより大きいキーを持つノード が含まれる。
    /// また、左サブツリーと右サブツリーの両方が二分探索木でなければならない。
    /// </summary>
    public class Problem0098
    {
        [Fact]
        public void Case1()
        {
            IsValidBST(
                new TreeNode(
                    2,
                    new TreeNode(1),
                    new TreeNode(3)))
                .Should().BeTrue();
        }

        [Fact]
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
                .Should().BeFalse();
        }

        [Fact]
        public void Case3()
        {
            IsValidBST(
                new TreeNode(
                    2,
                    new TreeNode(2),
                    new TreeNode(2)))
                .Should().BeFalse();
        }

        [Fact]
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
                .Should().BeFalse();
        }

        private bool IsValidBST(TreeNode root)
        {
            // DFS探索を開始して各ノードの構成が二分探索木になっているか
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