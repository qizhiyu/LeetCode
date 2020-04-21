using System.Collections.Generic;

public class Solution
{
    public TreeNode BstFromPreorder(int[] values)
    {
        // path from root node to current node
        var pathFromTop = new List<TreeNode>(values.Length);
        int tail = -1;

        void RegisterToPath(TreeNode node)
        {
            //t.Dump("T");
            if (pathFromTop.Count <= tail + 1)
            {
                pathFromTop.Add(node);
                tail++;
            }
            else
            {
                pathFromTop[++tail] = node;
            }
            //s.Dump();
        }

        if (values.Length == 0) return null;

        var root = new TreeNode(values[0]);
        RegisterToPath(root);

        for (var i = 1; i < values.Length; i++)
        {
            var valueToInsert = values[i];
            var node = new TreeNode(valueToInsert);
            var possibleParent = pathFromTop[tail];

            // left
            if (valueToInsert < possibleParent.val)
            {
                possibleParent.left = node;
                RegisterToPath(node);
                continue;
            }

            // valueToInsert is bigger than parent, note that it can be anywhere higher in the tree.
            // if valueToInsert is biggest among the path, it will be the rightest node with biggest value; 
            // otherwise it is the right node of the node with biggest value but small than valueToInsert
            var parentIndex = tail;
            var max = possibleParent.val;

            for (var j = tail - 1; j >= 0; j--)
            {
                var val = pathFromTop[j].val;
                if (val > valueToInsert)
                {
                    break;
                }

                if (val > max)
                {
                    max = val;
                    parentIndex = j;
                }
            }

            pathFromTop[parentIndex].right = node;
            
            // new node and its parent will be end of path from top
            tail = parentIndex;
            RegisterToPath(node);
        }

        return root;
    }
}