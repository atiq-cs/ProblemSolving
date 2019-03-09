/***************************************************************************************************
* Title : Implement Trie (Prefix Tree)
* URL   : https://leetcode.com/problems/implement-trie-prefix-tree/
* Date  : 2019-03-03
* Comp  : check Trie ds core
* Status: Accepted
* Notes : Implementation's in 'ds/Trie.java', other than the core part (related to this prob) is
*   here
* ref   : ds/Trie.java
* rel   : https://leetcode.com/tag/trie/
* meta  : tag-ds-tree, tag-ds-string, tag-leetcode-medium
***************************************************************************************************/
class Trie {
  /** Initialize your data structure here. */
  // ...

  /** Inserts a word into the trie. */
  public void insert(String word) {
    put(root, word);
  }

  /** Returns if the word is in the trie. */
  public boolean search(String word) {
    return get(word) != null;
  }

  /** Returns if there is any word in the trie that starts with the given prefix. */
  public boolean getPrefix(Node node, String word) {
    if (word.isEmpty())
      return true;
    if (node.next.containsKey(word.charAt(0)) == false)
      return false;
    return getPrefix(node.next.get(word.charAt(0)), word.substring(1));
  }

  public boolean startsWith(String prefix) {
    return getPrefix(root, prefix);
  }
}
