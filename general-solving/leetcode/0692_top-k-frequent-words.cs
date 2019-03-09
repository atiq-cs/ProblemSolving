/***************************************************************************
* Title : Top K Frequent Words
* URL   : https://leetcode.com/problems/top-k-frequent-words
* Date  : 2018-03-10
* Author: Atiq Rahman
* Comp  : O(n lg n), O(n)
* Status: Accepted
* Notes : Linq query is to do the n lg n sorting
*   If we solve this without using LINQ one way to do it would be to implement
*   a comparator to do sorting considering following cases,
*   - sort in descending order of frequency of words
*   - when there is a tie for frequency sort lexicographically
*
*   Amazon's coding test version of this problem asks to implement similar
*   sorting however required comparison is case insensitive. It also asks to
*   exclude words from a given list.
*   
*   For java probably use Priority Queue to get n lg k
*   ref: 'general-solving/coding-tests/Amazon Autometa_DeepLearning_SDE2_1.cs'
* meta  : tag-ds-hash-table, tag-chsarp-linq, tag-algo-sort
***************************************************************************/
public class LeetcodeSolution {
  public IList<string> TopKFrequent(string[] words, int k) {
    Dictionary<string, int> wordDict = new Dictionary<string, int>();
    // O(N) time and O(N) space - to build and store dictionary
    foreach ( string word in words )
      wordDict[word] = (wordDict.ContainsKey(word) ? wordDict[word] : 0) + 1;

    // Dictionary to string Array; Array is Enumerable (can be returned as
    // IList)
    // We are ordering by,
    //  Value(frequency): int as decending
    //  key: string as ascending
    // syntax is like this because we could not put them together like a cross
    // join syntax i.e.,
    //  'orderby entry.Key, entry.Value'
    return (from entry in wordDict orderby entry.Key ascending orderby entry.
            Value descending select entry.Key).Take(k).ToArray();
  }
}
