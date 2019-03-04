// PalindromeNumber.cpp
// Author: hyan23
// 2019.03.05
// https://leetcode.com/problems/palindrome-number/

#include <iostream>

using namespace std;

class Solution
{
  public:
    int getDigit(int x, int pos)
    {
        int lut[] = { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000 };
        return x / lut[pos] % 10;
    }
    
    bool isPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }
        int left = 9;
        while (left >= 0)
        {
            if (getDigit(x, left))
            {
                break;
            }
            left --;
        }
        int right = 0;
        while (left > right)
        {
            if (getDigit(x, left) != getDigit(x, right))
            {
                return false;
            }
            left --;
            right ++;
        }
        return true;
    }
};

int main(int argc, char *argv[])
{
    (void)argc;
    (void)argv;

    cout << Solution().isPalindrome(121) << endl;
    cout << Solution().isPalindrome(-121) << endl;
    cout << Solution().isPalindrome(10) << endl;
    cout << Solution().isPalindrome(1000021) << endl;
    cout << Solution().isPalindrome(0) << endl;

    return 0;
}