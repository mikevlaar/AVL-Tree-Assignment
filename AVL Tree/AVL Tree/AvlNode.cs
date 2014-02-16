using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AvlNode 
{
    public AvlNode left;
    public AvlNode right;
    public AvlNode parent;
    public int key;
    public int balance;

    public AvlNode(int k) 
    {
        left = right = parent = null;
        balance = 0;
        key = k;
    }
}
