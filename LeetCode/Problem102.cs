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
            // null���n���ꂽ��null��Ԃ�
            if (root is null)
            {
                return new List<IList<int>>();
            }

            // �[�����ɒl�̃��X�g���Ǘ����邽�߂̑S�̂̒l�Ǘ����X�g���쐬
            var depthList = new List<IList<int>>();

            // �T���Ώۂ̃m�[�h���Ǘ����邽�߂̃L���[���쐬����root��ǉ�
            var nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);

            // �T���Ώۂ������Ȃ�܂ŌJ��Ԃ�
            while (nodeQueue.Count != 0)
            {
                // ���݂̒T���Ώۂ̐����m�F���Ĉꎞ�ۑ�
                var levelsCount = nodeQueue.Count;

                // ���ݒT�����Ă���[���̒l���Ǘ����邽�߂̒l�Ǘ����X�g���쐬
                var nodeValues = new List<int>();

                // ���ݒT�����Ă���[���̃m�[�h�̐������J��Ԃ�
                for (int i = 0; i < levelsCount; i++)
                {
                    // �T���Ώۂ���m�[�h������o���Ēl��l�Ǘ����X�g�ɕۑ�
                    var node = nodeQueue.Dequeue();
                    nodeValues.Add(node.val);

                    // �Ώۂ̃m�[�h�̍��Ƀm�[�h������ΒT���Ώۃ��X�g�ɒǉ�
                    if (node.left is not null)
                    {
                        nodeQueue.Enqueue(node.left);
                    }

                    // �Ώۂ̃m�[�h�̉E�Ƀm�[�h������ΒT���Ώۃ��X�g�ɒǉ�
                    if (node.right is not null)
                    {
                        nodeQueue.Enqueue(node.right);
                    }
                }

                // ���݂̐[���̒l�Ǘ����X�g��S�̂̒l�Ǘ����X�g�ɒǉ�
                depthList.Add(nodeValues);
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