/***************************************************************************
* Title : IP Address Validation
* URL   : https://www.hackerrank.com/challenges/ip-address-validation/
* Date  : 2018-04-06
* Author: Atiq Rahman
* Comp  : O(n) to do multiple iterations, space O(n) to store tokens
* Status: Accepted
* Notes : This is solution for bloomberg version which only validates IPv4
*   For hackerrank version which includes validation for IPv6 check the C#
*   solution
*   If input string is valid IPv4 print IPv4
*   Otherwise print Invalid
*   Uses C++ istringstream to tokenize;
*   Example ref, https://atiqcs.wordpress.com/2018/01/27/cpp-fundamentals/
*   Example input at the bottom of the source
*   The interviewer suggested 'cerr' for debugging errors.
* meta  : tag-easy, tag-company-bloomberg, tag-string, tag-tokenize
***************************************************************************/
#include <sstream>
#include <string>
#include <vector>
#include <fstream>
#include <iostream>
#include <algorithm>    // find_if
#include <cctype>       // isdigit

class IPValidation {
private:
  // ref: How to determine if a string is a number with C++ 11?
  // https://stackoverflow.com/q/4654636
  bool is_number(const std::string& s)
  {
    return !s.empty() && std::find_if(s.begin(),
      s.end(), [](char c) { return !std::isdigit(c); }) == s.end();
  }

  // method 1: using std::stoi
  // ref: http://en.cppreference.com/w/cpp/string/basic_string/stol
  int convert_string_to_number(const std::string& s)
  {
    int val = -1;
    try {
      val = std::stoi(s);
    }
    catch (const std::invalid_argument& e) {
    }
    catch (const std::out_of_range& e) {
    }
    // when val = -1 caller function gets the meaning
    return val;
  }
  // method 2: using std::istringstream; need to test
  /* int convert_string_to_number(const std::string& s)
  {
    std::istringstream ss(s);
    int val;
    if (ss >> val)
    return val;
    return -1;
  }*/

  bool isValid(std::string ip) {
    // tokenize
    std::istringstream ss(ip);
    std::string token;
    int count = 0;
    char delim = '.';

    while (std::getline(ss, token, delim)) {
      count++;
      // early termination
      if (count > 4)
        return false;
      // validate if token is a number
      //if (is_number(token) == false)
      //return false;
      // valid input std::string, verify for ip token
      int val = convert_string_to_number(token);
      if (val < 0 || val > 255)
        return false;
    }
    return count == 4;
  }

  std::vector<std::string> checkIPs(std::vector<std::string> ip_array) {
    std::vector <std::string> result;
    for (auto ip : ip_array)
      result.push_back(isValid(ip) ? "IPv4" : "Invalid");
    return result;
  }

public:
  void Run(std::string inputFile) {
    // Handle IO
    std::ofstream fout(inputFile);
    std::vector <std::string> res;

    int _ip_array_size = 0;
    std::cin >> _ip_array_size;
    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');
    std::vector<std::string> _ip_array;
    std::string _ip_array_item;
    for (int _ip_array_i = 0; _ip_array_i<_ip_array_size; _ip_array_i++) {
      std::getline(std::cin, _ip_array_item);
      _ip_array.push_back(_ip_array_item);
    }

    res = checkIPs(_ip_array);
    for (size_t res_i = 0; res_i < res.size(); res_i++) {
      fout << res[res_i] << std::endl;;
    }

    fout.close();
  }
};

int main() {
  IPValidation demo;
  demo.Run("validation.txt");
  return 0;
}

/*
cerr examples,
cerr << "count " << count << "for input "<< ip << endl;
cerr << "count " << count << "for input "<< ip << endl;

Example input,
3
This is a text.
123.56.98.75
192.168.70.152

Output goes into specified 'validation.txt'
*/
