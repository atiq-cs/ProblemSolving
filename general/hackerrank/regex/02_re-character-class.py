"""***************************************************************************
* Title : Regular Expression Character Class Challenges
* URL   : https://www.hackerrank.com/domains/regex/re-character-class
* Date  : 2018
* Author: Atiq Rahman
* Comp  : N/A
* Status: Accepted
* Notes : Character Matching based regex problems
*   These problems do not support C#
* meta  : tag-regex
***************************************************************************"""
# Problem #1: Matching Specific Characters
# Date      : Mar, 2018
Regex_Pattern = r'^[1-3][0-2](x|s|0)(0|3|a|A)(s|x|u)(\.|,)$'
# template code
import re
print(str(bool(re.search(Regex_Pattern, input()))).lower())

# Problem #2: Excluding Specific Characters
# Date      : 04-07-2018
# template  : code for template is same as previous
Regex_Pattern = r'^\D[^aeiou][^bcDF]\S[^AEIOU][^\.,]$'

# Problem #3: Matching Character Ranges
# Date      : 04-07-2018
# template  : code for template is same as previous
Regex_Pattern = r'^[a-z][1-9][^a-z][^A-Z][A-Z].*'
