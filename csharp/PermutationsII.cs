// PermutationsII.cs
// Author: hyan23
// 2019.10.22
// https://leetcode.com/problems/permutations-ii/

/*
Given a collection of numbers that might contain duplicates, return all possible unique permutations.
Example:
Input: [1,1,2]
Output:
[
  [1,1,2],
  [1,2,1],
  [2,1,1]
]
*/

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
            PrintPermutations(new int[] { 1, 1, 2 });
            Console.WriteLine();
            PrintPermutations(new int[] { });
            Console.WriteLine();
            PrintPermutations(new int[] { 1 });
            Console.WriteLine();
            PrintPermutations(new int[] { 1, 3, 4, 3 });
            Console.WriteLine();
            PrintPermutations(new int[] { 2, 2, 1, 1 });
        }

        private void PrintPermutations(int[] nums)
        {
            foreach (var permutation in PermuteUnique(nums))
            {
                Console.WriteLine(string.Join(", ", permutation));
            }
        }

        class Cmp : EqualityComparer<IList<int>>
        {
            public override bool Equals(IList<int> x, IList<int> y)
            {
                return x.SequenceEqual(y);
            }

            public override int GetHashCode(IList<int> obj)
            {
                return $"{obj.First()}-{obj.Last()}".GetHashCode();
            }
        }

        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> permutations = new List<IList<int>>();
            Dictionary<string, bool> numDict = nums.Zip(Enumerable.Range(0, nums.Length),
                (x, y) => $"{y}:{x}").ToDictionary(x => x, x => true);
            Helper(permutations, new List<int>(), nums, numDict);
            return permutations.Distinct(new Cmp()).ToList();
        }

        private void Helper(IList<IList<int>> permutations, IList<int> permutation, int[] nums, Dictionary<string, bool> numDict)
        {
            bool empty = true;
            for (int i = 0; i < nums.Length; i++)
            {
                string key = $"{i}:{nums[i]}";
                if (numDict[key])
                {
                    empty = false;
                    numDict[key] = false;
                    permutation.Add(nums[i]);
                    Helper(permutations, permutation, nums, numDict);
                    permutation.Remove(nums[i]);
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
