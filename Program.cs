using System;
using System.Collections.Generic;
using System.Linq;

namespace Arbre
{
    class Program
    {
        // Exec avec dotnet run
        static void Main(string[] args)
        {
            //Arbre();            
            //Tas();
            ArbreEquilibre();
        }

        // TD 1 
        static void Arbre()
        {

            Tree root = new Tree()
            {
                Id = 1,
            };

            Tree[] tree = { new Tree(2, 1), new Tree(3, 1), new Tree(4, 2) };
            root = Tree.BuildTree(tree.ToList(), root);

            Console.WriteLine("Largeur");
            showListTree(Td1.Largeur(root));

            Console.WriteLine("Prefixe");
            List<Tree> prefixe = new List<Tree>();
            Td1.Prefixe(root, prefixe);
            showListTree(prefixe);

            Console.WriteLine("Suffixe");
            List<Tree> suffixe = new List<Tree>();
            Td1.Suffixe(root, suffixe);
            showListTree(suffixe);

            Console.WriteLine("Infixe");
            List<Tree> infixe = new List<Tree>();
            Td1.Infixe(root, infixe);
            showListTree(infixe);
        }

        // TD 3
        static void Tas()
        {
            List<int> listOfValues = new List<int> { 20, 2, 35, 50, 12, 885, 9, 7 };
            // Randomiser
            Random r = new Random();
            int numOfInts = 10000;
            var ints = Enumerable.Range(0, numOfInts)
                                     .Select(i => new Tuple<int, int>(r.Next(numOfInts), i))
                                     .OrderBy(i => i.Item1)
                                     .Select(i => i.Item2).ToList();

            Tree tasRoot = new Tree(20, 0);
            Tree.AddNodeFromValues(listOfValues, 0, tasRoot);

            Console.WriteLine("Infixe");
            List<Tree> infixe = new List<Tree>();
            Td1.Infixe(tasRoot, infixe);
            showListTree(infixe);
        }

        // TD 3
        static void ArbreEquilibre()
        {
            Tree root = new Tree()
            {
                Id = 1,
            };
            Tree[] tree = { new Tree(2, 1), new Tree(3, 1), new Tree(4, 3) };
            root = Tree.BuildTree(tree.ToList(), root);

            Console.WriteLine(Td4.isBalanced(root));
        }

        static void showListTree(List<Tree> list)
        {
            List<int> treeId = new List<int>();
            list.ForEach(t => treeId.Add(t.Id));
            Console.WriteLine("[{0}]", string.Join(", ", treeId.ToArray()));
        }        
    }
}
