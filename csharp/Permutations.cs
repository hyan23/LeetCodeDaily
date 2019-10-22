// Permutations.cs
// Author: hyan23
// 2019.10.22
// https://leetcode.com/problems/permutations/

/*
 * Given a collection of distinct integers, return all possible permutations.
Example:
Input: [1,2,3]
Output:
[
  [1,2,3],
  [1,3,2],
  [2,1,3],
  [2,3,1],
  [3,1,2],
  [3,2,1]
]
*/

// Runtime: 256 ms, faster than 73.76% of C# online submissions for Permutations.
// Memory Usage: 30.9 MB, less than 50.00% of C# online submissions for Permutations.

using System;
using System.Collections.Generic;
using System.Linq;

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
            PrintPermutations(new int[] { 1, 2, 3 });
            Console.WriteLine();
            PrintPermutations(new int[] { });
            Console.WriteLine();
            PrintPermutations(new int[] { 1 });
            Console.WriteLine();
            PrintPermutations(new int[] { 1, 3, 4, 5 });
        }

        private void PrintPermutations(int[] nums)
        {
            foreach (var permutation in Permute(nums))
            {
                Console.WriteLine(string.Join(", ", permutation));
            }
        }

        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> permutations = new List<IList<int>>();
            Dictionary<int, bool> numDict = nums.ToDictionary(x => x, x => true);
            Helper(permutations, new List<int>(), nums, numDict);
            return permutations;
        }

        private void Helper(IList<IList<int>> permutations, IList<int> permutation, int[] nums, Dictionary<int, bool> numDict)
        {
            bool empty = true;
            foreach (var key in nums)
            {
                if (numDict[key])
                {
                    empty = false;
                    numDict[key] = false;
                    permutation.Add(key);
                    Helper(permutations, permutation, nums, numDict);
                    permutation.Remove(key);
                    numDict[key] = true;
                }
            }
            if (empty && permutation.Count > 0)
            {
                permutations.Add(permutation.ToList());
            }
        }
    }
}
