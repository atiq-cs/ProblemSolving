/***************************************************************************************************
* Title : Unique Email Addresses
* URL   : https://leetcode.com/problems/unique-email-addresses/
* Date  : 2019-03-14
* Comp  : O(N*m), O(N) N is size of emails array and m is length of string
* Status: Accepted
* Notes : Build an automator to extract the final email string ignoring . and chars after + but
*   before @. Then push it to HashSet
* meta  : tag-automaton, tag-ds-hashtable, tag-leetcode-easy
***************************************************************************************************/
class Solution {
  public int numUniqueEmails(String[] emails) {
    HashSet<String> recips = new HashSet<String>();
    
    for (String email: emails) {
      boolean plusFound = false;
      boolean atSignFound = false;
      StringBuilder sb = new StringBuilder();

      for (int i=0; i<email.length(); i++) {
        char ch = email.charAt(i);
        
        switch (ch) {
          case '.':
            if (atSignFound)
              sb.append(ch);
            break;
          case '+':
            plusFound = true;
            break;
          case '@':
            atSignFound = true;
            sb.append(ch);
            break;
          default:
            if (!plusFound || atSignFound)
              sb.append(ch);
            break;            
        }
      }
      recips.add(sb.toString());
    }
    
    return recips.size();
  }
}
