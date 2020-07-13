/***************************************************************************
* Title : Find optimized flight strategy
* URL   : Amazon Autometa Kindle Author/Editing SDE2 amcat
* Date  : 2019-01-09
* Author: Atiq Rahman
* Comp  : O(m*n)
* Status: Wrong Answer
* Notes : Desc from careercup link,
*   Given max. travel distance and forward and backward route list, return pair
*   of ids of forward and backward routes that optimally utilized the max travel
*   distance.
*   In my words,
*   Given maximum travel distance and list of forward routes and return
*   routes find pairs of routes that optimizes the utilization of provided travel
*   distance
*
*   Please note that this solution is a wrong answer
*   
*   A binary search would be better solution, which would be as costly as
*    O( m lg n ) + O (m lg m) + O (n lg n)
*    
*    
*
* meta  : tag-charp-lambda-exp, tag-algo-sort, tag-company-amazon
***************************************************************************/
using System.Collections.Generic;

// Amazon's default documentation style, example at 'amcat_demo1.cs'
class Solution {
  // Complete this method
  public List<List<int>> optimalUtilization(int maxTravelDist,
                                        List<List<int>> forwardRouteList,
                                        List<List<int>> returnRouteList) {
    var filteredResult = new List<List<int>>();
    for (int i = 0; i < forwardRouteList.Count; i++) {
      int max = -1;
      for (int j = 0; j < returnRouteList.Count; j++) {
        int distance = forwardRouteList[i][1] + forwardRouteList[j][1];
        if (distance <= maxTravelDist) {
          if (distance > max) {
            max = distance;
            filteredResult.Add(new List<int>(new int[] { forwardRouteList[i][0], returnRouteList[j][0], distance }));
          }
          else if (distance == max)
            filteredResult.Add(new List<int>(new int[] { forwardRouteList[i][0], returnRouteList[j][0], distance }));
        }
      }
    }

    // sort in descending order of distance
    filteredResult.Sort((a, b) => {
      return b[2] - a[2];
    });

    var result = new List<List<int>>();
    result.Add(new List<int>(new int[] { filteredResult[0][0], filteredResult[0][1] }));

    for (int i = 1; i < filteredResult.Count; i++)
      if (filteredResult[i][2] == filteredResult[i - 1][2])
        result.Add(new List<int>(new int[] { filteredResult[i][0], filteredResult[i][1] }));
    return result;
  }
}

/*
Example,
Input:
10000
[{1, 6000}, {2, 2000}, {3, 3000}]
[{1, 6000}, {2, 2000}, {3, 3000}]

Output: (1,3), (3,1)
since both of these pairs make total distance 9000

However, if input was 
Input:
10000
[{1, 6000}, {2, 4000}, {3, 3000}]
[{1, 6000}, {2, 4000}, {3, 3000}]

Output would be, (1,2), (2,1)

eg: max travel distance is : 11000 
forward route list : [1,3000],[2,5000],[3,4000],[4,10000] 
backward route list : [1,2000],[2,3000],[3,4000] 

ref: https://www.careercup.com/question?id=5750442676453376
Result : [2,3] ...2 is from forward and 3 is from backward.. total distance is 9000... no other
combination is there which is >9000 and <=11,000.......0(n^2) solution is straight forward,
thinking that sorting both might help.
*/
