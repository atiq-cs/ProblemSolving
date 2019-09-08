/***************************************************************************************************
* Title : Broken Keyboard (a.k.a. Beiju Text)
* URL   : https://uva.onlinejudge.org/external/119/p11988.pdf
* Status: Accepted
* Comp  : O(n) (0.343s)
* Notes : with C++ IO (cout/cin) being slow I thought I won't be able to get this problem accepted
*   However, with improved approach I had been able to get AC.
*
*   Utilizes C++ STL vector
*
* Algo - Dequeue
* meta  : tag-ds-linked-list
***************************************************************************************************/


#include <iostream>
#include <algorithm>
#include <string>
#include <list>
#include <vector>

enum Button { HOME, END };

typedef struct BUTTON_PRESS {
  int position;
  Button type;
} BUTTON_PRESS;

// Search for Home button or End button and list their indices
// We only have two types of buttonp presses, so better preprocess
std::vector<BUTTON_PRESS> preprocess_button_presses(std::string& str) {
  std::vector<BUTTON_PRESS> result_buttons;
  for (int i = 0; i < (int) str.length(); i++) {
    char ch = str[i];
    if (ch == '[' || ch == ']') {
      BUTTON_PRESS btn = {i, HOME};
      if (ch == ']') {
        btn.type = END;
      }
      result_buttons.push_back(btn);
    }
  }
  return result_buttons;
}

std::string translate_string(std::string str) {
  // in the beginning end button does not make sense
  // till we reach end of line
  std::list<std::string> str_list;
  std::vector<BUTTON_PRESS> button_press_list = preprocess_button_presses(str);
  Button previous_button = END;
  size_t current_found_position = str.length();
  size_t previous_found_position = -1;
  std::string segment;

  for (int i = 0; i< (int) button_press_list.size(); i++) {
    Button current_button = button_press_list[i].type;
    current_found_position = button_press_list[i].position;

    if (current_found_position - previous_found_position - 1 > 0) {
      segment = str.substr(previous_found_position + 1, current_found_position - previous_found_position - 1);
      if (previous_button == HOME)
        str_list.push_front(segment);

      else
        str_list.push_back(segment);
    }

    previous_button = current_button;
    previous_found_position = current_found_position;
  }
  segment = str.substr(previous_found_position + 1, current_found_position - previous_found_position - 1);
  if (previous_button == HOME)
    str_list.push_front(segment);
  else
    str_list.push_back(segment);

  std::string result;
  for (auto item : str_list)
    result += item;

  return result;
}

void handleIO() {
  // read till EOF
  std::string line;
  while (std::getline(std::cin, line))
    std::cout<<translate_string(line)<<std::endl;
}

int main() {
  handleIO();
  return 0;
}
