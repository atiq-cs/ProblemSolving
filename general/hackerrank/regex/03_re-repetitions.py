"""***************************************************************************
* Title : Regular Expression Repetitions Challenges
* URL   : https://www.hackerrank.com/domains/regex/re-repetitions
* Date  : 2018
* Author: Atiq Rahman
* Comp  : N/A
* Status: Accepted
* Notes : Nothing new, I knew about * or + before from autometa class
* meta  : tag-regex
***************************************************************************"""
# Problem #1: Matching {x} Repetitions
# Date      : Mar, 2018
Regex_Pattern = r'^[a-zA-Z02468]{40}[13579\s]{5}$'
# template code
import re
print(str(bool(re.search(Regex_Pattern, input()))).lower())

# Problem #2: Matching {x, y} Repetitions
# Date      : 04-07-2018
# Skill     : \w which is for word char is not only uppercase, lowercase
#   letters but more i.e., numeric digits are also included (check ref)
# template  : code for template is same as previous
# ref       : https://stackoverflow.com/q/2998519
Regex_Pattern = r'^\d{1,2}[a-zA-Z]{3,}\.{0,3}$'

# Problem #3: Matching Zero Or More Repetitions
# Date      : Mar, 2018
# template  : code for template is same as previous
Regex_Pattern = r'^\d\d+[a-z]*[A-Z]*$'

# Problem #4: Matching One Or More Repetitions
# Date      : 04-07-2018
# template  : same as previous
Regex_Pattern = r'^\d\d+[a-z]*[A-Z]*$'

# Problem #5: Matching Ending Items
# Date      : 04-07-2018
# template  : same as previous
Regex_Pattern = r'^[a-zA-Z]*s$'
