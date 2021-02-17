using System.Collections.Generic;


class Tree
{
    #region Constructeur
    public Tree(){
        Children = new List<Tree>();
    }

    public Tree(int id, int parentId){
        Id = id;
        ParentId = parentId;
        Children = new List<Tree>();
    }
    #endregion

    #region Variables membres
    public int Id {get; set;}
    public List<Tree> Children {get; set;}    
    public int ParentId {get; set;}
    #endregion

    #region Méthodes

    public static Tree BuildTree(List<Tree> treeNodes, Tree root){
        
        foreach(Tree node in treeNodes){
            if(root.Id == node.ParentId){
                root.Children.Add(BuildTree(treeNodes, node));
            }
        }
        return root;
    }

    public static void AddNodeFromValues(List<int> values, int position, Tree tree){
        int length = values.Count;
        List<Tree> childOfThisTree =  new List<Tree>();        
        if(2*position + 1 < length) {
			Tree leftChild = new Tree(values[2*position + 1], tree.Id);
			AddNodeFromValues(values, 2*position + 1, leftChild);
			childOfThisTree.Add(leftChild);
		}
		if(2*position + 2 < length) {
			Tree rightChild = new Tree(values[2*position + 2], tree.Id);
			AddNodeFromValues(values, 2*position + 2, rightChild);
			childOfThisTree.Add(rightChild);
		}
		tree.Children.AddRange(childOfThisTree);        
    }   

    #endregion
}

