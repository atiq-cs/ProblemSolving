/*
    Problem Link :  https://uva.onlinejudge.org/external/119/p11988.pdf
    Problem Name :  Broken Keyboard (a.k.a. Beiju Text)
    Algorithm    :  Linked List
    Notes        :  I was thinking with C++ IO being slow I won't be able to get this problem accepted
                    In the end, with improved approach had been able to get it accepted

                    I thought of implementing own list. Then I changed mind as the list is already implemented
                    in C++ STL

    Complexity   :  O(n)
    Status       :  Accepted
*/


#include <iostream>
#include <algorithm>
#include <string>
#include <list>
#include <vector>

// Comment before submission to judge
#define FILE_IO	TRUE

#ifdef FILE_IO
#include <fstream>
#endif

enum Button {HOME, END};

typedef struct BUTTON_PRESS {
    int position;
    Button type;
} BUTTON_PRESS;

void handleIO();

/*  search for Home button or End button and list their indices
    We only have two types of buttonp presses, so better preprocess
*/
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

int main() {
    handleIO();
    return 0;
}

void handleIO() {
#ifdef FILE_IO
    std::string problem = "11988";
    std::ifstream inFile(problem + "_in.txt");
    std::streambuf *cinbuf = std::cin.rdbuf(); //save old buf
    std::cin.rdbuf(inFile.rdbuf()); //redirect std::cin to inFile!

    std::ofstream outFile(problem + "_out.txt");
    std::streambuf *coutbuf = std::cout.rdbuf();
    std::cout.rdbuf(outFile.rdbuf());
#endif

    // read till EOF
    std::string line;
    while (std::getline(std::cin, line)) {
        std::cout<<translate_string(line)<<std::endl;
    }

#ifdef FILE_IO
    std::cin.rdbuf(cinbuf);
    inFile.close();
    std::cout.rdbuf(coutbuf);
    outFile.close();
#endif
}
