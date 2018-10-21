/***************************************************************************************************
* Title : First Unique Character in a String
* URL   : first-unique-character-in-a-string
* Date  : 18-10-20
* Author: Atiq Rahman
* Comp  : O(N), O(26)
* Status: Accepted
* Notes : Using only O(26) we can find a duplicate. However, to find the first duplicate we need
*   some sort of ordering. Hence, comes the class CharProp with a int property orderNum which
*   records at which index the char was found.
*   
*   Second approach would be to do it in same time complexity where in first loop, we record
*   which of them exists in a hashtable and we record order number as values in the table. To
*   indiciate duplicates we use negative values. In second loop, going over the hashtable we find
*   the entry with minimum value. Using hash-table here instead of using a direct array like
*   structure is that we don't have to find a way to indicate whether a character exists in the
*   string or not. Ack: Charan
*   
*   Third approach would be to do it in O(N) + O(N) where in first loop we record which of them
*   exists more than once. And in second loop, iterating through the original string we find the
*   one that did not appear more than once using the hash-table constructed in previous loop.
* ref   : 
* rel   : 
* meta  : tag-string, tag- hash-table
***************************************************************************************************/
public class Solution
{ // 2nd approach
  private const int INF = int.MaxValue;
  public int FirstUniqChar(string s) {
    var charOrders = new Dictionary<char, int>();
    for (int i = 0; i < s.Length; i++)
      if (charOrders.ContainsKey(s[i])) {
        if (charOrders[s[i]] != INF)
          charOrders[s[i]] = INF;
      }
      else
        charOrders.Add(s[i], i);

    int min = INF; char firstUniqueChar = '\0';
    foreach (var entry in charOrders)
      if (entry.Value < min)
        min = entry.Value;
    return min == INF ? -1 : min;
  }

  // 1st approach
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
