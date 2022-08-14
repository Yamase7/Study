using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Study
{
    [TestClass]
    public class Problem0103
    {
        [TestMethod]
        public void Case1()
        {
            var list = ZigzagLevelOrder(
                new TreeNode(
                    3,
                    new TreeNode(9),
                    new TreeNode(
                        20,
                        new TreeNode(15),
                        new TreeNode(7))));

            list[0].Is(3);
            list[1].Is(20, 9);
            list[2].Is(15, 7);
        }

        [TestMethod]
        public void Case2()
        {
            var list = ZigzagLevelOrder(new TreeNode(1));

            list[0].Is(1);
        }

        [TestMethod]
        public void Case3()
        {
            var list = ZigzagLevelOrder(null);

            list.IsNotNull();
            list.Count.Is(0);
        }
        [TestMethod]
        public void Case4()
        {
            var list = ZigzagLevelOrder(
                new TreeNode(
                    1,
                    new TreeNode(
                        2,
                        new TreeNode(4),
                        null),
                    new TreeNode(
                        3,
                        null,
                        new TreeNode(5))));

            list[0].Is(1);
            list[1].Is(3, 2);
            list[2].Is(4, 5);
        }

        private IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            // null���n���ꂽ���̃��X�g��Ԃ�
            if (root is null)
            {
                return new List<IList<int>>();
            }

            // �[�����ɒl�̃��X�g���Ǘ����邽�߂̑S�̂̒l�Ǘ����X�g���쐬
            var depthList = new List<IList<int>>();

            // �T���Ώۂ̃m�[�h���Ǘ����邽�߂̃L���[���쐬����root��ǉ�
            var nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);

            // ���]���邽�߂̃t���O
            var isReversed = false;

            // �T���Ώۂ������Ȃ�܂ŌJ��Ԃ�
            while (nodeQueue.Count > 0)
            {
                // ���݂̒T���Ώۂ̐����m�F���Ĉꎞ�ۑ�
                var levelsCount = nodeQueue.Count;

                // ���ݒT�����Ă���[���̒l���Ǘ����邽�߂̒l�Ǘ����X�g���쐬
                var nodeValues = new LinkedList<int>();

                for (int i = 0; i < levelsCount; i++)
                {
                    // �T���Ώۂ���m�[�h������o���Ēl��l�Ǘ����X�g�ɕۑ�
                    var node = nodeQueue.Dequeue();

                    // ���]���邩���f���ǉ�������������߂�
                    if (!isReversed)
                    {
                        nodeValues.AddLast(node.val);
                    }
                    else
                    {
                        nodeValues.AddFirst(node.val);
                    }

                    // ���E�����̒T���ΏۂƂ��ă��X�g�ɒǉ�
                    if (node.left is not null)
                    {
                        nodeQueue.Enqueue(node.left);
                    }
                    if (node.right is not null)
                    {
                        nodeQueue.Enqueue(node.right);
                    }
                }

                // ���݂̐[���̒l�Ǘ����X�g��S�̂̒l�Ǘ����X�g�ɒǉ�
                depthList.Add(nodeValues.ToList());

                // �i�s�����𔽓]������
                isReversed = !isReversed;
            }

            // �S�̂̒l�Ǘ����X�g��Ԃ�
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