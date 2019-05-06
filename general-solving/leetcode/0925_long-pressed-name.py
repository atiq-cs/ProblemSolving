'''***************************************************************************************************
* Title : Long Pressed Name
* URL   : https://leetcode.com/problems/long-pressed-name/
* Date  : 2019-03-30
* Comp  : O(n+m), O(1)
* Status: Accepted
* Notes : Handle few cases for two pointers
* meta  : tag-string, tag-two-pointers, tag-leetcode-easy
***************************************************************************************************'''
class Solution:
  def isLongPressedName(self, name: str, typed: str) -> bool:
    i = 0
    matchFound = False

    for j in range(len(typed)):
      if name[i] == typed[j]:
        matchFound = True
        if i+1 < len(name) and j+1<len(typed) and name[i+1] == typed[j+1]:
          i = i +1
      else:
        if matchFound and name[i+1] == typed[j]:
          i = i +1
        else:
          return False
    return i == len(name)-1


'''
Example debug statement,
 print("i {} j {}".format(i, j))

Useful test-cases,
"pyplrz"
"ppyypllr"

from draft,
"ab"
"aabb"

Counter(ab)

a -> 1
b -> 1

Counter(aabb)
a -> 2
b -> 2

"aabb"
"abab"


name[i]

------
test-cases
"saeed"
"ssaaedd"
"alex"
"aaleex"
"laiden"
"laiden"


"saeed"
"ssaaedd"
"alex"
"aaleex"
"laiden"
"laiden"

'''
