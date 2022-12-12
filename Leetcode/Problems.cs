using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class Problems
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        //https://leetcode.com/problems/container-with-most-water/
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

        //https://leetcode.com/problems/valid-parentheses/
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

        //https://leetcode.com/problems/remove-element/
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

        //https://leetcode.com/problems/divide-two-integers/
        public int Divide(int dividend, int divisor)
        {
            long res = (long)dividend / (long)divisor;
            if (res > int.MaxValue) return int.MaxValue;
            if (res < int.MinValue) return int.MinValue;
            return (int)res;
        }

        //https://leetcode.com/problems/roman-to-integer/
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

        //https://leetcode.com/problems/longest-common-prefix/
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

        //https://leetcode.com/problems/zigzag-conversion/
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

        //https://leetcode.com/problems/remove-duplicates-from-sorted-array/
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

        //https://leetcode.com/problems/search-insert-position/
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

        //https://leetcode.com/problems/length-of-last-word/
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

        //https://leetcode.com/problems/plus-one/
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

        //https://leetcode.com/problems/symmetric-tree/
        public bool IsSymmetric(TreeNode root)
        {
            return root is null ? true : IsSymmetricHelper(root.left, root.right);
        }

        public bool IsSymmetricHelper(TreeNode l, TreeNode r)
        {
            if (l is null && r is null) return true; 
            if ((l is null || r is null) && (l != r)) return false;
            return (l is null || r is null) && (l == r) || (l.val == r.val && IsSymmetricHelper(l.left, r.right) && IsSymmetricHelper(l.right, r.left));
        }

        //https://leetcode.com/problems/maximum-depth-of-binary-tree/
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        //https://leetcode.com/problems/same-tree/
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if ((p == null && q != null) || (q == null && p != null)) return false;
            return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        //https://leetcode.com/problems/climbing-stairs/
        public int ClimbStairs(int n)
        {
            int[] arr = new int[n + 1];
            arr[0] = 1;
            arr[1] = 2;
            for (int i = 2; i <= n; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
            }
            return arr[n - 1];
        }

        //https://leetcode.com/problems/merge-sorted-array/
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] arr = new int[m + n];
            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
            {
                if (nums1[i] < nums2[j])
                {
                    arr[k++] = nums1[i++];
                }
                else
                {
                    arr[k++] = nums2[j++];
                }
            }
            while (i < m)
            {
                arr[k++] = nums1[i++];
            }

            while (j < n)
            {
                arr[k++] = nums2[j++];
            }
            for (k = 0; k < m + n;)
            {
                nums1[k] = arr[k++];
            }
        }

        //https://leetcode.com/problems/add-binary/
        public string AddBinary(string a, string b)
        {
            StringBuilder builder = new();

            int rm = 0;

            for (int i = 1; i < Math.Max(a.Length, b.Length) + 1; i++)
            {
                int aa = a.Length - i >= 0 ? a[a.Length - i] - '0' : 0;
                int bb = b.Length - i >= 0 ? b[b.Length - i] - '0' : 0;
                int sum = aa + bb + rm;
                if (sum > 1)
                {
                    sum = sum % 2;
                    rm = 1;
                }
                else
                {
                    rm = 0;
                }
                builder.Append(sum);
            }

            if (rm > 0) builder.Append(rm);

            var res = builder.ToString().ToCharArray();
            Array.Reverse(res);
            return new string(res);
        }

    }
}
