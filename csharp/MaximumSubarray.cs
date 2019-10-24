// MaximumSubarray.cs
// Author: hyan23
// 2019.10.24
// https://leetcode.com/problems/maximum-subarray/

/*
Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
Example:
Input: [-2,1,-3,4,-1,2,1,-5,4],
Output: 6
Explanation: [4,-1,2,1] has the largest sum = 6.
Follow up:
If you have figured out the O(n) solution, try coding another solution using the divide and conquer approach, which is more subtle.
 */

// <Analysis>

using System;

namespace csharp
{
    public class Program
    {
        public static void Main()
        {
            new Program().Test();
        }

        public void Test()
        {
            Console.WriteLine(MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }

        public int MaxSubArray(int[] nums)
        {
            int sum = nums[0], max = sum;
            int left = 0, right = 1;
            while (right < nums.Length)
            {
                sum += nums[right];
                int t = sum;
                for (int i = left; i < right; i++)
                {
                    t -= nums[i];
                    if (t >= sum)
                    {
                        sum = t;
                        left = i + 1;
                    }
                }
                if (sum > max)
                {
                    max = sum;
                }
                right++;
            }
            return max;
        }
    }
}
