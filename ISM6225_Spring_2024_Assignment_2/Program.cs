using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                // Handle edge cases
                if (nums == null || nums.Length == 0)
                {
                    return new List<int>(); // Return empty list if input is null or empty
                }

                foreach (var num in nums)
                {
                    if (num < 1 || num > nums.Length)
                    {
                        throw new ArgumentException("Array contains invalid numbers outside the range [1, n].");
                    }
                }

                //Main Code
                List<int> result = new List<int>(); // Create a list to store missing numbers
                // Iterate through the input array
                for (int i = 0; i < nums.Length; i++)
                {
                    // Find the absolute value index (adjusting for zero-based index)
                    int val = Math.Abs(nums[i]) - 1;
                    // If the value at this index is positive, negate it to mark it as seen
                    if (nums[val] > 0)
                    {
                        nums[val] = -nums[val];
                    }
                }
                // Check which indices are still positive (missing numbers)
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] > 0)
                    {
                        result.Add(i + 1); // Add the missing number (i + 1) to the result
                    }
                }
                return result; // Return the list of missing numbers
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
                return new List<int>(); // Return empty list if input is invalid
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                int left = 0, right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[left] % 2 > nums[right] % 2)
                    {
                        // Swap nums[left] and nums[right]
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }

                    if (nums[left] % 2 == 0) left++;
                    if (nums[right] % 2 == 1) right--;
                }
                return nums; // Return the array sorted by parity
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here
                Dictionary<int, int> map = new Dictionary<int, int>(); // Create a dictionary to store number and index
                // Iterate through the array to find two numbers that add up to the target
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i]; // Calculate the complement
                    // Check if the complement exists in the dictionary
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i }; // Return the indices of the two numbers
                    }
                    map[nums[i]] = i; // Add the number and its index to the dictionary
                }
                return new int[0]; // Return an empty array if no solution is found

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null || nums.Length < 3) //validation to ensure the input array has at least 3 elements:
                    throw new ArgumentException("Input array must have at least 3 integers.");

                Array.Sort(nums); // Sort the array
                int n = nums.Length; // Get the length of the array
                // Calculate the maximum product of the last three numbers or the product of the first two (smallest) and the last (largest)
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[0] * nums[1] * nums[n - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                if (decimalNumber == 0) return "0"; // Special case for zero
                bool isNegative = decimalNumber < 0;
                decimalNumber = Math.Abs(decimalNumber);
                string binary = ""; // Initialize binary string
                // Convert decimal to binary by repeatedly dividing by 2
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary; // Prepend the remainder (0 or 1)
                    decimalNumber /= 2; // Divide the number by 2
                }
                return binary; // Return the binary representation
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DecimalToBinary: " + ex.Message);
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Write your code here
                if (nums == null || nums.Length == 0)
                    throw new ArgumentException("Input array must not be empty.");
                int left = 0; // Start index
                int right = nums.Length - 1; // End index
                // Use binary search to find the minimum element in the rotated sorted array
                while (left < right)
                {
                    int mid = (left + right) / 2; // Find the middle index
                    // If the middle element is greater than the rightmost element, the minimum is to the right
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1; // Move left index to mid + 1
                    }
                    else if (nums[mid] < nums[right])
                    {
                        right = mid;
                    }
                    else
                    {
                        right--; // Move right index to mid
                    }
                }
                return nums[left]; // Return the minimum element
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here
                if (x < 0) return false; // Negative numbers are not palindromes
                int original = x; // Store the original number for comparison
                int reversed = 0; // Initialize the reversed number
                // Reverse the digits of the number
                while (x > 0)
                {
                    int digit = x % 10; // Get the last digit
                    reversed = reversed * 10 + digit; // Append digit to the reversed number
                    x /= 10; // Remove the last digit from x
                }
                return original == reversed; // Check if the original number and reversed number are equal
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here
                if (n < 0 || n > 30)
                    throw new ArgumentOutOfRangeException("n must be between 0 and 30.");
                if (n == 0) return 0; // Base case for Fibonacci
                if (n == 1) return 1; // Base case for Fibonacci
                int a = 0, b = 1; // Initialize the first two Fibonacci numbers
                // Calculate Fibonacci iteratively
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b; // Calculate the next Fibonacci number
                    a = b; // Update a to the next number
                    b = temp; // Update b to the newly calculated number
                }
                return b;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
