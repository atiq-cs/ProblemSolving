/***************************************************************************************************
* Title : Precedence of Logical Operators: And and OR
* URL   : https://docs.microsoft.com/en-us/cpp/c-language/precedence-and-order-of-evaluation
* Occasn: Demo Lang Feature
* Date  : 2019-01
* Comp  : 
* Status: 
* Notes : Because && has higher precedence than ||, operands around && are automatically as if
*   wrapped around by parenthesis. For example,
*    a && b || c is equivalent to, (a && b) || c
*    a || b && c is equivalent to, a || (b && c)
*    
*   it's like && is auto surrounded by parenth && is auto precided.. We don't need to wrap them
*   explicitly with parenthesis.
*    
*   Output of the program is at bottom.
* ref   : https://docs.microsoft.com/en-us/cpp/cpp/cpp-built-in-operators-precedence-and-associativity
* meta  : tag-lang-core
***************************************************************************************************/
using System;

public class LogicalOpPrecedence {
  int[] A;
  int k;
  int n;

  private void EvalExp(byte choice) {
    bool r = false;   // result of logical expression
    bool a, b, c;

    for (byte i = 0; i < 0x8; i++) {
      a = ((i & 0x4) != 0);
      b = ((i & 0x2) != 0);
      c = ((i & 0x1) != 0);
      var exp = "";

      switch (choice) {
      case 1:
        r = (a || b || c);
        exp = "a || b || c";
        break;
      case 2:
        r = a && b || c;
        exp = "a && b || c";
        break;
      case 3:
        r = a || b && c;
        exp = "a || b && c";
        break;
      case 4:
        r = a && b && c;
        exp = "a && b && c";
        break;
      default:
        break;
      }
      Console.WriteLine("Exp: " + exp + " vals: " + Convert.ToString(i, 2).PadLeft(3, '0') + " result: " + r);
      // Format specifier more example: ..,3:G3
    }
  }

  public void Run() {
    for (byte i = 1; i <= 0x4; i++)
      EvalExp(i);
  }
}

public class LogicalOpsDemo {
  private static void Main() {
    LogicalOpPrecedence demo = new LogicalOpPrecedence();
    demo.Run();
  }
}

/*
Exp: a || b || c vals: 000 result: False
Exp: a || b || c vals: 001 result: True
Exp: a || b || c vals: 010 result: True
Exp: a || b || c vals: 011 result: True
Exp: a || b || c vals: 100 result: True
Exp: a || b || c vals: 101 result: True
Exp: a || b || c vals: 110 result: True
Exp: a || b || c vals: 111 result: True
Exp: a && b || c vals: 000 result: False
Exp: a && b || c vals: 001 result: True
Exp: a && b || c vals: 010 result: False
Exp: a && b || c vals: 011 result: True
Exp: a && b || c vals: 100 result: False
Exp: a && b || c vals: 101 result: True
Exp: a && b || c vals: 110 result: True
Exp: a && b || c vals: 111 result: True
Exp: a || b && c vals: 000 result: False
Exp: a || b && c vals: 001 result: False
Exp: a || b && c vals: 010 result: False
Exp: a || b && c vals: 011 result: True
Exp: a || b && c vals: 100 result: True
Exp: a || b && c vals: 101 result: True
Exp: a || b && c vals: 110 result: True
Exp: a || b && c vals: 111 result: True
Exp: a && b && c vals: 000 result: False
Exp: a && b && c vals: 001 result: False
Exp: a && b && c vals: 010 result: False
Exp: a && b && c vals: 011 result: False
Exp: a && b && c vals: 100 result: False
Exp: a && b && c vals: 101 result: False
Exp: a && b && c vals: 110 result: False
Exp: a && b && c vals: 111 result: True
*/
