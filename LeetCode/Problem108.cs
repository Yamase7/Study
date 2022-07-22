using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 要素が昇順にソートされた整数配列numsが与えられたとき、
    /// それを高さバランスのとれた二分探索木に変換せよ。
    /// 高さバランスのとれた2分木とは、
    /// 各ノードの2つの部分木の深さが1以上違わない2分木のことである。
    /// </summary>
    [TestClass]
    public class Problem108
    {
        [TestMethod]
        public void Case1()
        {
            var tree = SortedArrayToBST(new int[]
            {
                -10,
                -3,
                0,
                5,
                9
            });
            tree.val.Is(0);
            tree.left.val.Is(-3);
            tree.right.val.Is(9);
            tree.left.left.val.Is(-10);
            tree.left.right.IsNull();
            tree.right.left.val.Is(5);
            tree.right.right.IsNull();
        }

        [TestMethod]
        public void Case2()
        {
            var tree = SortedArrayToBST(new int[]
            {
                1,
                3,
            });
            tree.val.Is(3);
            tree.left.val.Is(1);
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            // エラー処理
            if (nums.Length == 0)
            {
                return null;
            }

            return CreateBSTWithDFS(nums, 0, nums.Length - 1);
        }

        public TreeNode CreateBSTWithDFS(int[] nums, int low, int high)
        {
            if (low > high)
            {
                return null;
            }

            // 中央のインデックスを求めてノードを作成
            //int mid = Convert.ToInt32(low + Math.Ceiling((double)(high - low) / 2));
            int mid = low + (high - low) / 2;
            var node = new TreeNode(nums[mid]);

            // 左右のノードを求める
            node.left = CreateBSTWithDFS(nums, low, mid - 1);
            node.right= CreateBSTWithDFS(nums, mid + 1, high);

            return node;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(
                int val=0,
                TreeNode left=null,
                TreeNode right=null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}