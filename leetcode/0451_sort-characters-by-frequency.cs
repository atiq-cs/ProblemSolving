/***************************************************************************
* Title : Sort Characters By Frequency
* URL   : https://leetcode.com/problems/sort-characters-by-frequency
* Date  : 2018-06-07
* Author: Atiq Rahman
* Comp  : O(n), O(n)
* Status: Accepted
* Notes : Given data is unsorted.
*   if input was only chars (lower and upper)
*     limit = 'z'-'A'+1
*   and, starting index would be,
*     i-'A'
*
*   input can contain numbers as well. Then I change to offset with '0'.
*   Then I found input contains space as well. Therefore, adjusted offset with
*   ' '.
*   
*   For most optimized solution we would need additional O(N) space to maintain
*   the mapping
* meta  : tag-algo-sort, tag-csharp-lambda-exp, tag-ds-hash-table, tag-company-amazon,
*   tag-coding-test, tag-leetcode-easy
***************************************************************************/

public class Solution {
  // O(n lg n), O(1) unless sorting function requires something, this is a shorter version
  public string FrequencySort_v2(string s) {
    var chars = s.ToCharArray();
    var freq = new int['z' - ' ' + 1];

    foreach (var ch in s)
      freq[ch - ' ']++;

    Array.Sort(chars, (a, b) => freq[a - ' '] == freq[b - ' '] ? a - b : freq[b - ' '] -
      freq[a - ' ']);
    return new string(chars);
  }

  // previous v2
  public string FrequencySort_v2(string s) {
    int[] freq = new int['z' - ' ' + 1];
    char[] chars = s.ToArray();
    foreach (char ch in chars)
      freq[ch - ' ']++;
    /* Inside the lambda function,
       return freq[b-' '] - freq[a-' '];

     if we don't handle cases where frequencies are equal,
     for input, "loveleetcode"
     output becomes "eeeelolovtcd" where expected answer is "eeeeoollvtdc"

     Therefore, when frequencies are equal we wanna print them together. */
    Array.Sort(chars, (a, b) => {
      return freq[a - ' '] == freq[b - ' ']? a - b : freq[b - ' '] - freq[a - ' '];
    });
    return new String(chars);
  }

  // Borrowed and modified from 'demos/algo/sort/CountingSort.cs'
  internal class Item {
    public int priority { get; set; }   // or can be named 'key'
    public char ch { get; set; }
    public Item(int n, char ch) { priority = n; this.ch = ch; }
  }

  // O(N), O(N)
  public string FrequencySort_v1(string s) {
    int[] freq = new int['z'-' '+1];
    char[] chars = s.ToArray();
    /* maxFreq is required if we do counting sort
    int maxFreq = 0;
    foreach ( char ch in chars)
      maxFreq = Math.Max(maxFreq, ++freq[ch-' ']); */
    foreach (char ch in chars)
      freq[ch - ' ']++;

    /* We don't need a counting sort here. All we need is a class
     * representations. To either retain original indices or the characters
     * indices are representing..
     */
    Item[] items = new Item[freq.Length];
    for (int i = 0; i < freq.Length; i++)
      items[i] = new Item(freq[i], (char)(i + ' '));

    // Because sort on a collection of constant size is O(1) time
    Array.Sort(items, (a, b) => {
      if (a.priority == b.priority)
        return a.ch-b.ch;
      return b.priority - a.priority;
    });
    int j = 0;
    foreach (var it in items)
      for (int i = 0; i < it.priority; i++)
        chars[j++] = it.ch;
    return new String(chars);
  }
}
