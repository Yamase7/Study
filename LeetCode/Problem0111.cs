using FluentAssertions;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 二分木の根が与えられたとき、その最大深度を返す。
    /// 二分木の最大深度は、ルートノードから
    /// 最遠のリーフノードまでの最長経路に沿ったノードの数である。
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
            // 深さ毎に各ノードを確認
            while (queue.Count != 0)
            {
                // 現在探索している深さを記録
                depth++;

                // 現在の深さの確認対象数
                var currentTargetCount = queue.Count;

                // 確認対象がリーフノードかどうか確認
                for (int i = 0; i < currentTargetCount; i++)
                {
                    var target = queue.Dequeue();

                    // 対象がリーフノードであれば今の深さを返す
                    if (target.left is null && target.right is null)
                    {
                        return depth;
                    }

                    // 左のノードが存在していれば左のノードを探索対象に追加
                    if (target.left != null)
                    {
                        queue.Enqueue(target.left);
                    }

                    // 右のノードが存在していれば右のノードを探索対象に追加
                    if (target.right != null)
                    {
                        queue.Enqueue(target.right);
                    }
                }
            }

            // ここにたどり着いたら異常
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