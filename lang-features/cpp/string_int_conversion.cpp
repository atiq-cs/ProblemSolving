/*
    Demonstration of string and numeric type conversion
        stoi
        stol, stoll
        stoul, stoull

        to_string

    Includes demonstration of exception handling as well,
    ref: http://stackoverflow.com/questions/1157591/what-type-of-exception-should-i-throw

    to_string ref: http://en.cppreference.com/w/cpp/string/basic_string/to_string
*/

#include <iostream>
#include <algorithm>
#include <string>
#include <exception>

int main() {
    std::string num_str1 = "1253";
    std::string num_str2 = "4321";

    //================================================================================================================//
    //                    string to numeric type conversion example
    //================================================================================================================//
    // string to int, example use of std::stoi
    // we are not handling exceptions here for demonstrating usage, please handle exceptions
    long long num1 = std::stoi(num_str1);
    long long num2 = std::stoi(num_str2);
    std::cout << "Sum of "<< num1<<" and "<< num2 <<"= "<<num1 + num2 << std::endl;

    // string to long long
    // max limit of long long 9223372036854775807
    // num_str1 = "2133569876541321852555";        // for example, use this for an out_of_range exception test
    // num_str1 = "sadf12";                        // for example, use this for an invalid_argument exception test
    num_str1 = "2133569876541321852";
    num_str2 = "6985555576541321852";
    try {
        // might throw exception std::invalid_argument or std::out_of_range
        num1 = std::stoll(num_str1);
        num2 = std::stoll(num_str2);
    }
    catch (std::invalid_argument &e)
    {
        std::cout << "Invalid argument exception: " << e.what() << std::endl;
        return 0;
    }
    catch (std::out_of_range &e)
    {
        std::cout << "Out of range exception: " << e.what() << std::endl;
        return 0;
    }
    catch (std::exception &e)
    {
        std::cout << "Other exception: " << e.what() << std::endl;
        return 0;
    }

    std::cout << "Sum of " << num1 << " and " << num2 << "= " << num1 + num2 << std::endl;

    //================================================================================================================//
    //                    numeric type to string conversion example
    //================================================================================================================//
    // we have numeric data on variables num1 and num2
    std::string str1, str2;
    str1 = std::to_string(num1);
    str2 = std::to_string(num2);
    std::cout << "Converted numeric data to string: " << str1 << " and " << str2 << std::endl;

    return 0;
}
