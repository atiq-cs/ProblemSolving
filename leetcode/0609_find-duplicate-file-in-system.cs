/***************************************************************************
* Title : Find Duplicate File in System
* URL   : https://leetcode.com/problems/find-duplicate-file-in-system
* Date  : 2017-12-13
* Author: Atiq Rahman
* Comp  : O(n^m * (length(file content) + length(file name)) )
* Status: Accepted
* Notes : Pretty much a hashtable problem. This file contains the leetcode
*   solution. For the Visual Studio driver program along with a sample large
*   input please have a look at '609_find-duplicate-file-in-system_demo_vs.cs'
* meta  : tag-ds-hashtable, tag-string
***************************************************************************/
using System;
using System.Collections.Generic;
// using System.Linq;

public class Solution {
  public IList<IList<string>> FindDuplicate(string[] paths) {
    Dictionary<string, IList<string>> fileDict = new Dictionary<string, IList<string>>();
    char[] delim = new char[] {'(', ')'};
    
    foreach( string fileListString in paths ) {
      // split for each file
      string[] files = fileListString.Split();
      string dir = files[0];
      
      for (int i=1; i<files.Length; i++) {
        string fileString = files[i];
        string[] tokens = fileString.Split(delim);
        string key = tokens[1];
        string val = dir + '/' + tokens[0];

        if (fileDict.ContainsKey(key)) {
          IList<string> pathList = fileDict[key];
          pathList.Add(val);
        } else {
          List<string> pathList = new List<string>();
          pathList.Add(val);
          fileDict.Add(key, pathList);
        }
      }
    }

    /* This Linq statement works okay on Visual Studio. However, it throws
       Runtime Error on leetcode judge!
       ref: How to get dictionary values as a generic list
            https://stackoverflow.com/q/7555690

    return (IList<IList<string>>) fileDict.Values.ToList();
    */

    // So tried this, luckily somebody tried C# to solve this problem
    // https://discuss.leetcode.com/topic/91331/c-solution-with-dictionary
    IList<IList<string>> res = new List<IList<string>>();
    foreach(var kv in fileDict){
        if(kv.Value.Count>1){
            res.Add(kv.Value);
        }
    }
    return res;
  }
}
