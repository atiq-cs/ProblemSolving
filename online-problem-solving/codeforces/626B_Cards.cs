/***************************************************************************
* Title : Cards
* URL   : https://codeforces.com/problemset/problem/626/B
* Occasn: 8VC Venture Cup 2016 - Elimination Round
* Date  : 2018-09-30
* Author: Atiq Rahman
* Comp  : O(N)
* Status: Accepted
* Notes : Points to summarize,
*   Max 3 colors can be final result
*   1. What would produce all colors
*   - Having cards of all colors
*   - Having 2 colors (both of them more than 1)
*   2. What would produce 2 colors
*   - Having 1 color card more than once and other one just once; challenge: which colors
*   3. What would produce single color?
*   - Having 2 cards - one color each of them
*   - Having single 1 color card (regardless of frequency)
*   
*   Complexity: after computing frequencies finds the final color in constant
*   time.
*   
*   Alternative solution is DP, probably O(N^3)
*   
* meta  : tag-medium, tag-algo-greedy, tag-algo-dp
***************************************************************************/
using System;
using System.Collections.Generic;

// codeforces judge also sets first element to 0 by default
enum COLOR { Red, Green, Blue }

// SortedList and SortedDictionary does not facilitate sorting based on values
// Both of them make it hard to add entries with duplicate values
class Card {
  public COLOR Color { get; set; }
  public int Count { get; private set; }

  public Card(COLOR c, int count) {
    this.Color = c;
    this.Count = count;
  }

  public void IncrementCount() {
    Count++;
  }

  public string GetColor() {
    switch (Color) {
    case COLOR.Red:
      return "R";
    case COLOR.Green:
      return "G";
    case COLOR.Blue:
      return "B";
    default:
      return "";
    }
  }
}

public class CardsDemo {
  int n;
  Card[] cards = new Card[3];

  private void GetFrequencies(string str) {
    cards[(int) COLOR.Red] = new Card(COLOR.Red, 0);
    cards[(int) COLOR.Green] = new Card(COLOR.Green, 0);
    cards[(int) COLOR.Blue] = new Card(COLOR.Blue, 0);

    foreach (var ch in str) {
      switch (ch) {
      case 'R':
        cards[(int) COLOR.Red].IncrementCount();
        break;
      case 'G':
        cards[(int) COLOR.Green].IncrementCount();
        break;
      case 'B':
        cards[(int) COLOR.Blue].IncrementCount();
        break;
      default:
        break;
      }
    }
    Array.Sort(cards, (Card a, Card b) => {
      return a.Count - b.Count;
    });
  }

  public void Run() {
    n = int.Parse(Console.ReadLine());
    string cardsStr = Console.ReadLine();
    GetFrequencies(cardsStr);
    Console.WriteLine(GetFinalColors());
  }

  private string GetAlternateColor(COLOR a, COLOR b) {
    if ((a == COLOR.Red && b == COLOR.Green) || (b == COLOR.Red && a == COLOR.Green))
      return "B";
    if ((a == COLOR.Green && b == COLOR.Blue) || (b == COLOR.Green && a == COLOR.Blue))
      return "R";
    if ((a == COLOR.Red && b == COLOR.Blue) || (b == COLOR.Red && a == COLOR.Blue))
      return "G";
    return "";
  }

  private string GetFinalColors() {
    // All color card with count >= 1
    if (cards[0].Count >= 1 && cards[1].Count >= 1 && cards[2].Count >= 1)
      return "BGR";
    // any 2 color cards both more than once
    if ((cards[1].Count > 1 && cards[2].Count > 1) ||
      (cards[0].Count > 1 && cards[2].Count > 1) ||
      (cards[0].Count > 1 && cards[1].Count > 1))
      return "BGR";

    if (cards[2].Count > 1 && cards[1].Count == 1) {
      string a = cards[1].GetColor();
      string b = GetAlternateColor(cards[1].Color, cards[2].Color);
      return a[0] > b[0] ? b + a : a + b;
    }
    if (cards[2].Count == 1 && cards[1].Count == 1)
      return GetAlternateColor(cards[1].Color, cards[2].Color);
    if (cards[2].Count >= 1)
      return cards[2].GetColor();
    return "";
  }
}

class CFSolution {
  static void Main(String[] args) {
    CardsDemo Demo = new CardsDemo();
    Demo.Run();
  }
}
