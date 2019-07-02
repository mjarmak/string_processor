using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {
        public void Run()
        {
            // TODO
            // Complete the methods below


            // For the anagram test, I calculated the unique chars and counts of each char for each word (using the function inexercise 2) as features,
            // then I compared these features for each word, and if they match, then they are anagrams
            Console.WriteLine("String Exercise 1:");
            AnagramTest();

            // For getting the unique char and count of each char, I scan the string, and each time I encounter a new char,
            // I store it inside the string "uc" which I will use to check if the next char of "word" is included in "uc" to
            // to know if I already encountered it. Each string in "uc" has a corrensponding count integer in the int list "occurences". So
            // each time I encounter a char already included in "uc", I add 1 to the corresponding int in "occurences"
            Console.WriteLine("String Exercise 2:");
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "test", "tops", "spin", "post", "mist", "step" };
                
            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";

            string uc = "";
            int uc_count = 0;
            StringBuilder sb = new StringBuilder();
            List<int> occurences = new List<int>();

            foreach (char c in word)
            {
                if (!uc.Contains(c.ToString()))
                {
                    sb.Append(c);
                    uc = sb.ToString();
                    uc_count++;
                    occurences.Add(0);
                }
                for (int i = 0; i < uc.Length; i++)
                    if (uc.Substring(i,1) == c.ToString() && uc.Substring(i, 1) != " ")
                        occurences[i]++;
            }
            
            Console.WriteLine("The word is: " + word);
            Console.WriteLine("There are: " + uc_count + " unique characters");
            Console.WriteLine("Unique characters are: " + uc);

            for (int i = 0; i < uc.Length; i++)
                Console.WriteLine(uc.Substring(i,1) + " occured: " + occurences[i]);

            // TODO
            // Write an algorithm that gets the unique characters of the word below 
            // and counts the number of occurrences for each character found
        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)
        {
            // TODO
            // Write logic to determine whether a is an anagram of b


            string uc_a = "";
            int uc_count_a = 0;
            List<int> occurences_a = new List<int>();
            string uc_b = "";
            int uc_count_b = 0;
            List<int> occurences_b = new List<int>();


            StringBuilder sb = new StringBuilder();

            foreach (char c in a)
            {
                if (!uc_a.Contains(c.ToString()))
                {
                    sb.Append(c);
                    uc_a = sb.ToString();
                    uc_count_a++;
                    occurences_a.Add(0);
                }
                for (int i = 0; i < uc_a.Length; i++)
                    if (uc_a.Substring(i, 1) == c.ToString() && uc_a.Substring(i, 1) != " ")
                        occurences_a[i]++;
            }

            sb.Clear();
            foreach (char c in b)
            {
                if (!uc_b.Contains(c.ToString()))
                {
                    sb.Append(c);
                    uc_b = sb.ToString();
                    uc_count_b++;
                    occurences_b.Add(0);
                }
                for (int i = 0; i < uc_b.Length; i++)
                    if (uc_b.Substring(i, 1) == c.ToString() && uc_b.Substring(i, 1) != " ")
                        occurences_b[i]++;
            }

            if (uc_count_a == uc_count_b)
            {
                for (int i = 0; i < uc_count_a; i++)
                {
                    for (int j = 0; j < uc_count_b; j++)
                    {
                        if(!uc_a.Contains(uc_b.Substring(j, 1)))
                            return false;
                        else if (uc_a.Substring(i, 1) == uc_b.Substring(j, 1)) {
                            if (occurences_a[i] != occurences_b[j])
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            else
                return false;
        }
    }
}
