/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/merge-two-sorted-lists/
* Date  : 2015-06-04
* Author: Atiq Rahman
* Comp  : theta(n), where n is sum of size of linked list 1 and size of linked list 2
* Notes :
*   Solution that does not even require creating extra node and its deletion
*   We iterate through both of the linked list and compare item against items add to merged
*   linked list.
* rel   : https://leetcode.com/problems/merge-two-sorted-lists
* meta  : tag-quick-sort, tag-algo-sort, tag-ds-linked-list
***************************************************************************************************/
class Solution {
private:
  // have to check use of smart pointer
  // std::unique_ptr<LargeObject> pLarge(new LargeObject());
  ListNode *ml;
  ListNode *ml_root;
  bool isFirstTime;

  /*
    We don't know how many times object is created and constructor is called
    Therefore it's better to use a custom function
  */
  void init_mergedList() {
    isFirstTime = true;
    ml_root = ml = NULL;
  }
  
  void addNodeToMergedList(int value) {
    if (isFirstTime) {
      ml = new ListNode(value);
      ml_root = ml;
      isFirstTime = false;
    }
    else {
      // a new node is allocated and pointed to ml's next pointer member
      ml->next = new ListNode(value);
      // we forward the pointer to point to this new node
      ml = ml->next;
    }
  }
  
public:
  /**
   * @param ListNode l1 is the head of the linked list
   * @param ListNode l2 is the head of the linked list
   * @return: ListNode head of linked list
   */
  ListNode *mergeTwoLists(ListNode *l1, ListNode *l2) {
    if (l1==NULL && l2==NULL)
      return NULL;
    if (l1 == NULL)
      return l2;
    if (l2 == NULL)
      return l1;
      
    // write your code here
    init_mergedList();
    ListNode *cur1 = l1;
    ListNode *cur2 = l2;
    
    while (cur1 && cur2) {
      // insert from list 1 as long as it's current item is smaller than the current pointer
      // in list 2
      if (cur2->val > cur1->val) {
        // insert the item into result merge list
        addNodeToMergedList(cur1->val);
        cur1 = cur1->next;
      }
      // at this point we do not have the current item in list 1 smaller anymore
      // we might have cur2->val == cur1->val
      // or we reached end of list 1
      else if (cur2->val == cur1->val) {
        // insert the item into result merge list
        addNodeToMergedList(cur1->val);
        addNodeToMergedList(cur2->val);
        cur1 = cur1->next;
        cur2 = cur2->next;
      }
      // at this point we do not have the current item in list 1 smaller or equal anymore
      // we have cur2->val < cur1->val
      // or we reached end of list 1 or 2
      // if (cur1->val > cur2->val) {
      else {
        // insert the item into result merge list
        addNodeToMergedList(cur2->val);
        cur2 = cur2->next;
      }
    }
    while (cur1) {
      // insert the item into result merge list
      addNodeToMergedList(cur1->val);
      cur1 = cur1->next;
    }
    while (cur2) {
      // insert the item into result merge list
      addNodeToMergedList(cur2->val);
      cur2 = cur2->next;
    }
    
    return ml_root;
  }
};
