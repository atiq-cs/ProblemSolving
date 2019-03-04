/***************************************************************************************************
 * Title : TRIE/ Radix Tree
 * URL   : Algorithms (4th Ed), Robert Sedgewick p#737, p#738
 * Date  : 2019-03-03
 * Comp  : look up O(L) where l is length of string
 * Notes : get and put are verified by leetcode prob..
 *   ToDo keysWithPrefix
 * rel   :  https://leetcode.com/problems/implement-trie-prefix-tree
 * meta  : tag-ds-trie, tag-ds-core
***************************************************************************************************/
import java.util.HashMap;

public class Trie {
  Node root;

  public Trie() {
    root = new Node(new HashMap<Character, Node>());
  }

  class Node {
    boolean isWord;
    HashMap<Character, Node> next;

    public Node(boolean isWord, HashMap<Character, Node> next) {
      this.isWord = isWord;
      this.next = next;
    }

    public Node(HashMap<Character, Node> next) {
      this.isWord = false;
      this.next = next;
    }
  }

  /// Algorithms (4th Ed) p#737
  public void put(String word) {
    if (word.isEmpty())
      return ;
    put(root, word);
  }

  public void put(Node node, String word) {
    if (word.isEmpty()) {
      node.isWord = true;
      return ;
    }

    if (node.next.containsKey(word.charAt(0)) == false)
      node.next.put(word.charAt(0), new Node(new HashMap<Character, Node>()));
    put(node.next.get(word.charAt(0)), word.substring(1));
  }

  public Node get(String word) {
    if (word.isEmpty())
      return root;
    return get(root, word);
  }

  public Node get(Node node, String word) {
    if (word.isEmpty())
      return node.isWord? node : null;
    if (node.next.containsKey(word.charAt(0)) == false)
      return null;
    return get(node.next.get(word.charAt(0)), word.substring(1));
  }

  // Driver method for demo
  public void Run() {
    // can be simplified using a loop
    System.out.println("Trie: initial implementation");
    var inStr = "";
    System.out.println("Found " + inStr + ": " + search(inStr));
    inStr = "abc";
    System.out.println("Inserting " + inStr);
    put(inStr);
    System.out.println("Inserting " + inStr);
    put(inStr);
    inStr = "a";
    System.out.println("Inserting " + inStr);
    put(inStr);
    inStr = "ab";
    System.out.println("Inserting " + inStr);
    put(inStr);

    var stringList = new String[] { "abc", "ab", "a", "abcd", "abcdef", "c", "b"};
    for(var str: stringList)
      System.out.println("Found string " + str + ": " + search(str));

    stringList = new String[] { "abc", "a", "ab", "b"};
    for(var str: stringList)
      System.out.println("Found prefix " + str + ": " + startsWith(str));
  }

  // Driver main method
  public static void main(String[] args) {
    new Trie().Run();
  }
}
