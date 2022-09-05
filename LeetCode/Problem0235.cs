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
        /// 二分探索木（BST）が与えられたとき、
        /// BST内の与えられた2つのノードの最低共通祖先（LCA）ノードを求めよ
        /// 
        /// ウィキペディアのLCAの定義によると"2つのノードpとqの間の最小公倍数祖先は、
        /// Tにおいてpとqの両方を子孫として持つ最も低いノードと定義される
        /// （ここではノードはそれ自身の子孫となることを認める）。
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
            // pとqがrootの同じ方向に存在する限り繰り返す
            while ((root.val - p.val) * (root.val - q.val) > 0)
                // pがrootよりも低かったら左方向にあるので、左をrootにして再度探索する
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