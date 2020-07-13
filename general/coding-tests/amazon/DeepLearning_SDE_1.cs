/***************************************************************************
* Title : Find Most Frequent Words
* URL   : Amazon Autometa DeepLearning SDE2 amcat
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
*   Required comparison for sort is case insensitive. It also asks to exclude
*   words from a given list
* ref   : 'leetcode/0692_top-k-frequent-words.cs'
* meta  : tag-hash-table, tag-charp-linq, tag-algo-sort, tag-company-amazon
***************************************************************************/
public class AmazonSolution
{
  public IList<string> MostFrequent(string line, string[] excludeWords) {
    // Build a hash set using excluded word list
    // Parse string line.
    // For each token found by parsing line and build a hash table to record
    // frequency of each word.
    //  check if the token is in excluded list
    //  if not then increment frequency of the word in the hashtable

    // Iterate through the hash table and output most frequently used words
    //  implement a comparator so that case insensitive comparison is done
    //  when there are ties in frequency
  }
}

/*
Example,
Sentence: Jill and cheese's kids went to the shop. They bought some adam's cheese.
Excelude: "Jill", "and", "to", "the" etc..

Output: "Cheese", "s"
Order does not matter.
*/
