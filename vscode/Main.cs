/***************************************************************************
* Title : Prob Name
* URL   : https://codeforces.com/xxx
* Occasn: Contest name or an event
* Date  : 2018-mm-dd
* Author: Atiq Rahman
* Comp  : O(X)
* Status: W/A/CE
* Notes : desc
* Ref   :
* meta  : tag-
***************************************************************************/
using System;
using System.Collections.Generic;

public class ProbDemo {
  int n;

  public void Run() {
    n = int.Parse(Console.ReadLine());
    string str = Console.ReadLine();
    Console.WriteLine(GetResult() + str);
  }

  private string GetResult() {
    // do compute
    return "echoed ";
  }
}

class CFSolution {
  static void Main(String[] args) {
    ProbDemo demo = new ProbDemo();
    demo.Run();
  }
}
