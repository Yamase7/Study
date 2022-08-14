using ChainingAssertion;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0112
    {
        [Fact]
        public void Case1()
        {
            HasPathSum(
                new TreeNode(
                    5,
                    new TreeNode(
                        4,
                        new TreeNode(
                            11,
                            new TreeNode(7),
                            new TreeNode(2))),
                    new TreeNode(
                        8,
                        new TreeNode(13),
                        new TreeNode(
                            4,
                            null,
                            new TreeNode(1)))),
                22).IsTrue();
        }

        [Fact]
        public void Case2()
        {
            HasPathSum(
                new TreeNode(
                    1,
                    new TreeNode(2),
                    new TreeNode(3)),
                5).IsFalse();
        }

        [Fact]
        public void Case3()
        {
            HasPathSum(
                null,
                0).IsFalse();
        }

        [Fact]
        public void Case4()
        {
            HasPathSum(
                new TreeNode(
                    1,
                    new TreeNode(2)),
                1).IsFalse();
        }

        [Fact]
        public void Case5()
        {
            HasPathSum(
                new TreeNode(
                    -2,
                    null,
                    new TreeNode(-3)),
                -5).IsTrue();
        }

        private bool HasPathSum(TreeNode node, int targetSum)
        {
            if (node == null)
            {
                return false;
            }

            if (node.left is null && node.right is null)
            {
                return node.val == targetSum;
            }

            return HasPathSum(node.left, targetSum - node.val) || HasPathSum(node.right, targetSum - node.val);
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