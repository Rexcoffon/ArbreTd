using System;
using System.Collections.Generic;
using System.Linq;

static class Td1{
    public static List<Tree> Largeur(Tree node){
        var result = new List<Tree>();
        
        var q = new Queue<Tree>();
        q.Enqueue(node);

        while (q.Count > 0)
        {
            var currentNode = q.Dequeue();

            result.Add(currentNode);
            foreach (var children in currentNode.Children)
            {
                q.Enqueue(children);
            }

        }

        return result;
    }

    public static void Prefixe(Tree node, List<Tree> result){
        result.Add(node);

        foreach (var children in node.Children)
        {
            Prefixe(children, result);
        }
    }

    public static void Suffixe(Tree node, List<Tree> result){       

        foreach (var children in node.Children)
        {
            Suffixe(children, result);
        }

        result.Add(node);
    }

    public static void Infixe(Tree node, List<Tree> result){

        if(node.Children.Count <=2){
            // noeud de gauche
            if(node.Children.Any() && node.Children[0] != null){                
                Infixe(node.Children[0], result);
                result.Add(node);
                
                // noeud de droite
                if(node.Children.Count > 1 && node.Children[1] != null){
                    Infixe(node.Children[1], result);
                }                
            }else{
                result.Add(node);
            }
            
        }else{
            Console.WriteLine("Impossible l'arbre n'est pas binaire");
        }        
    }
}