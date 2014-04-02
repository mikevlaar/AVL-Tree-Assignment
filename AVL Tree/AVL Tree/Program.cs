using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.start();
        }

        public void start()
        {
            AvlTree avlTree = new AvlTree();
            avlTree.insert(15);
            avlTree.insert(12);
            avlTree.insert(90);
            avlTree.insert(83);
            avlTree.insert(99);
            avlTree.insert(42);
            avlTree.insert(56);
            avlTree.insert(8);
            avlTree.insert(74);
            ArrayList inOrderList = avlTree.inorder();
            for (int i = 0; i < inOrderList.Count; i++)
            {
                AvlNode node = (AvlNode)inOrderList[i];
                if(node.Parent != null) 
                {
                    Console.Write("\nParent: " + node.Parent.Value + " ");
                }
                Console.WriteLine("Value: " + node.Value + " Height: " + avlTree.calculateHeight(node) + " - Balance: " + node.Balance);
            }
            Console.ReadLine();
        }
    }
}
