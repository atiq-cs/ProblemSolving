/***************************************************************************
* Title : Binary Search Tree Iterator
* URL   : https://leetcode.com/problems/binary-search-tree-iterator
* Occasn: InnoWorld Meetup 05-13
* Date  : 2018-05-15
* Comp  : O(lg N) worst case time complexity, amortized time complexity should
*   is O(1), space complexity is similar
* Status: Accepted
* Notes : https://leetcode.com/problems/binary-search-tree-iterator/discuss/
*   130629/C++-Solution-O(1)-amortized-complexity-for-both-next()-and-hasNext()
*   pushes an extra item in the stack, which allows it to verify if there's an
*   next item by checking whether Stack is Empty or not.
* meta  : tag-leetcode-medium, tag-binary-tree, tag-successor
***************************************************************************/
// at 'ds/binary-tree/Iterator.cs'