/***************************************************************************************************
* Title : Sorting Log File (p#2)
* URL   : Amazon Autometa DeepLearning SDE2 amcat
* Date  : 2018-03-10
* Author: Atiq Rahman
* Comp  : O(n lg n + n*m) where n*m is for n number of comparisons among
*   strings; m being the max length of string
* Status: Tests passing: First version and second versions both passing 14/24
* Notes : This problem asks to sort strings (lines) provided a set of
*   preferences,
*   compare the value (words) in a case insensitive way
*   if there are numbers instead of letters those go later
*   if two values are same then compare identifiers
*
*   Should try the lambda syntax for comparing to replace IComparer
* meta  : tag-hash-table, tag-algo-sort, tag-company-amazon
***************************************************************************************************/
using System;
using System.Collections.Generic;

// first version till line 86
class LogLine {
  public string id { get; set; }
  public string words { get; set; }
  // constructor
  public LogLine(string id, string words) {
    this.id = id;
    this.words = words;
  }
}

// Override comparer for sorting
class LineComparer : IComparer<LogLine> {
  public int Compare(LogLine x, LogLine y) {
    string id1 = x.id;
    string id2 = y.id;
    
    string val1 = x.words.ToLower();
    string val2 = y.words.ToLower();
    
    // handle tie
    if (val1 == val2)
      return id1.CompareTo(id2);
    // not equal
    // one of them are digits, first one digit
    else if (char.IsDigit(val1[0]) && char.IsLetter(val2[0]))
      return 1;
    // if second one is digit
    // then if first one is digit then order
    else if (char.IsLetter(val1[0]) && char.IsDigit(val2[0]))
      return -1;
    // then if both of them are digits then stable sort
    else if (char.IsDigit(val1[0]) && char.IsDigit(val2[0]))
      return 0;
    // otherwise lexicographically sort
    return val1.CompareTo(val2);
  }
}

public class SolutionV1 {
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
    string[] tokens = str.Split(new char[] {' '}, 2);
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
// second version
using System.Text;    // CleanDelimBetweenWords uses StringBuilder

// Property originalWords is added
class LogLine {
  public string id { get; set; }
  public string words { get; set; }
  public string originalWords { get; set; }
  // constructor
  public LogLine(string id, string words, string orig) {
    this.id = id;
    this.words = words;
    this.originalWords = orig;
  }
}

public class SolutionV2 {
  /// <summary>
  /// method ParseLine handles additional spaces in the beginning and in the
  /// end of the string
  /// </summary>
  /// <param name="str">
  /// a line in the log file
  /// </param>
  /// <returns>
  /// returns a LogLine object created from the provided string
  /// </returns>
  private LogLine ParseLine(string str) {
    str = str.TrimStart(' ').TrimEnd(' ');
    string[] tokens = str.Split(new char[] { ' ' }, 2);
    string cleanWords = CleanDelimBetweenWords(tokens[1]);
    return new LogLine(tokens[0], cleanWords, tokens[1]);
  }

  /// <summary>
  /// Second version implements CleanDelimBetweenWords which is called in ParseLine 
  /// Removes additional space delimeters inside words
  /// </summary>
  /// <param name="words">
  /// input line as string
  /// </param>
  /// <returns>
  /// returns trimmed version of the string
  /// </returns>
  private string CleanDelimBetweenWords(string words) {
    char pre_ch = ' ';
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < words.Length; i++) {
      char ch = words[i];
      if (pre_ch == ' ' && ch == pre_ch)
        continue;
      sb.Append(ch);
      pre_ch = ch;
    }
    if (pre_ch == ' ')
      sb.Length--;
    return sb.ToString();
  }
}
