using System;
using System.Collections.Generic;
using System.Collections;

public class AvlTree 
{
    protected AvlNode root;

    /**
    * Add a new element with the given "value" into the tree.
    * @param value :The value of the new node.
    */
    public void insert(int value) 
    {
        AvlNode node = new AvlNode(value);
        insertAVL(this.root, node);
    }

    /**
    * Calculates the Inorder traversal of this tree.
    * @return A Array-List of the tree in inorder traversal.
    */
    public ArrayList inorder()
    {
        ArrayList ret = new ArrayList();
        inorder(root, ret);
        return ret;
    }

    /**
    * Function to calculate inorder recursivly.
    * @param node :The current node.
    * @param io :The list to save the inorder traversal.
    */
    public void inorder(AvlNode node, ArrayList inOrderList)
    {
        if (node == null)
        {
            return;
        }
        inorder(node.Left, inOrderList);
        inOrderList.Add(node);
        inorder(node.Right, inOrderList);
    }

    /**
    * Calculating the "height" of a node.
    * @param Node :The current node.
    * @return The height of a node (-1, if node is not existent eg. NULL).
    */
    public int calculateHeight(AvlNode node)
    {
        if (node == null)
        {
            return -1;
        }
        if (node.Left == null && node.Right == null)
        {
            return 0;
        }
        else if (node.Left == null)
        {
            return 1 + calculateHeight(node.Right);
        }
        else if (node.Right == null)
        {
            return 1 + calculateHeight(node.Left);
        }
        else
        {
            return 1 + maximum(calculateHeight(node.Left), calculateHeight(node.Right));
        }
    }
 
    /**
    * Recursive method to insert a node into a tree.
    * @param compareNode :The node currently compared, usually you start with the root.
    * @param newNode :The node to be inserted.
    */
    private void insertAVL(AvlNode compareNode, AvlNode newNode) 
    {
        if(compareNode == null) 
        {
            this.root = newNode;
            return;
        } 
        if(newNode.Value < compareNode.Value) 
        {
            if(compareNode.Left == null) 
            {
                compareNode.Left = newNode;
                newNode.Parent = compareNode;
     
                recursiveBalance(compareNode);
            } 
            else 
            {
                insertAVL(compareNode.Left, newNode);
            }
        } 
        else if(newNode.Value > compareNode.Value) 
        {
            if(compareNode.Right == null) 
            {
                compareNode.Right = newNode;
                newNode.Parent = compareNode;
     
                recursiveBalance(compareNode);
            } 
            else 
            {
                insertAVL(compareNode.Right, newNode);
            }
        }
    }
 
    /**
    * Check the balance for each node recursivly and call required methods for balancing the tree until the root is reached.
    * @param node :The node to check the balance for, usually you start with the parent of a leaf.
    */
    private void recursiveBalance(AvlNode node) 
    {
        setBalance(node);
        int balance = node.Balance;
  
        if(balance == -2) 
        {
            if(calculateHeight(node.Left.Left) >= calculateHeight(node.Left.Right)) 
            {
                node = rotateRight(node);
                Console.WriteLine("Node has been rotated right!");
            } 
            else 
            {
                node = doubleRotateLeftRight(node);
                Console.WriteLine("Node has been double rotated left and right!");
            }
        } 
        else if(balance == 2) 
        {
            if(calculateHeight(node.Right.Right) >= calculateHeight(node.Right.Left)) 
            {
                node = rotateLeft(node);
                Console.WriteLine("Node has been rotated left!");
            } 
            else 
            {
                node = doubleRotateRightLeft(node);
                Console.WriteLine("Node has been double rotated right and left!");
            }
        }
  
        if(node.Parent != null) 
        {
            recursiveBalance(node.Parent);
        } 
        else 
        {
            this.root = node;
        }
    }
 
    /**
    * Left rotation using the given node.
    * @param node :The node for the rotation.
    * @return The root of the rotated tree.
    */
    private AvlNode rotateLeft(AvlNode node) 
    {
        AvlNode rotatedNode = node.Right;
        rotatedNode.Parent = node.Parent;
        node.Right = rotatedNode.Left;
  
        if(node.Right != null) 
        {
            node.Right.Parent = node;
        }
        rotatedNode.Left = node;
        node.Parent = rotatedNode;
  
        if(rotatedNode.Parent != null) 
        {
            if(rotatedNode.Parent.Right == node) 
            {
                rotatedNode.Parent.Right = rotatedNode;
            } 
            else if(rotatedNode.Parent.Left == node) 
            {
                rotatedNode.Parent.Left = rotatedNode;
            }
        }
        setBalance(node);
        setBalance(rotatedNode);
  
        return rotatedNode;
    }
 
    /**
    * Right rotation using the given node.
    * @param node :The node for the rotation
    * @return The root of the new rotated tree.
    */
    private AvlNode rotateRight(AvlNode node) 
    {
        AvlNode rotatedNode = node.Left;
        rotatedNode.Parent = node.Parent;
        node.Left = rotatedNode.Right;
  
        if(node.Left != null) 
        {
            node.Left.Parent = node;
        }
        rotatedNode.Right = node;
        node.Parent = rotatedNode;
  
        if(rotatedNode.Parent != null) 
        {
            if(rotatedNode.Parent.Right == node) 
            {
                rotatedNode.Parent.Right = rotatedNode;
            } 
            else if(rotatedNode.Parent.Left == node) 
            {
                rotatedNode.Parent.Left = rotatedNode;
            }
        }
        setBalance(node);
        setBalance(rotatedNode);
  
        return rotatedNode;
    }

    /**
    * This method double rotates the node in the AVL tree.
    * First a left rotation then a right rotation.
    * @param node :The node for the rotation.
    * @return The root after the double rotation.
    */
    private AvlNode doubleRotateLeftRight(AvlNode node) 
    {
        node.Left = rotateLeft(node.Left);
        return rotateRight(node);
    }
 
    /**
    * This method double rotates the node in the AVL tree.
    * First a right rotation then a left rotation.
    * @param node :The node for the rotation.
    * @return The root after the double rotation.
    */
    private AvlNode doubleRotateRightLeft(AvlNode node) 
    {
        node.Right = rotateRight(node.Right);
        return rotateLeft(node);
    }
 
    /**
    * Return the maximum of two integers.
    */
    private int maximum(int valueOne, int valueTwo) 
    {
        if(valueOne >= valueTwo) 
        {
            return valueOne;
        }
        else 
        {
            return valueTwo;
        }
    }

    /**
     * This method sets the balance of the given node in the AVL tree.
     * @param node :The current node.
     */
    private void setBalance(AvlNode node) 
    {
        node.Balance = calculateHeight(node.Right) - calculateHeight(node.Left);
    }
}
