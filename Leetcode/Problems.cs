using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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

        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null) {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode MergeNodes(ListNode head) {
            ListNode result = new ListNode();
            ListNode cur = result;
            int sum = 0;
            while ((head = head.next) is not null) {
                sum += head.val;
                if (head.val == 0) {
                    cur.val = sum;
                    cur.next = new ListNode();
                    cur = cur.next;
                    sum = 0;
                }
            }
            cur.next = null;
            return result;
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
        // does not work yet
        public string LongestPalindrome(string s) {
            (int f, int l) res = (0, 1);
            List<int> list = new();
            list.Add(0);

            for (int i = 1; i < s.Length; i++) {
                for (int j = 0; j < list.Count; j++) {
                    if (list[j] != 0 && s[i] == s[list[j] - 1]) {
                        list[j]--;
                        continue;
                    }
                    if (res.l < i - list[j]) {
                        res.f = list[j];
                        res.l = i - list[j];
                    }
                    list.RemoveAt(j--);
                }
                list.Add(i);
                if (s[i] == s[i - 1]) {
                    list.Add(i - 1);
                }
            }

            foreach (var item in list) {
                if (res.l < s.Length - item) {
                    res.f = item;
                    res.l = s.Length - item;
                }
            }

            return s.Substring(res.f, res.l);
        }

        //https://leetcode.com/problems/next-permutation/
        public void NextPermutation(int[] nums) {
            int i = nums.Length - 2, tmp = 0;
            for (; i >= 0; i--) {
                if (nums[i] < nums[i + 1]) {
                    for (int j = nums.Length - 1; true; j--) {
                        if (nums[i] < nums[j]) {
                            tmp = nums[i];
                            nums[i] = nums[j];
                            nums[j] = tmp;
                            break;
                        }
                    }
                    break;
                }
            }

            Array.Sort(nums, i + 1, nums.Length - i - 1);
        }

        //
        public IList<IList<int>> PermuteUnique(int[] nums) {
            var res = new List<IList<int>>();
            PermuteUniqueHelper(new List<int>(nums), res, new List<int>());
            return res;
        }

        public void PermuteUniqueHelper(List<int> numbers, List<IList<int>> lists, List<int> cur) {
            if (numbers.Count == 0) {
                lists.Add(new List<int>(cur));
                return;
            }
            var set = new HashSet<int>();
            for (int i = 0; i < numbers.Count; i++) {
                int removed = numbers.ElementAt(i);
                if (set.Contains(removed)) {
                    continue;
                }
                set.Add(removed);
                numbers.RemoveAt(i);
                cur.Add(removed);
                PermuteUniqueHelper(numbers, lists, cur);
                numbers.Insert(i, removed);
                cur.RemoveAt(cur.Count - 1);
            }
        }


        public int[] CountBits(int n) {
            int[] arr = new int[n + 1];
            arr[0] = 0;
            if (n == 0) {
                return arr;
            }
            arr[1] = 1;
            int i = 1, j = 2, k = 0;
            Loop:
            for (k = j / 2; i < j && i < arr.Length; i++) {
                arr[i] = arr[k] + arr[i - k];
            }
            if (i < arr.Length) {
                j = i * 2;
                arr[i++]++;
                goto Loop;
            }
            return arr;
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            var arr = nums1.Concat(nums2).ToArray();
            Array.Sort(arr);
            if (arr.Length % 2 == 0)
                return (arr[arr.Length / 2] + arr[arr.Length / 2 - 1]) / 2.0;
            return arr[arr.Length / 2];
        }


        // write this
        public bool IsMatch(string s, string p) {
            List<(char ch, int count)> lists = new(new (char, int)[] { (s[0], 0) });
            List<string> listp = new();
            List<char> zeroormore = new();

            foreach (var item in s) {
                if (lists[^1].ch == item) lists[^1] = (lists[^1].ch, lists[^1].count + 1);
                else lists.Add((item, 1));
            }

            foreach (var item in p) {
                if (listp.Count > 0 && listp[^1][^1] == item) listp[listp.Count - 1] += item;
                else if (item == '*') {
                    if (listp[^1].Length != 1) {
                        listp[listp.Count - 1] = listp[^1].Substring(0, listp[^1].Length - 1);
                        listp.Add(listp[^1][^1].ToString());
                    }
                    listp[listp.Count - 1] += item;
                } else {
                    listp.Add(item.ToString());
                }
            }

            for(int i = 0; i < listp.Count; i++) {
                if (listp[i].Contains('*')) {
                    zeroormore.Add(listp[i][0]);
                } else {
                    if (lists.Count == 0) return false;
                    if (lists[0].ch == listp[i][0] || listp[i][0] == '.') {
                        if (lists[0].count == listp[i].Length) {
                            lists.RemoveAt(0);
                            continue;
                        }
                        if (lists[0].count < listp[i].Length) {
                            listp[i] = new string(Enumerable.Repeat(listp[i][0], listp[i].Length - lists[0].count).ToArray());
                            lists.RemoveAt(0);
                            i--;
                        } else {
                            lists[0] = (lists[0].ch, lists[0].count - listp[i].Length);
                        }
                    } else {
                        int index = zeroormore.FindIndex(x => x == lists[0].ch || x == '.');
                        if (index == -1) return false;
                        zeroormore.RemoveRange(0, index + 1);
                        lists.RemoveAt(0);
                        i--;
                    }
                }
            }

            foreach (var item in zeroormore) {
                if (lists.Count == 0) break;
                if (item == '.') return true;
                if (item == lists[0].ch) {
                    lists.RemoveAt(0);
                }
            }

            return lists.Count == 0;
        }

        public bool IsStrictlyPalindromic(int n) {
            return Enumerable.Range(2, n - 2).Select(x => new string(System.Convert.ToString(n, x).Skip('0').ToArray())).ToList().All(s => IsPalindrom(s));
            
            bool IsPalindrom(string s) {
                for (int i = 0; i < s.Length / 2; i++)
                    if (s[i] != s[s.Length - i - 1])
                        return false;
                return true;
            }
            
        }

        public int DeepestLeavesSum(TreeNode root) {
            Dictionary<int, List<int>> dict = new();
            int max = 0;
            maxHeight(root, 0, ref max, dict);
            return dict[max].Sum();

            void maxHeight(TreeNode root, int cur, ref int max, Dictionary<int, List<int>> dict) {
                if (root is null) return;
                if (cur > max) {
                    max = cur;
                }
                if (cur == max) {
                    if (!dict.ContainsKey(max)) {
                        dict.Add(max, new List<int>());
                    }
                    dict[max].Add(root.val);
                }
                maxHeight(root.left, cur + 1, ref max, dict);
                maxHeight(root.right, cur + 1, ref max, dict);
            }
        }


        public class SubrectangleQueries {

            int[][] rectangle;

            public SubrectangleQueries(int[][] rectangle) => this.rectangle = rectangle;

            public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue) {
                for (int r = row1; r <= row2; r++) {
                    for (int c = col1; c <= col2; c++) {
                        rectangle[r][c] = newValue;
                    }
                }
            }

            public int GetValue(int row, int col) => rectangle[row][col];
        }

        public int[] TwoSum(int[] nums, int target) {
            Dictionary<int, int> dict = new();
            for (int i = 0; i < nums.Length; i++) {
                if (dict.ContainsKey(target - nums[i]))
                    return new int[] { dict[target - nums[i]], i };
                if (!dict.ContainsKey(nums[i]))
                    dict.Add(nums[i], i);
            }
            return null;
        }

        public int[] TwoSumII(int[] nums, int target) {
            int l = 0, r = nums.Length - 1;
            while (l < r) {
                int sum = nums[l] + nums[r];
                if (sum == target)
                    return new int[] { l + 1, r + 1 };
                if (sum < target)
                    l++;
                else r--;
            }
            return null;
        }

        public bool CheckSubarraySum(int[] nums, int k) {
            Dictionary<int, List<int>> dict = new();
            int sumTillIndex = 0;
            dict.Add(0, new List<int>(new int[] { -1 }));

            for (int i = 0; i < nums.Length; i++) {

                sumTillIndex += nums[i];

                dict.TryAdd(sumTillIndex, new List<int>());
                dict[sumTillIndex].Add(i);

                if (dict.Any(x => (sumTillIndex - x.Key) % k == 0 && i - x.Value[0] > 1))
                    return true;

            }

            return false;
        }

        public int SubarraySum(int[] nums, int k) {
            Dictionary<int, int> dict = new();
            int sumTillIndex = 0, count = 0;

            dict.Add(0, 1);

            for (int i = 0; i < nums.Length; i++) {

                sumTillIndex += nums[i];

                if (dict.ContainsKey(sumTillIndex - k))
                    count += dict[sumTillIndex - k];

                dict[sumTillIndex] = dict.GetValueOrDefault(sumTillIndex) + 1;
            }

            return count;
        }

        public IList<IList<int>> ThreeSum(int[] nums) {
            Array.Sort(nums);
            List<IList<int>> list = new();
            int tmp;

            for(int i = 0; i < nums.Length - 2;) {
                if (nums[i] > 0) break;
                int l = i + 1, r = nums.Length - 1;
                while (l < r) {
                    int sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0) {
                        list.Add(new int[] { nums[i], nums[l], nums[r] });
                    }
                    if (sum <= 0) {
                        tmp = l;
                        while (++l < r && nums[tmp] == nums[l]) ;
                    } else {
                        tmp = r;
                        while (l < --r && nums[tmp] == nums[r]) ;
                    }
                }
                tmp = i;
                while (++i < nums.Length - 2 && nums[tmp] == nums[i]) ;
            }

            return list;
        }

        public IList<IList<int>> FourSum(int[] nums, int target) {
            Array.Sort(nums);
            HashSet<(int, int, int, int)> list = new();
            for (int i = 0; i < nums.Length - 4; i++) {
                for (int j = i + 1; j < nums.Length - 3; j++) {
                    int l = j + 1, r = nums.Length - 1, sum2 = nums[i] + nums[j];
                    //if (sum2 > 0 && target > 0 && sum2 > target / 2) return list;
                    while (l < r) {
                        int sum = sum2 + nums[l] + nums[r];
                        if (sum == target) {
                            list.Add((nums[i], nums[j], nums[l++], nums[r]));
                        } else if (sum <= target) {
                            l++;
                        } else {
                            r--;
                        }
                    }
                }
            }
            return list.Select(x => new int[] {x.Item1, x.Item2, x.Item3, x.Item4}).ToList<IList<int>>();
        }

        public bool CanBeValid(string s, string locked) {
            if (s.Length % 2 == 1)
                return false;
            int open = 0, canopen = 0, canclose = 0;

            for (int i = 0; i < s.Length; i++) {
                if (s[i] == '(')
                    open++;
                else {
                    open--;
                    if (open / 2 < canclose)
                        canclose--;
                }

                if (locked[i] == '0') {
                    if (s[i] == ')')
                        canopen++;
                    else if (canclose + 1 <= open / 2)
                        canclose++;
                }

                if (open < 0) {
                    if (canopen > 0) {
                        open += 2;
                        canopen--;
                    } else
                        return false;
                }

            }

            return open == 0 || canclose >= open / 2;
        }

        public bool CheckValidString(string s) {

            int min = 0, max = 0;

            for (int i = 0; i < s.Length; i++) {
                max += s[i] != ')' ? 1 : -1;
                min += s[i] == '(' ? 1 : min ==  0 ? 0 : -1;
                if (max < 0)
                    return false;

            }

            return min == 0;
        }

        public int LongestValidParentheses(string s) {
            if (s.Length == 0) return 0;
            int open = 0;
            int[] arr = new int[s.Length + 1];

            for (int i = 0, j = 1; i < s.Length; i++, j++) {
                if (s[i] == '(') {
                    open++;
                } else if (open > 0) {
                    open--;
                    arr[j] = arr[i] + 1;
                    int lastclose = j - 2 * arr[j];
                    arr[j] += arr[lastclose];
                }
            }

            return 2 * arr.Max();
        }

        public int[] SearchRange1(int[] nums, int target) {
            (int l, int m, int r, int d, bool f) tmp = (0, 0, nums.Length - 1, 0, false);

            int index = bsearch(() => {
                if (tmp.d < 0) tmp.l = tmp.m + 1;
                else if (tmp.d > 0) tmp.r = tmp.m - 1;
                else tmp.f = true;
            });

            tmp = (0, tmp.m, index, 0, false);
            int li = bsearch(() => {
                if (tmp.d < 0) tmp.l = tmp.m + 1;
                else if (tmp.m == 0 || nums[tmp.m - 1] < target) tmp.f = true;
                else tmp.r = tmp.m - 1;
            });

            tmp = (index == -1 ? nums.Length : index, tmp.m, nums.Length - 1, 0, false);
            int ri = bsearch(() => {
                if (tmp.d > 0) tmp.r = tmp.m - 1;
                else if (tmp.m == nums.Length - 1 || nums[tmp.m + 1] > target) tmp.f = true;
                else tmp.l = tmp.m + 1;
            });

            return new int[] { li, ri };

            int bsearch(Action action) {
                if (tmp.l > tmp.r) return -1;
                tmp.m = (tmp.l + tmp.r) / 2;
                tmp.d = nums[tmp.m] - target;
                action();
                return tmp.f ? tmp.m : bsearch(action);
            }
        }

        public int CoinChange(int[] coins, int amount) {
            Array.Sort(coins);
            return helper(coins.Length - 1, 0, 0);

            int helper(int i, int curamount, int coincount) {
                if (curamount == amount) {
                    return coincount;
                }

                if (i < 0) {
                    return -1;
                }

                int amountgoal = amount - curamount;
                int res = int.MaxValue;
                int curcoincount = amountgoal / coins[i];
                while (curcoincount > -1) {
                    int helperres = helper(i - 1, curamount + curcoincount * coins[i], coincount + curcoincount);
                    if (helperres != -1) {
                        res = Math.Min(res, helperres);
                    }
                    curcoincount--;
                }

                return res == int.MaxValue ? -1 : res;
            }
        }


        public IList<IList<int>> CombinationSum(int[] candidates, int target) {
            List<IList<int>> res = new();
            Array.Sort(candidates);
            helper(new List<int>());

            return res;

            void helper(List<int> l, int i = 0, int sum = 0) {
                if (sum > target) {
                    return;
                }
                if (sum == target) {
                    res.Add(l.ToArray());
                }

                for (; i < candidates.Length; i++) {
                    l.Add(candidates[i]);
                    helper(l, i, sum + candidates[i]);
                    l.Remove(candidates[i]);
                }
            }
        }


        public void Rotate(int[][] matrix) {
            int l = matrix.Length - 1, tmp;
            for (int i = 0; i < l / 2 + 1; i++) {
                for (int j = i; j < l - i; j++) {
                    tmp = matrix[i][j];
                    matrix[i][j] = matrix[l - j][i];
                    matrix[l - j][i] = matrix[l - i][l - j];
                    matrix[l - i][l - j] = matrix[j][l - i];
                    matrix[j][l - i] = tmp;
                }
            }
        }

        public int[] SearchRange(int[] nums, int target) {
            (int l, int m, int r, bool found) tmp = (0, 0, nums.Length - 1, false);

            int index = bsearch(() => (nums[tmp.m] - target) switch {
                    < 0 => (tmp.m + 1, tmp.m, tmp.r, false),
                    > 0 => (tmp.l, tmp.m, tmp.m - 1, false),
                    0 => (tmp.l, tmp.m, tmp.r, true)
            });

            tmp = (0, tmp.m, index, false);
            int li = bsearch(() => (nums[tmp.m] - target) switch {
                    < 0 => (tmp.m + 1, tmp.m, tmp.r, false),
                    0 => tmp.m == 0 || nums[tmp.m - 1] < target ? (tmp.l, tmp.m, tmp.r, true) : (tmp.l, tmp.m, tmp.m - 1, false)
            });

            tmp = (index == -1 ? nums.Length : index, tmp.m, nums.Length - 1, false);
            int ri = bsearch(() => (nums[tmp.m] - target) switch {
                    > 0 => (tmp.l, tmp.m, tmp.m - 1, false),
                    0 => tmp.m == nums.Length - 1 || nums[tmp.m + 1] > target ? (tmp.l, tmp.m, tmp.r, true) : (tmp.m + 1, tmp.m, tmp.r, false)
            });

            return new int[] { li, ri };
            
            int bsearch(Func<(int, int, int, bool)> condition) {
                if (tmp.l > tmp.r) return -1;
                tmp.m = (tmp.l + tmp.r) / 2;
                return (tmp = condition()).found ? tmp.m : bsearch(condition);
            }
        }

        public int ThreeSumClosest(int[] nums, int target) {
            int i = 0, j = 1, k = 2, res = Math.Abs(nums[i] + nums[j] + nums[k] - target), tmp = res;
            for (; i < nums.Length - 2; i++) {
                for (; j < nums.Length - 1; j++) {
                    for (; k < nums.Length; k++) {
                        tmp = Math.Abs(nums[i] + nums[j] + nums[k] - target);
                        res = Math.Min(res, tmp);
                        if (tmp > res) break;
                    }
                }
            }
            return 0;
        }

        public int[][] Insert(int[][] i, int[] n) {
            List<(int[] x, int y)> l = i.Select((x, y) => (x, y)).Where(z => n[1] >= z.x[0] && n[0] <= z.x[1]).ToList();

            return null;
        }

        public bool MakeStringsEqual(string s, string t) {
            if (s.Equals(t)) return true;
            int s1 = s.FirstOrDefault(x => x == '1', '0'), t1 = t.FirstOrDefault(x => x == '1', '0');
            if (s1 == t1) return false;
            return true;
        }

        public int[][] SortTheStudents(int[][] score, int k) {
            PriorityQueue<int[], int> pq = new();
            foreach(var arr in score) {
                pq.Enqueue(arr, arr[k]);
            }
            int[][] res = new int[score.Length][];
            for (int i = score.Length - 1; i >= 0; i--) {
                res[i] = pq.Dequeue();
            }
            return res;
        }

    }
}
