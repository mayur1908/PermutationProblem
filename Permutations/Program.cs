using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    public class Program
    {
        class Permutations
        {
            // Iterative method to generate permutations
            public static List<string> GetPermutationsIterative(string str)
            {
                List<string> permutations = new List<string>();
                permutations.Add(str);  // Add the original string as the first permutation

                for (int i = 0; i < str.Length - 1; i++)
                {
                    int size = permutations.Count;
                    for (int j = 0; j < size; j++)
                    {
                        char[] chars = permutations[j].ToCharArray();
                        for (int k = i + 1; k < str.Length; k++)
                        {
                            // Swap characters
                            char temp = chars[i];
                            chars[i] = chars[k];
                            chars[k] = temp;

                            permutations.Add(new string(chars));
                        }
                    }
                }

                return permutations;
            }

            // Recursive method to generate permutations
            public static List<string> GetPermutationsRecursive(string str)
            {
                List<string> permutations = new List<string>();
                GeneratePermutations(str.ToCharArray(), 0, str.Length - 1, permutations);
                return permutations;
            }

            private static void GeneratePermutations(char[] strArr, int start, int end, List<string> permutations)
            {
                if (start == end)
                {
                    permutations.Add(new string(strArr));
                }
                else
                {
                    for (int i = start; i <= end; i++)
                    {
                        Swap(ref strArr[start], ref strArr[i]);
                        GeneratePermutations(strArr, start + 1, end, permutations);
                        Swap(ref strArr[start], ref strArr[i]); // backtrack
                    }
                }
            }

            private static void Swap(ref char a, ref char b)
            {
                char temp = a;
                a = b;
                b = temp;
            }
        }

        static void Main(string[] args)
        {
            string ip = "May";

            // Generate permutations using the iterative method
            List<string> iterativePermutations = Permutations.GetPermutationsIterative(ip);

            // Generate permutations using the recursive method
            List<string> recursivePermutations = Permutations.GetPermutationsRecursive(ip);

            // Check if the two arrays are equal
            bool areEqual = Enumerable.SequenceEqual(iterativePermutations, recursivePermutations);

            Console.WriteLine("Permutations using iterative method:");
            foreach (string permutation in iterativePermutations)
            {
                Console.WriteLine(permutation);
            }

            Console.WriteLine("Permutations using recursive method:");
            foreach (string permutation in recursivePermutations)
            {
                Console.WriteLine(permutation);
            }

            Console.WriteLine("Are the permutations equal? " + areEqual);

        }
    }
}
