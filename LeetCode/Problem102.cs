using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem102
    {
        [TestMethod]
        public void Case1()
        {
            var list = LevelOrder(
                new TreeNode(
                    3,
                    new TreeNode(9),
                    new TreeNode(
                        20,
                        new TreeNode(15),
                        new TreeNode(7))));

            list[0].Is(3);
            list[1].Is(9, 20);
            list[2].Is(15, 7);
        }

        [TestMethod]
        public void Case2()
        {
            var list = LevelOrder(new TreeNode(1));

            list[0].Is(1);
        }

        [TestMethod]
        public void Case3()
        {
            var list = LevelOrder(null);

            list.IsNotNull();
            list.Count.Is(0);
        }

        private IList<IList<int>> LevelOrder(TreeNode root)
        {
            // nullが渡されたらnullを返す
            if (root is null)
            {
                return new List<IList<int>>();
            }

            // 深さ毎に値のリストを管理するための全体の値管理リストを作成
            var depthList = new List<IList<int>>();

            // 探索対象のノードを管理するためのキューを作成してrootを追加
            var nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);

            // 探索対象が無くなるまで繰り返す
            while (nodeQueue.Count != 0)
            {
                // 現在の探索対象の数を確認して一時保存
                var levelsCount = nodeQueue.Count;

                // 現在探索している深さの値を管理するための値管理リストを作成
                var nodeValues = new List<int>();

                // 現在探索している深さのノードの数だけ繰り返す
                for (int i = 0; i < levelsCount; i++)
                {
                    // 探索対象からノードを一つ取り出して値を値管理リストに保存
                    var node = nodeQueue.Dequeue();
                    nodeValues.Add(node.val);

                    // 対象のノードの左にノードがあれば探索対象リストに追加
                    if (node.left is not null)
                    {
                        nodeQueue.Enqueue(node.left);
                    }

                    // 対象のノードの右にノードがあれば探索対象リストに追加
                    if (node.right is not null)
                    {
                        nodeQueue.Enqueue(node.right);
                    }
                }

                // 現在の深さの値管理リストを全体の値管理リストに追加
                depthList.Add(nodeValues);
            }

            // 全体の値管理リストを返す
            return depthList;
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