/***************************************************************************
*   Problem Name:   First problem of this vmware challenge
*   Problem Link :  https://www.hackerrank.com/tests/*
*   Date        :   Sept 19, 2015
*
*   Algo, DS    :   Subsequence generation
*   Desc        :   Asked to complete the function
*
*   Complexity  :   O(n^2)
*   Author      :   Atiq Rahman
*   Status      :   Testcases passed
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
  // example debug print of the result subset
  // Console.WriteLine(string.Join(Environment.NewLine, subsets));
  return subsets.ToArray();
}
