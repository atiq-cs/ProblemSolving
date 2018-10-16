/***************************************************************************
* Title : Sorting: Comparator
* URL   : https://www.hackerrank.com/challenges/ctci-comparator-sorting
* Date  : 2018-06
* Author: Atiq Rahman
* Comp  : O(n lg n) depends on partition size, ref:
*   https://msdn.microsoft.com/en-us/library/6tf1f0bc.aspx
* Status: Accepted
* Notes : Lang C# not available in this problem
* meta  : tag-algo-sort, tag-lambda-exp
***************************************************************************/
struct Player {
  string name;
  int score;
};

vector<Player> comparator(vector<Player> players) {
  sort(players.begin(), players.end(),
    [](const Player & a, const Player & b) -> bool {
    if (a.score == b.score)
      return a.name < b.name;
    return a.score > b.score;
  });
  return players;
}
