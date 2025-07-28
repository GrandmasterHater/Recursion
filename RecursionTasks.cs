using System.Collections.Generic;

namespace Recursion
{
    public static class RecursionTasks
    {
        //1. Возведение числа N в степень M;
        public static long RecursivePower(long number, uint power)
        {
            long ZERO_POWER_RESULT = 1;
            return power > 0 ? number * RecursivePower(number, power - 1) : ZERO_POWER_RESULT;
        }
        
        //2. Вычисление суммы цифр числа;
        public static long SumOfDigits(long number)
        {
            return number > 0 ? number % 10 + SumOfDigits(number / 10) : 0;
        }
        
        //3. Расчёт длины списка, для которого разрешена только операция удаления первого элемента pop(0) (и получение длины конечно);
        public static int LengthOfListRecursive(List<int> list)
        {
            if (list.Count > 0)
            {
                list.RemoveAt(0);
                return 1 + LengthOfListRecursive(list);
            }
            
            return 0;
        }
        
        //4. Проверка, является ли строка палиндромом;
        public static bool IsPalindromeRecursive(string str)
        {
            if (str.Length <= 1)
                return true;
            
            char firstChar = str[0];
            char lastChar = str[str.Length - 1];
            bool isFirstCharLetterOrDigit = char.IsLetterOrDigit(firstChar);
            bool isLastCharLetterOrDigit = char.IsLetterOrDigit(lastChar);
            
            if (isFirstCharLetterOrDigit && isLastCharLetterOrDigit)
            {
                return char.ToLower(firstChar) == char.ToLower(lastChar) && IsPalindromeRecursive(str.Substring(1, str.Length - 2));
            }
            
            int startIndex = isFirstCharLetterOrDigit ? 0 : 1;
            int length = isFirstCharLetterOrDigit ? str.Length : str.Length - 1;
            length = isLastCharLetterOrDigit ? length : length - 1;

            return IsPalindromeRecursive(str.Substring(startIndex, length));
        }
    }
}