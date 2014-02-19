using System;
using System.Collections.Generic;
using System.Collections;

/**
 * This class is the complete and tested implementation of an AVL-tree.
 */
public class AvlTree 
{
    protected AvlNode root; // the root node

    /**
    * Add a new element with the given "value" into the tree.
    * @param value :The value of the new node.
    */
    public void insert(int value) 
    {
        // create new node
        AvlNode node = new AvlNode(value);
        // start recursive procedure for inserting the node
        insertAVL(this.root, node);
    }
 
    /**
    * Recursive method to insert a node into a tree.
    * @param compareNode :The node currently compared, usually you start with the root.
    * @param newNode :The node to be inserted.
    */
    public void insertAVL(AvlNode compareNode, AvlNode newNode) 
    {
        // If  node to compare is null, the node is inserted. If the root is null, it is the root of the tree.
        if(compareNode == null) 
        {
            this.root = newNode;
            return;
        } 
        // If compare node is smaller, continue with the left node
        if(newNode.value < compareNode.value) 
        {
            if(compareNode.left == null) 
            {
                compareNode.left = newNode;
                newNode.parent = compareNode;
     
                // Node is inserted now, continue checking the balance
                recursiveBalance(compareNode);
            } 
            else 
            {
                insertAVL(compareNode.left, newNode);
            }
    
        } 
        else if(newNode.value > compareNode.value) 
        {
            if(compareNode.right == null) 
            {
                compareNode.right = newNode;
                newNode.parent = compareNode;
     
                // Node is inserted now, continue checking the balance
                recursiveBalance(compareNode);
            } 
            else 
            {
                insertAVL(compareNode.right, newNode);
            }
        }
    }
 
    /**
    * Check the balance for each node recursivly and call required methods for balancing the tree until the root is reached.
    * @param node :The node to check the balance for, usually you start with the parent of a leaf.
    */
    public void recursiveBalance(AvlNode node) 
    {
        // we do not use the balance in this class, but store it anyway
        setBalance(node);
        int balance = node.balance;
  
        // check the balance
        if(balance == -2) 
        {
            Console.WriteLine("------------ -2 ----------------");
            if(height(node.left.left) >= height(node.left.right)) 
            {
                node = rotateRight(node);
            } 
            else 
            {
                node = doubleRotateLeftRight(node);
            }
        } 
        else if(balance == 2) 
        {
            Console.WriteLine("------------ 2 ----------------");
            if(height(node.right.right)>=height(node.right.left)) 
            {
                node = rotateLeft(node);
            } 
            else 
            {
                node = doubleRotateRightLeft(node);
            }
        }
  
        // we did not reach the root yet
        if(node.parent != null) 
        {
            recursiveBalance(node.parent);
        } 
        else 
        {
            this.root = node;
            Console.WriteLine("------------ Balancing finished ----------------");
        }
    }
 
    /**
    * Left rotation using the given node.
    * @param node :The node for the rotation.
    * @return The root of the rotated tree.
    */
    public AvlNode rotateLeft(AvlNode node) 
    {
        AvlNode rotatedNode = node.right;
        rotatedNode.parent = node.parent;
        node.right = rotatedNode.left;
  
        if(node.right != null) 
        {
            node.right.parent = node;
        }
        rotatedNode.left = node;
        node.parent = rotatedNode;
  
        if(rotatedNode.parent != null) 
        {
            if(rotatedNode.parent.right == node) 
            {
                rotatedNode.parent.right = rotatedNode;
            } 
            else if(rotatedNode.parent.left == node) 
            {
                rotatedNode.parent.left = rotatedNode;
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
    public AvlNode rotateRight(AvlNode node) 
    {
        AvlNode rotatedNode = node.left;
        rotatedNode.parent = node.parent;
        node.left = rotatedNode.right;
  
        if(node.left != null) 
        {
            node.left.parent = node;
        }
        rotatedNode.right = node;
        node.parent = rotatedNode;
  
        if(rotatedNode.parent != null) 
        {
            if(rotatedNode.parent.right == node) 
            {
                rotatedNode.parent.right = rotatedNode;
            } 
            else if(rotatedNode.parent.left == node) 
            {
                rotatedNode.parent.left = rotatedNode;
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
    public AvlNode doubleRotateLeftRight(AvlNode node) 
    {
        node.left = rotateLeft(node.left);
        return rotateRight(node);
    }
 
    /**
    * This method double rotates the node in the AVL tree.
    * First a right rotation then a left rotation.
    * @param node :The node for the rotation.
    * @return The root after the double rotation.
    */
    public AvlNode doubleRotateRightLeft(AvlNode node) 
    {
        node.right = rotateRight(node.right);
        return rotateLeft(node);
    }
 

    /**
    * Calculating the "height" of a node.
    * @param Node :The current node.
    * @return The height of a node (-1, if node is not existent eg. NULL).
    */
    public int height(AvlNode node) 
    {
        if(node == null) 
        {
            return -1;
        }
        if(node.left == null && node.right == null) 
        {
            return 0;
        } 
        else if(node.left == null) 
        {
            return 1 + height(node.right);
        } 
        else if(node.right == null) 
        {
            return 1 + height(node.left);
        } 
        else 
        {
            return 1 + maximum(height(node.left), height(node.right));
        }
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
        node.balance = height(node.right) - height(node.left);
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
        inorder(node.left, inOrderList);
        inOrderList.Add(node);
        inorder(node.right, inOrderList);
    }
}
