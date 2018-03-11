/***************************************************************************
* Prob#2: Sorting Log File
* URL   :
* Date  : 2018-03-10
* Author: Atiq Rahman
* Comp  : O(n lg n)
* Status: Accepted
* Notes : This problem asks to sort strings (lines) provided a set of
*   preferences,
*    compare the value (words) in a case insensitive way
*    if there are numbers instead of letters those go later
*    if two values are same then compare identifiers
*
*   Compared to C++, there's no clever/oneliner lambda syntax for comparing
* meta  : tag-hash-table, tag-sorting, tag-amazon
***************************************************************************/
using System;
using System.Collections.Generic;

class LogLine {
  public string id;
  public string words;
  public LogLine(string id, string words) {
    this.id = id;
    this.words = words;
  }
}

class LineComparer : IComparer<LogLine> {
  public int Compare(LogLine x, LogLine y) {
    string id1 = x.id;
    string id2 = y.id;
    
    string val1 = x.words.ToLower();
    string val2 = y.words.ToLower();
    
    if (val1 == val2)
      return id1.CompareTo(id2);
    else if (char.IsDigit(val1[0]) && char.IsLetter(val2[0]))
      return 1;
    // if second one is digit
    // then if first one is digit then order
    else if (char.IsLetter(val1[0]) && char.IsDigit(val2[0]))
      return -1;
    // then if first one is digit then stable sort
    else if (char.IsDigit(val1[0]) && char.IsDigit(val2[0]))
      return 0;

    return val1.CompareTo(val2);
  }
}

public class Solution {
  public List<string> reorderLines(int logFileSize, string[] logfile) {
    LogLine[] lines = ParseData(logfile);
    Array.Sort(lines, new LineComparer());
    return ConvertLinesToString(lines);
  }
  
  private LogLine[] ParseData(string[] logfile) {
    LogLine[] lines = new LogLine[logfile.Length];
    for (int i=0; i<logfile.Length; i++)
      lines[i] = ParseLine(logfile[i]);
    return lines;
  }
  
  private LogLine ParseLine(string str) {
    string[] tokens = str.Split(new char[] { ' ' }, 2);
    return new LogLine(tokens[0], tokens[1]);
  }
  
  private List<string> ConvertLinesToString(LogLine[] lines) {
    List<string> result = new List<string>();
    foreach( LogLine line in lines )
       result.Add(line.id + " " + line.words);
    return result;
  }
}

/*
Example Input,
aq2 ady meny si
fg5 4 7 9 2
mi4 Act zoo
c6 1 55 7 3
ci5 Act zoo

Here, aq2 is identifier, 'ady meny si' is the string or words

Output:
ci5 Act zoo
mi4 Act zoo
aq2 ady meny si
fg5 4 7 9 2
c6 1 55 7 3
*/
