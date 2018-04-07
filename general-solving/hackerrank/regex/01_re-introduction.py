"""***************************************************************************
* Title : Regular Expression Introduction Challenges
* URL   : https://www.hackerrank.com/domains/regex/re-introduction
* Date  : 2017 & 2018
* Author: Atiq Rahman
* Comp  : N/A
* Status: Accepted
* Notes : Some easy regular expression problems
*   Solved in python because hackerrank does not seem to have C#
* meta  : tag-regex
***************************************************************************"""
# Problem #1: Matching Specific String
# Date      : 2017
Regex_Pattern = r'hackerrank'
# template code
import re
Test_String = input()
match = re.findall(Regex_Pattern, Test_String)
print("Number of matches :", len(match))

# Problem #2: Matching Anything But a Newline
# Date      : 2017
Regex_Pattern = r"^...\....\....\....$"
# template code
import re
import sys
test_string = input()
match = re.match(regex_pattern, test_string) is not None
print(str(match).lower())

# Problem #3: Matching Digits & Non-Digit Characters
# Date      : Dec, 2017
Regex_Pattern = r"\d\d\D\d\d\D\d\d\d\d"
# template code
import re
print(str(bool(re.search(Regex_Pattern, input()))).lower())

# Problem #4: Matching Whitespace & Non-Whitespace Character
# Date      : Dec, 2017
# template  : code for template is same as previous
Regex_Pattern = r"\S\S\s\S\S\s\S\S"

# Problem #5: Matching Word & Non-Word Character
# Date      : Dec, 2017
# Input length: 3 1 10 1 3
# template  : code for template is same as previous
Regex_Pattern = r"\w\w\w\W\w\w\w\w\w\w\w\w\w\w\W\w\w\w"

# Problem #6: Matching Start & End
# Date      : Mar, 2018
# template  : code for template is same as previous
Regex_Pattern = r"^\d\w\w\w\w\.$"
