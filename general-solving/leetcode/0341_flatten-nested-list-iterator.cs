/***************************************************************************************************
* Title : Flatten Nested List Iterator
* URL   : https://leetcode.com/problems/flatten-nested-list-iterator
* Date  : 2017-02-04
* Comp  : O(n) Time
* Author: Atiq Rahman
* Status: Accepted
* Notes : All we have to do is properly use the interface provided
*   Not a binary tree related problem at all;
*    for example, "Flatten Binary Tree to Linked List"
* meta  : tag-stack, tag-data-structure, tag-leetcode-medium
***************************************************************************************************/
public class NestedIterator
{
  List<int> fNumList;
  int index = 0;

  public NestedIterator(IList<NestedInteger> nestedList) {
    fNumList = new List<int>();
    FlattenRec(nestedList);
  }

  private void FlattenRec(IList<NestedInteger> nList) {
    for (int i=0; i< nList.Count; i++) {
      if (nList[i].IsInteger())
        fNumList.Add(nList[i].GetInteger());
      else
        FlattenRec(nList[i].GetList());
    }
  }

  public bool HasNext() {
    return index < fNumList.Count;
  }

  public int Next() {
    return fNumList[index++];
  }
}

/*
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
