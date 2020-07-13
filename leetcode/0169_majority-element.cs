/***************************************************************************************************
* Title : Majority Element
* URL   : https://leetcode.com/problems/majority-element/
* Date  : 2015-10-17
* Comp  : O(n), O(1)
* Status: Accepted
* Notes : A majority element appears more than floor (n/2) times.
*   Q: Multiple majority elements?
*    may be return most frequent one? In case of tie may be return just one of them?
* Moore's voting algorithm
*   Please note that we don't need to maintain correct count since we only need to track the
*   majority element; not the count.
* 
* This is an algorithm with O(n) time and contant space complexity
* To find a majority element provided that it exists it needs one pass
* However, if not provided then the algorithm can figure it out in another pass
*
* Let's consider an example, 3 3 4 2 2 3 4 5 2 2 2 2 3 2
* initially count = 0
* we iterate over first item 3 and set count = 1, majorityElement = 3
* Then we find next item which is 3, we set count = 2, majorityElement = 3
*  next time we get 4 so count = 1 majorityElement stays the same
*  next time we get 2 so count is decremented to 0 majorityElement stays the same
*  next time we encounter 2 again as count = 0, majorityElement is set to 2 and count = 1
*  now we get 3 so this decrements count to 0
*  next time we encounter 4 as count = 0, majorityElement is set to 4 and count = 1
*  now we get 5 so this decrements count to 0
*  next time we encounter 2 as count = 0, majorityElement is set to 2 and count = 1
*  we keep getting more of 2s and count keeps incrementing
*  when we encounter 3 (previous to last item) count decrements once and it sets count = 3
*  after encountering 2 again count = 4
*  majorityElement stays 2
*  we return 2

* What if 2 was not really majorityElement, how the next pass figures this out ?
* Consider following example, 2 2 3 3 1 1
* First pass gives us 1, but 1 is not majority element, there is not one in this example
* The solution is to count number of occurrences of majority element in another pass and verify
* that it occurs at least (n+1)/2 (consider number of items can be odd) times then it is majority element
* ref: http://www.cs.utexas.edu/~moore/best-ideas/mjrty/
*  https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
* meta  : tag-bit-manip, tag-divide-conquer, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public int MajorityElement(int[] nums) {
    int count = 0, majorityElement = -1;

    foreach (int item in nums) {
      if (count == 0) {
        majorityElement = item;
        count = 1;
      }
      else if (item == majorityElement)
        count++;
      else
        count--;
    }
    // as majority element always exists for this leetcode problem only we don't need second pass
    return majorityElement;
  }
}

/*
[3, 3, 2, 2, 2, 4, 4]
3, 3, 2, 2, 2, 4, 4, 4, 4

maj = 3
count = 2
i =2
count = 1
i=3
 count = 0
 
i=4
 maj = 2
 count = 1
 
i = 5 {4}
 count = 0
*/
