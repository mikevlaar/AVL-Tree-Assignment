using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AvlNode 
{
    private AvlNode left;
    public AvlNode Left
    {
        get { return left; }
        set { left = value; }
    }

    private AvlNode right;
    public AvlNode Right
    {
        get { return right; }
        set { right = value; }
    }

    private AvlNode parent;
    public AvlNode Parent
    {
        get { return parent; }
        set { parent = value; }
    }

    private int value;
    public int Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    private int balance;
    public int Balance
    {
        get { return balance; }
        set { balance = value; }
    }


    public AvlNode(int aValue) 
    {
        left = right = parent = null;
        balance = 0;
        value = aValue;
    }
}
