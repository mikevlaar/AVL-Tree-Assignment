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
            AvlTree avt1 = new AvlTree();
            avt1.insert(15);
            avt1.insert(12);
            avt1.insert(90);
            avt1.insert(83);
            avt1.insert(99);
            avt1.insert(42);
            avt1.insert(56);
            avt1.insert(8);
            avt1.insert(74);
            ArrayList ret = avt1.inorder();
            for (int i = 0; i < ret.Count; i++)
            {
                AvlNode node = (AvlNode)ret[i];
                Console.WriteLine("Value: " + node.key + " Height: " + avt1.height(node) + " - Balance: " + node.balance);
            }
            Console.ReadLine();
        }
    }
}
