/***************************************************************************
* Title : First problem of this vmware challenge
* URL   : https://www.hackerrank.com/tests/*
* Date  : 2015-09-19
* Comp  : O(n^2)
* Status: Testcases passed
* Notes : Is it about the subsequences or subsets? Are we only considering sets?
*   Coding template asks to complete the function
* rel   : https://leetcode.com/problems/subsets/
* meta  : tag-subsequence, tag-subset, tag-permutation, tag-recursion
***************************************************************************/
static string[] buildSubsets(string s) {
  string set = s;
  List<string> subsets = new List<string>();

  for (int i = 1; i < set.Length; i++) {
    subsets.Add(set[i - 1].ToString());
    List<string> newSubsets = new List<string>();

    for (int j = 0; j < subsets.Count; j++) {
      string newSubset = subsets[j] + set[i];
      newSubsets.Add(newSubset);
    }
    subsets.AddRange(newSubsets);
  }

  subsets.Add(set[set.Length - 1].ToString());
  subsets.Sort();
  return subsets.ToArray();
}

// example debug print of the result subset
// Console.WriteLine(string.Join(Environment.NewLine, subsets));