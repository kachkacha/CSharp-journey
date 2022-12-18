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

        //https://leetcode.com/problems/binary-tree-inorder-traversal/
        public IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>();
            InorderTraversalHelper(root, list);
            return list;
        }

        public void InorderTraversalHelper(TreeNode root, IList<int> list)
        {
            if (root == null) return;
            InorderTraversalHelper(root.left, list);
            list.Add(root.val);
            InorderTraversalHelper(root.right, list);
        }

        //https://leetcode.com/problems/remove-one-element-to-make-the-array-strictly-increasing/
        public bool CanBeIncreasing(int[] nums)
        {
            bool remove = false;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] <= nums[i - 1])
                {
                    if (remove || i != 1 && nums[i] <= nums[i - 2] && i != nums.Length - 1 && nums[i + 1] <= nums[i - 1])
                    {
                        return false;
                    }
                    remove = true;
                }
            }
            return true;
        }

        //https://leetcode.com/problems/x-of-a-kind-in-a-deck-of-cards/
        public bool HasGroupsSizeX(int[] deck)
        {
            Dictionary<int, int> nums = new();
            foreach (var item in deck)
            {
                if (nums.ContainsKey(item))
                {
                    nums[item] = nums[item] + 1;
                }
                else
                {
                    nums[item] = 1;
                }
            }
            int num = nums[deck[0]];
            foreach (var item in nums)
            {
                if (GCD(num, item.Value) == 1)
                {
                    return false;
                }
            }



            return true;
        }

        int GCD(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }


        //https://leetcode.com/problems/third-maximum-number/
        public int ThirdMax(int[] nums)
        {
            long max3 = long.MinValue, max2 = long.MinValue, max1 = long.MinValue;
            
            foreach (var item in nums)
            {
                if (item > max3 && item != max3 && item != max2 && item != max1)
                {
                    if (item > max2)
                    {
                        if (item > max1)
                        {
                            max3 = max2;
                            max2 = max1;
                            max1 = item;
                        }
                        else
                        {
                            max3 = max2;
                            max2 = item;
                        }
                    }
                    else
                    {
                        max3 = item;
                    }
                }
            }

            return (int)(max3 == long.MinValue ? max1 : max3);
        }


        //https://leetcode.com/problems/can-place-flowers/
        public bool CanPlaceFlowers(int[] flowerbed, int n) {
            int cur = 0;

            foreach (var item in flowerbed) {
                if (item == 0) {
                    if (cur == 2) {
                        cur--;
                        n--;
                    } else {
                        cur++;
                    }
                } else {
                    cur = 0;
                }
                if (n == 0) return true;
            }

            return false || (n == 1 && cur == 2);
        }


        //https://leetcode.com/problems/valid-mountain-array/
        public bool ValidMountainArray(int[] arr) {
            if (arr.Length < 3) return false;
            bool increase = true;

            for (int i = 1; i < arr.Length; i++) {
                if (increase) {
                    if (arr[i] < arr[i - 1]) {
                        if (i == 1) return false;
                        increase = !increase;
                    } else if (arr[i] == arr[i - 1]) {
                        return false;
                    }
                } else {
                    if (arr[i] >= arr[i - 1]) {
                        return false;
                    }
                }
            }

            return !increase;
        }


        //https://leetcode.com/problems/check-if-n-and-its-double-exist/
        public bool CheckIfExist(int[] arr)
        {
            HashSet<int> ints = new(arr);
            int zeros = 0;
            foreach (var item in arr)
            {
                ints.Remove(item);
                if (ints.Contains(2 * item))
                {
                    return true;
                }
                if (item == 0 && ++zeros == 2)
                {
                    return true;
                }
            }
            return false;
        }


        //https://leetcode.com/problems/valid-boomerang/
        public bool IsBoomerang(int[][] points) {
            (int x, int y) a = (points[0][0], points[0][1]);
            (int x, int y) b = (points[1][0], points[1][1]);
            (int x, int y) c = (points[2][0], points[2][1]);

            if (a == b || b == c || a == c) return false;

            if ((b.y - a.y == 0) || (c.y - a.y == 0)) {
                if (b.y == c.y) return false;
                else return true;
            }

            if ((b.x - a.x == 0) || (c.x - a.x == 0)) {
                if (b.x == c.x) return false;
                else return true;
            }

            if ((double)(b.x - a.x) / (b.y - a.y) == (double)(c.x - a.x) / (c.y - a.y)) return false;
            return true;
        }


        //https://leetcode.com/problems/longest-palindromic-substring/
        public string LongestPalindrome(string s) {
            (int f, int l) res = (0, 1);
            int[,] arr = new int[s.Length, 2];
            arr[0, 1]++;

            for (int i = 1; i < s.Length; i++) {
                arr[i, 1]++;
                if (s[i] == s[i - 1]) {
                    arr[i - 1, 0] = 2;
                    if (res.l < 2) {
                        res.f = i - 1;
                        res.l = 2;
                    }
                }
                for (int j = i - 1; j > 0; j--) {
                    int k = (i - j) % 2;
                    if (arr[j, k] > 0 && s[j - 1] == s[i]) {
                        arr[j - 1, k] = arr[j, k] + 2;
                        arr[j, k] = 0;
                        if (arr[j - 1, k] > res.l) {
                            res.f = j - 1;
                            res.l = arr[j - 1, k];
                        }
                    }
                }
            }

            return s.Substring(res.f, res.l);
        }


    }
}
