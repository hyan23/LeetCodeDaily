// CountingElements.cs
// Author: hyan23
// 2020.04.11
// https://leetcode.com/explore/challenge/card/30-day-leetcoding-challenge/528/week-1/3289/

// 

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
        }

        public int MaxProfit(int[] prices)
        {
            int max = 0;
            int buy = prices[0];
            foreach (var p in prices)
            {
                if (buy < p)
                {
                    max += p - buy;
                }
                buy = p;
            }
            return max;
        }
    }
}
