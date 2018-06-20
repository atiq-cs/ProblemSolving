/*
    Problem     : 3 types of Traversal
    Description :
                  https://en.wikipedia.org/wiki/Tree_traversal
                   Pre-order
                   In-order
                   Post-order
                  Tested solving hackerrank problems on the topic

    Complexity  : O(n)

    Status      :   Accepted
    Notes       :
    Pre-order traversal of Binary Tree
    Solves https://www.hackerrank.com/challenges/tree-preorder-traversal

*/

void Preorder(node *root) {
    if (root == NULL)
        return;

    std::cout << root->data << " ";

    Preorder(root->left);
    Preorder(root->right);
}

/*
    In-order traversal of Binary Tree
    Solves https://www.hackerrank.com/challenges/tree-inorder-traversal/
*/
void Inorder(node *root) {
    if (root == NULL)
        return;

    Inorder(root->left);
    std::cout << root->data << " ";
    Inorder(root->right);
}

/*
    Post-order traversal of Binary Tree
    Solves https://www.hackerrank.com/challenges/tree-postorder-traversal/
*/
void Postorder(node *root) {
    if (root == NULL)
        return;

    Postorder(root->left);
    Postorder(root->right);
    std::cout << root->data << " ";
}
