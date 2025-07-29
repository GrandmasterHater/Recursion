using System;
using System.Collections.Generic;

namespace Recursion
{
    public static class RecursionTasks
    {
        //1. Возведение числа N в степень M;
        public static long Power(long number, uint power)
        {
            return RecursivePower(1, number, power);
        }

        private static long RecursivePower(long currentNumber, long number, uint power)
        {
            if (power == 0)
                return currentNumber;
            
            return RecursivePower(currentNumber * number, number, power - 1);
        }
        
        //2. Вычисление суммы цифр числа;
        public static long SumOfDigits(long number)
        {
            return SumOfDigitsRecursive(0, number);
        }
        
        private static long SumOfDigitsRecursive(long numbersSum, long number)
        {
            if (number == 0)
                return numbersSum;
            
            return SumOfDigitsRecursive(numbersSum + (number % 10), number / 10);
        }
        
        //3. Расчёт длины списка, для которого разрешена только операция удаления первого элемента pop(0) (и получение длины конечно);
        public static int LengthOfList(List<int> list)
        {
            return LengthOfListRecursive(list, 0);
        }
        
        private static int LengthOfListRecursive(List<int> list, int count)
        {
            if (list.Count == 0)
                return count;
            
            list.RemoveAt(0);
            return LengthOfListRecursive(list, ++count);
        }
        
        //4. Проверка, является ли строка палиндромом;
        public static bool IsPalindrome(string str)
        {
            return IsPalindromeRecursive(str, 0, str.Length - 1);
        }

        private static bool IsPalindromeRecursive(string str, int firstIndex, int lastIndex)
        {
            if (firstIndex >= lastIndex)
                return true;
            
            char firstChar = str[firstIndex];
            char lastChar = str[lastIndex];
            bool isFirstCharLetterOrDigit = char.IsLetterOrDigit(firstChar);
            bool isLastCharLetterOrDigit = char.IsLetterOrDigit(lastChar);
            
            if (isFirstCharLetterOrDigit && isLastCharLetterOrDigit)
            {
                return char.ToLower(firstChar) == char.ToLower(lastChar) && IsPalindromeRecursive(str, ++firstIndex, --lastIndex);
            }
            
            firstIndex = isFirstCharLetterOrDigit ? firstIndex : ++firstIndex;
            lastIndex = isLastCharLetterOrDigit ? lastIndex : --lastIndex;

            return IsPalindromeRecursive(str, firstIndex, lastIndex);
        }
        
        //5. печать только чётных значений из списка;
        public static List<int> PrintOnlyEvenNumbers(List<int> list)
        {
            List<int> result = new List<int>();
            PrintOnlyEvenNumbersRecursive(list, 0, result);
            return result;
        }
        
        public static void PrintOnlyEvenNumbersRecursive(List<int> list, int currentIndex, List<int> result)
        {
            if (currentIndex >= list.Count)
                return;
            
            if (list[currentIndex] % 2 == 0)
                result.Add(list[currentIndex]);
            
            PrintOnlyEvenNumbersRecursive(list, ++currentIndex, result);
        }
        
        //6. печать элементов списка с чётными индексами;
        public static List<int> PrintOnlyEvenIndexes(List<int> list)
        {
            List<int> result = new List<int>();
            PrintOnlyEvenIndexesRecursive(list, 0, result);
            return result;
        }
        
        public static void PrintOnlyEvenIndexesRecursive(List<int> list, int currentIndex, List<int> result)
        {
            if (currentIndex >= list.Count)
                return;
            
            if (currentIndex % 2 == 0)
                result.Add(list[currentIndex]);
            
            PrintOnlyEvenIndexesRecursive(list, ++currentIndex, result);
        }
        
        //7. нахождение второго максимального числа в списке;
        public static int FindSecondMax(List<int> list)
        {
            return FindSecondMaxRecursive(list, 0, int.MinValue, int.MinValue);
        }
        
        private static int FindSecondMaxRecursive(List<int> list, int currentIndex, int max, int secondMax)
        {
            if (currentIndex >= list.Count)
                return secondMax;
            
            int currentNumber = list[currentIndex];

            if (currentNumber > max)
            {
                secondMax = max;
                max = currentNumber;
            }
            else if (currentNumber > secondMax)
            {
                secondMax = currentNumber;
            }
                
            return FindSecondMaxRecursive(list, ++currentIndex, max, secondMax);
        }
    }
}