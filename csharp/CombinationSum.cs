// CombinationSum.cs
// Author: hyan23
// 2019.10.20
// https://leetcode.com/problems/combination-sum/

// Runtime: 284 ms (23.5% faster)
// Best solution: 232 ms

using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            Stopwatch watch = new Stopwatch();
            watch.Start();

            foreach (var combo in CombinationSum(new int[] { 2, 3, 6, 7 }, 7))
            {
                Console.WriteLine(string.Join(",", combo));
            }
            Console.WriteLine();
            foreach (var combo in CombinationSum(new int[] { 2, 3, 5 }, 8))
            {
                Console.WriteLine(string.Join(",", combo));
            }
            Console.WriteLine();
            foreach (var combo in CombinationSum(new int[] { 6, 8, 12, 5, 9, 3, 4, 11 }, 31))
            {
                //Console.WriteLine(string.Join(",", combo));
            }

            watch.Stop();
            Console.WriteLine($"{watch.ElapsedMilliseconds}ms");
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> results = new List<IList<int>>();
            Helper(candidates, target, 0, new List<int>(), results);
            return results;
        }

        public void Helper(int[] candidates, int target, int index, List<int> combo, List<IList<int>> results)
        {
            if (index > candidates.Length - 1)
            {
                return;
            }
            if (target > 0)
            {
                // 不允许选取上次选取元素之前的元素，因为那个元素必然已被其他序列选过
                // 而那个序列有机会选择本序列所有元素而产生重复
                for (int i = index; i < candidates.Length; i++)
                {
                    List<int> combo2 = new List<int>(combo);
                    combo2.Add(candidates[i]);
                    Helper(candidates, target - candidates[i], i, combo2, results);
                }
            }
            else if (target == 0)
            {
                results.Add(combo);
            }
        }
    }
}
