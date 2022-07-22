using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    /// <summary>
    /// 2つの二分木が与えられるので2つをマージし、マージされた二分木を返せ。
    /// 2つのノードが重なっている場合、合計値を新しい値とする。
    /// 片方のノードしか存在しない場合はその値を引き継ぐ。
    /// ノードが存在していない場合はnullとする。
    ///
    /// 注意: マージ処理は、両方の木のルートノードから開始しなければならない。
    /// </summary>
    [TestClass]
    public class Problem617
    {

        [TestMethod]
        public void Case1()
        {
            var mergedTree = MergeTrees(
                new TreeNode(
                    1,
                    new TreeNode(
                        3,
                        new TreeNode(5)),
                    new TreeNode(2)),
                new TreeNode(
                    2,
                    new TreeNode(
                        1,
                        null,
                        new TreeNode(4)),
                    new TreeNode(
                        3,
                        null,
                        new TreeNode(7))));
            mergedTree.val.Is(3);
            mergedTree.left.val.Is(4);
            mergedTree.left.left.val.Is(5);
            mergedTree.left.right.val.Is(4);
            mergedTree.right.val.Is(5);
            mergedTree.right.right.val.Is(7);
        }

        [TestMethod]
        public void Case2()
        {
            var mergedTree = MergeTrees(
                new TreeNode(1),
                new TreeNode(
                    1,
                    new TreeNode(2)));
            mergedTree.val.Is(2);
            mergedTree.left.val.Is(2);
        }

        private TreeNode MergeTrees(TreeNode node1, TreeNode node2)
        {
            // どちらも null であれば null を返す
            if (node1 is null && node2 is null)
            {
                return null;
            }

            // 合計した新しいノードを作成
            var newNode = new TreeNode(
                (node1 == null ? 0 : node1.val) +
                (node2 == null ? 0 : node2.val));

            // 左右のノードを作成
            newNode.left = MergeTrees(
                node1 == null ? null : node1.left,
                node2 == null ? null : node2.left);
            newNode.right = MergeTrees(
                node1 == null ? null : node1.right,
                node2 == null ? null : node2.right);

            return newNode;
        }

        private class TreeNode {
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