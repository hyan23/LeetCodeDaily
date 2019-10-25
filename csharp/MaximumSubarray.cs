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

// Runtime: 96 ms, faster than 86.87% of C# online submissions for Maximum Subarray.
// Memory Usage: 24.7 MB, less than 10.00% of C# online submissions for Maximum Subarray.

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
            Console.WriteLine(MaxSubArray(new int[] { 1, 2 }));
            Console.WriteLine(MaxSubArray(new int[] { 2 }));
        }

        /*
         * 1. 最大子序列的第一个元素必然是正数
         * 2. 每个由正数开始的序列可以包含另一个正数，当且仅当：它的和大于零。否则，应该由另一个正数开始一个新序列
         * 3. 最大子序列必在这些由正数开始的子序列中取得
         * 如果一个序列没有正数，这算法也能工作。
         */
        public int MaxSubArray(int[] nums)
        {
            int sum = nums[0], max = sum;
            for (int i = 1; i < nums.Length; i++)
            {
                sum = sum > 0 ? sum + nums[i] : nums[i];
                max = Math.Max(max, sum);
            }
            return max;
        }
    }
}
