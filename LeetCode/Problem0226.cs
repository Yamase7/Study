using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    public class Problem0226
    {
        [Fact]
        public void Case1()
        {
            var root = InvertTree(new TreeNode(
                4,
                new TreeNode(
                    2,
                    new TreeNode(1),
                    new TreeNode(3)),
                new TreeNode(
                    7,
                    new TreeNode(6),
                    new TreeNode(9))));

            root.val.Should().Be(4);
            root.left.val.Should().Be(7);
            root.right.val.Should().Be(2);
            root.left.left.val.Should().Be(9);
            root.left.right.val.Should().Be(6);
            root.right.left.val.Should().Be(3);
            root.right.right.val.Should().Be(1);
        }

        [Fact]
        public void Case2()
        {
            var root = InvertTree(new TreeNode(
                2,
                new TreeNode(1),
                new TreeNode(3)));

            root.val.Should().Be(2);
            root.left.val.Should().Be(3);
            root.right.val.Should().Be(1);
        }

        [Fact]
        public void Case3()
        {
            InvertTree(null).Should().BeNull();
        }

        private TreeNode InvertTree(TreeNode root)
        {
            if (root is null) return null;
            var tempLeft = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(tempLeft);
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