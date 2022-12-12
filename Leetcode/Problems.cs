using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Problems
    {

        public int MaxArea(int[] height)
        {
            int max = 0, left = 0, right = height.Length - 1, tmp;

            while (left < right)
            {
                max = Math.Max(max, (right - left) * Math.Min(height[left], height[right]));
                tmp = height[left] < height[right] ? left++ : right--;
            }

            return max;
        }

        public bool IsValid(string s)
        {
            if (s.Length % 2 == 1)
            {
                return false;
            }
            Stack<char> chars = new();
            Dictionary<char, char> dic = new Dictionary<char, char>() {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };
            foreach (char ch in s)
            {
                if (dic.ContainsKey(ch))
                {
                    if (chars.TryPeek(out char peek) && peek == dic[ch])
                    {
                        chars.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    chars.Push(ch);
                }
            }
            return chars.Count == 0;
        }

        public int RemoveElement(int[] nums, int val)
        {
            int count = 0;

            for (int i = 0, j = nums.Length - 1; i <= j;)
            {
                if (nums[i] == val && nums[j] != val)
                {
                    nums[i++] = nums[j--];
                    count++;
                    continue;
                }
                if (nums[i] != val)
                {
                    i++;
                }
                if (nums[j] == val)
                {
                    j--;
                    count++;
                }
            }

            return nums.Length - count;
        }

        public int Divide(int dividend, int divisor)
        {
            long res = (long)dividend / (long)divisor;
            if (res > int.MaxValue) return int.MaxValue;
            if (res < int.MinValue) return int.MinValue;
            return (int)res;
        }

        public int RomanToInt(string s)
        {
            var dict = new Dictionary<char, int>(){
            { 'I', 1},
            { 'V', 5},
            { 'X', 10},
            { 'L', 50},
            { 'C', 100},
            { 'D', 500},
            { 'M', 1000}
            };
            int num = dict[s[0]];
            for (int i = 1, j = 0; i < s.Length; i++, j++)
            {
                num += dict[s[i]] > dict[s[j]] ? dict[s[i]] - 2 * dict[s[j]] : dict[s[i]];
            }
            return num;
        }

        public string LongestCommonPrefix(string[] strs)
        {
            StringBuilder res = new("");
            char ch = ' ';
            for (int i = 0; true; i++)
            {
                if (strs[0].Length == i) return res.ToString();
                ch = strs[0][i];
                foreach (string s in strs)
                {
                    if (s.Length == i) return res.ToString();
                    if (ch != s[i]) return res.ToString();
                }
                res.Append(ch);
            }
        }

        public String Convert(String s, int n)
        {
            if (n == 1) return s;
            StringBuilder[] res = new StringBuilder[n];
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                res[i] = new StringBuilder();
            }
            for (int i = 0, j = 0, k = -1; i < s.Length; i++, j += k)
            {
                if (j == 0 || j == n - 1)
                {
                    k *= -1;
                }
                res[j].Append(s[i]);
            }
            foreach (var stb in res)
            {
                result.Append(stb);
            }
            return result.ToString();
        }

        public int RemoveDuplicates(int[] nums)
        {
            int count = 1;
            for (int i = 0, j = 1; j < nums.Length; j++)
            {
                if (nums[j] > nums[i])
                {
                    nums[++i] = nums[j];
                    count++;
                }
            }
            return count;
        }

        public int SearchInsert(int[] nums, int target)
        {
            int index = 0;
            foreach (var item in nums)
            {
                if (target <= item)
                {
                    return index;
                }
                index++;
            }
            return index;
        }

        public int LengthOfLastWord(string s)
        {
            int count = 0;
            for (int i = s.Length - 1; i > -1; i--)
            {
                if (s[i] == ' ')
                {
                    if (count != 0)
                    {
                        return count;
                    }
                }
                else
                {
                    count++;
                }
            }
            return count;
        }

        public int[] PlusOne(int[] digits)
        {
            List<int> result = new List<int>();
            int remainder = 1;
            for (int i = digits.Length - 1; i > -1; i--)
            {
                if (remainder == 0)
                {
                    result.Add(digits[i]);
                }
                else
                {
                    if (digits[i] == 9)
                    {
                        result.Add(0);
                    }
                    else
                    {
                        result.Add(digits[i] + 1);
                        remainder--;
                    }
                }
            }
            if (remainder == 1)
            {
                result.Add(1);
            }

            result.Reverse();
            return result.ToArray();
        }

    }
}
