/***************************************************************************************************
* Title : First Unique Character in a String
* URL   : first-unique-character-in-a-string
* Date  : 18-10-20
* Author: Atiq Rahman
* Comp  : O(N)
* Comp  : Accepted
* Notes : Using only O(26) we can find a duplicate. However, to find the first duplicate we need
*   some sort of ordering. Hence, comes the class CharProp with a int property orderNum which
*   records at which index the char was found.
*   
*   Another approach would be to do it in O(N) + O(N) where in first loop we record which of them
*   exists more than once. And in second loop, iterating through the original string we find the
*   one that did not appear more than once using the hash-table constructed in previous loop.
* ref   : 
* rel   : 
* meta  : tag-string, tag- hash-table
***************************************************************************************************/
public class Solution
{
  public class CharProp {
    public CharProp(bool dup, int num) {
      isDup = dup;
      orderNum = num;
    }

    // true means it exists in input string
    public bool isDup { get; set; }
    // == INF means duplicate
    public int orderNum { get; set; }
  }
  CharProp[] charProps = new CharProp[26];

  // returns false if setting dup as first time
  // returns true otherwise
  private void setProp(int index, int num) {
    index -= 'a';
    if (charProps[index].isDup)
      charProps[index].orderNum = int.MaxValue;
    else {
      charProps[index].isDup = true;
      charProps[index].orderNum = num;
    }
  }

  public int FirstUniqChar(string s) {
    // Init
    for (int i = 0; i < 26; i++)
      charProps[i] = new CharProp(false, 0);

    for (int i = 0; i < s.Length; i++)
      setProp(s[i], i);

    int min = int.MaxValue;
    for (int i = 0; i < 26; i++)
      if (charProps[i].isDup && charProps[i].orderNum < min) {
        min = charProps[i].orderNum;
      }
    return min == int.MaxValue ? -1 : min;
  }
}
