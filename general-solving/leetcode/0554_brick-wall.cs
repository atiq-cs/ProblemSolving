/***************************************************************************************************
* Title : Brick Wall
* URL   : https://leetcode.com/problems/brick-wall
* Date  : 2018-03
* Author: Atiq Rahman
* Comp  : O(N*M)
* Status: Accepted
* Notes : 
* meta  : tag-hash-table, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  public int LeastBricks(IList<IList<int>> wall) {
    Dictionary<int, int> brickDict = new Dictionary<int, int>();
    foreach (IList<int> Bricks in wall) {
      int sum = 0;
      for (int i = 0; i < Bricks.Count - 1; i++) {
        sum += Bricks[i];
        if (brickDict.ContainsKey(sum))
          brickDict[sum]++;
        else
          brickDict.Add(sum, 1);
      }
    }
    int max = 0;
    foreach (KeyValuePair<int, int> Entry in brickDict)
      if (max < Entry.Value)
        max = Entry.Value;
    return wall.Count - max;
  }
}
