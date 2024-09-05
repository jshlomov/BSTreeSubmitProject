using BSTreeSubmitProject.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTreeSubmitProject
{

    internal class TreeNode
    {
        public DefenceStrategy Value { get; set; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(DefenceStrategy value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    internal class DefenceStrategiesBST
    {
        public TreeNode Root { get; set; }


        //insert
        public void Insert(DefenceStrategy value)
        {
            Root = InsertRecursive(Root, value);
        }

        private TreeNode? InsertRecursive(TreeNode? current, DefenceStrategy value)
        {
            if (current == null)
                return new TreeNode(value);
            if (current.Value.Equals(value)) return current;

            if (value.CompareTo(current.Value) < 0)
                current.Left = InsertRecursive(current.Left, value);
            if (value.CompareTo(current.Value) > 0)
                current.Right = InsertRecursive(current.Right, value);
            return current;
        }


        //pre order
        public List<DefenceStrategy> PreOrderTraversal() => PreOrderTraversalHelper(Root);

        private List<DefenceStrategy> PreOrderTraversalHelper(TreeNode? node)
        {
            if (node == null) { return []; }

            var currentNodeList = new List<DefenceStrategy> { node.Value };
            var leftSubtreeList = PreOrderTraversalHelper(node.Left);
            var rightSubtreeList = PreOrderTraversalHelper(node.Right);

            return [.. currentNodeList, .. leftSubtreeList, .. rightSubtreeList];
        }

        //pre order print
        public void PreOrderTraversalPrint() => PreOrderTraversalPrintHelper(Root, 0, "Root");

        private void PreOrderTraversalPrintHelper(TreeNode? node, int shift, string direction)
        {
            if (node == null) { return; }

            Console.WriteLine($"{new string('\t', shift)}{direction}: {node}");
            PreOrderTraversalPrintHelper(node.Left, shift + 1, "Left Chiled");
            PreOrderTraversalPrintHelper(node.Right, shift + 1, "Right Chiled");
        }

        //serch with pre order
        public List<string> SearchPreOrder(int severity) => SearchPreOrderRec(Root, severity);

        private List<string> SearchPreOrderRec(TreeNode? node, int severity)
        {
            if (node == null) return [];

            if (severity >= node.Value.MinSeverity && severity <= node.Value.MaxSeverity)
                return node.Value.Defenses;
            var left = SearchPreOrderRec(node.Left, severity);
            if (left.Count > 0)
                return left;
            return SearchPreOrderRec(node.Right, severity);
        }

        //find min severity value
        public int FindMinSeverity() => FindMinSeverity(Root);

        public int FindMinSeverity(TreeNode node)
        {
            if (node == null)
                return int.MaxValue;
            return FindMin(node).MinSeverity;
        }

        //find min node value
        public DefenceStrategy FindMin(TreeNode node)
        {
            while (node.Left != null)
                node = node.Left;
            return node.Value;
        }

        //in order
        public List<DefenceStrategy> InOrderTraversal() => InOrderTraversalHelper(Root);

        private List<DefenceStrategy> InOrderTraversalHelper(TreeNode? node)
        {
            if (node == null)
            {
                return [];
            }

            var leftSubtreeList = InOrderTraversalHelper(node.Left);
            var currentNodeList = new List<DefenceStrategy> { node.Value };
            var rightSubtreeList = InOrderTraversalHelper(node.Right);

            return [.. leftSubtreeList, .. currentNodeList, .. rightSubtreeList];
        }

        //balance the not balanced tree
        public void BalanceTree()
        {
            var listTree = InOrderTraversal();
            Root = BalanceTreeRecursive(listTree);
        }

        public TreeNode? BalanceTreeRecursive(List<DefenceStrategy> list)
        {
            if (!list.Any()) return null;
            var middle = list.Count / 2;
            var value = list[middle];
            TreeNode node = new TreeNode(value);
            node.Left = BalanceTreeRecursive(list.Take(middle).ToList());
            node.Right = BalanceTreeRecursive(list.Skip(middle + 1).ToList());
            return node;
        }


        //remove node from the tree
        public void Remove(DefenceStrategy value)
        {
            // Use a helper method for the recursive implementation
            Root = RemoveRecursive(Root, value);
        }

        private TreeNode? RemoveRecursive(TreeNode? node, DefenceStrategy value)
        {
            if (node == null)
                return null;

            if (value.CompareTo(node.Value) < 0)
                node.Left = RemoveRecursive(node.Left, value);
            else if (value.CompareTo(node.Value) > 0)
                node.Right = RemoveRecursive(node.Right, value);
            else
            {
                if (node.Left == null && node.Right == null)
                    return null;
                else if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;
                else
                {
                    DefenceStrategy minValue = FindMin(node.Right);
                    node.Value = minValue;
                    node.Right = RemoveRecursive(node.Right, minValue);
                }
            }

            return node;
        }
    }
}
