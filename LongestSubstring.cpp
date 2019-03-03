// LongestSubstring.cpp
// Author: hyan23
// 2019.03.03
// https://leetcode.com/problems/longest-substring-without-repeating-characters/

#include <iostream>
#include <map>

using namespace std;

class Solution
{
  public:
    int lengthOfLongestSubstring(string s)
    {
        int result = 0;
        map<char, int> charMap;

        int i = 0, j = 0;
        while (j < s.length())
        {
            char ch = s[j];
            auto iter = charMap.find(ch);
            if (iter != charMap.end())
            {
                if (iter->second >= i)
                {
                    i = iter->second + 1;
                }
            }
            charMap[ch] = j;
            int length = j - i + 1;
            if (length > result)
            {
                // cout << j << "-" << i << "+1  ";
                result = length;
            }
            j++;
        }
        return result;
    }
};

int main(int argc, char *argv[])
{
    (void)argc;
    (void)argv;

    cout << Solution().lengthOfLongestSubstring("abcabcbb") << endl;
    cout << Solution().lengthOfLongestSubstring("bbbbb") << endl;
    cout << Solution().lengthOfLongestSubstring("pwwkew") << endl;
    cout << Solution().lengthOfLongestSubstring("aab") << endl;
    cout << Solution().lengthOfLongestSubstring("tmmzuxt") << endl;
    cout << Solution().lengthOfLongestSubstring("abba") << endl;

    return 0;
}