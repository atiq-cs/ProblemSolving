/***************************************************************************
* Title : Sort Characters By Frequency
* URL   : https://leetcode.com/problems/sort-characters-by-frequency
* Date  : 2018-06-07
* Author: Atiq Rahman
* Comp  : O(n), O(N)
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
* meta  : tag-sort, tag-leetcode-easy, tag-lambda-expr, tag-hash-table,
*   tag-company-amazon, tag-coding-test
***************************************************************************/

// Borrowed and modified from 'demos/algo/sort/CountingSort.cs'
class Item {
  public int priority { get; set; }   // or can be named 'key'
  public char ch { get; set; }
  public Item(int n, char ch) { priority = n; this.ch = ch; }
}

public class Solution {
  // O(n lg n), O(1) unless sorting function requires something
  public string FrequencySort(string s) {
    int[] freq = new int['z'-' '+1];
    char[] chars = s.ToArray();
    foreach ( char ch in chars)
      freq[ch-' ']++;
    Array.Sort(chars, (a, b) => {
      if (freq[a-' '] == freq[b-' '])
        return a-b;
      return freq[b-' '] - freq[a-' '];
    });
    return new String(chars);
  }

  // O(N), O(N)
  public string FrequencySort(string s) {
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
