/***************************************************************************************************
* Title : Fibonacci Freeze
* URL   : 495
* Status: Accpeted
* Author: Atiq Rahman
* meta: tag-big-integer
***************************************************************************************************/
import java.util.Scanner;
import java.math.BigInteger;

class Main {
  public static void main (String args[]) {
    Scanner istream = new Scanner(System.in);
    BigInteger fibo[] = new BigInteger[5001];
    fibo[0] = new BigInteger("0");
    fibo[1] = new BigInteger("1");
    int i, n;
    
    for (i=2; i<5001; i++) {
      fibo[i] = new BigInteger("0");
      fibo[i] = fibo[i].add(fibo[i-2]);
      fibo[i] = fibo[i].add(fibo[i-1]);
    }
    while (istream.hasNextInt()) {
      n = istream.nextInt();
      System.out.println("The Fibonacci number for "+n+" is "+fibo[n]);
    }
  }
}
