using System;
using System.Linq;

static class Td4
{
    public static int BalanceFactor(Tree tree)
    {
        int left = 0;
        int right = 0;
        int result = 0;
        if (tree.Children.Any())
        {
            left = findHeight(tree.Children[0]);
            right = tree.Children.Count > 1 ? findHeight(tree.Children[1]): 0;
        }

        result = right - left;

        return result;
    }

    public static bool isBalanced(Tree node)
    {
        bool result = false;
        
        if (Math.Abs(BalanceFactor(node)) <= 1 && (node.Children.Count > 0 ? isBalanced(node.Children[0]): true) 
            && (node.Children.Count > 1 ? isBalanced(node.Children[1]): true)) { 
            return true; 
        } 

        return result;
    }
    static int findHeight(Tree root)
    {
        int left = 0;
        int right = 0;
        if (root.Children.Any())
        {
            switch (root.Children.Count)
            {
                case 1:
                    left = findHeight(root.Children[0]);
                    break;
                case 2:
                    left = findHeight(root.Children[0]);
                    right = findHeight(root.Children[1]);
                    break;
                default:
                    throw new Exception("Arbre non binaire");
            }
        }
        if (left >= right)
        {
            return left + 1;
        }
        else
        {
            return right + 1;
        }
    }
}

