/***************************************************************************
* Title : Deque-STL
* URL   : https://www.hackerrank.com/challenges/deque-stl
* Date  : 2016-01-03
* Comp  : O(N) as argued by geekforgeeks
* Author: Atiq Rahman
* Status: Accepted
* Notes : Idea from: http://www.geeksforgeeks.org/maximum-of-all-subarrays-of-size-k/
* Notes : initially push all items to the deque
*   - items, not the values but indices of items
*   when inserting an item into the queue
*   - drop all smaller ones
*   remove from front i-k index
*
* meta  : tag-data-structure, tag-ds-queue
***************************************************************************/
#include <iostream>
#include <deque>

int main() {
  void push_to_queue_window(int A[], std::deque<int>& mydeq, int k, int i, bool is_first_window);

  int T; std::cin >> T;
  while (T--) {
    int N; std::cin >> N;
    int K; std::cin >> K;
    std::deque<int> mydeque(K);
    int *A = new int[N];

    for (int i = 0; i<N; i++)
      std::cin >> A[i];

    mydeque.clear();
    for (int i = 0; i<N; i++)
      push_to_queue_window(A, mydeque, K, i, (i<K - 1));
    std::cout << std::endl;
    delete[] A;
  }
  return 0;
}

/*
1. first k-1 items should be pushed back too and result should be printed
2. on first condition a while might be necessary
*/
void push_to_queue_window(int A[], std::deque<int>& mydeq, int k, int i, bool is_first_window) {
  // get rid of items that are out of current Window
  if (!is_first_window && !mydeq.empty() && mydeq.front() == i - k)
    mydeq.pop_front();

  // remove smaller items
  while (!mydeq.empty() && A[i] >= A[mydeq.back()])
    mydeq.pop_back();

  mydeq.push_back(i);
  if (!is_first_window)
    std::cout << A[mydeq.front()] << " ";
}
