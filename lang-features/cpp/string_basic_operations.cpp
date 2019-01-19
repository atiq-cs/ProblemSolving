/*
Demonstration of basic string operations
    length, reverse, concatenation
    at, front, back, empty

    insert, erase
    push_back, pop_back
    append/ +
    compare
    <, lexicographical comparison
    replace
    substr
    copy
    swap

    find, rfind etc
*/


#include <iostream>
#include <sstream>
#include <algorithm>
#include <string>
#include <vector>

int main() {
    std::string str;

    str = "hello";
    str += " world!";
    std::cout << "String is: " << str << std::endl;

    //====================================================================================================================//
    //                    string length example
    //====================================================================================================================//
    std::cout << "Length of the string is: " << str.length() << std::endl;

    //====================================================================================================================//
    //                    string reverse example
    //====================================================================================================================//
    // using algorithm header, ref: http://stackoverflow.com/questions/198199/how-do-you-reverse-a-string-in-place-in-c-or-c
    std::reverse(str.begin(), str.end());
    std::cout << "Reveresed string is: " << str << std::endl;

    std::reverse(str.begin(), str.end());
    str = "Hi people, " + str;
    std::cout << "Modified string is: " << str << std::endl;

    //====================================================================================================================//
    //                    example: replacing all occurrences of a character
    //====================================================================================================================//
    // all occurrences replace example, ref:
    // http://stackoverflow.com/questions/2896600/how-to-replace-all-occurrences-of-a-character-in-string
    std::replace(str.begin(), str.end(), ' ', ','); // replace all ' ' to ','
    std::cout << "String is (' ' replaced with ','): " << str << std::endl;

    //====================================================================================================================//
    //                    string tokenization example with loop
    //====================================================================================================================//
    // string tokenization example using ssstream begins
    std::string token; // Have a buffer string
    std::stringstream ss(str); // Insert the string into a stream

    // std::vector<std::string> tokens; // Create vector to hold our words
    std::cout << std::endl << "Tokenizing the string using loop" << std::endl;
    /* use this to tokenize string that is delimited by space
    while (ss >> token)
    std::cout << "token found: " << token << std::endl;*/

    // delimeter is comma
    while (std::getline(ss, token, ','))
        // std::cout << token << '\n';
        std::cout << "token found: " << token << std::endl;

    //====================================================================================================================//
    //                    string tokenization example without loop
    //====================================================================================================================//
    // there are many ways, ref: http://stackoverflow.com/questions/236129/split-a-string-in-c

    std::cout << std::endl << "Tokenizing the string wihtout loop" << std::endl;
    std::string sentence = "And I feel fine...";
    std::istringstream iss(sentence);
    std::copy(std::istream_iterator<std::string>(iss),
        std::istream_iterator<std::string>(),
        std::ostream_iterator<std::string>(std::cout, "\n"));        // this does not support std::endl

    str = "The quick brown fox";
    // construct a stream from the string
    std::stringstream strstr(str);

    //====================================================================================================================//
    //                    string tokenization example without loop using vector
    //====================================================================================================================//
    std::cout << std::endl << "Tokenizing the string wihtout loop using vector" << std::endl;

    // use stream iterators to copy the stream to the vector as whitespace separated strings
    std::istream_iterator<std::string> it(strstr);
    std::istream_iterator<std::string> end;
    std::vector<std::string> results(it, end);
    
    std::copy(results.begin(), results.end(), std::ostream_iterator<std::string>(std::cout, "\n"));
    return 0;
}
