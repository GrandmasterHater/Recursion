using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Recursion
{
    public static class RecursionTasks
    {
        //1. Возведение числа N в степень M;
        public static long RecursivePower(long number, uint power, long currentNumber = 1)
        {
            if (power == 0)
                return currentNumber;
            
            return RecursivePower(number, power - 1, currentNumber * number);
        }
        
        //2. Вычисление суммы цифр числа;
        public static long SumOfDigitsRecursive(long number, long numbersSum = 0)
        {
            if (number == 0)
                return numbersSum;
            
            return SumOfDigitsRecursive(number / 10, numbersSum + (number % 10));
        }
        
        //3. Расчёт длины списка, для которого разрешена только операция удаления первого элемента pop(0) (и получение длины конечно);
        public static int LengthOfListRecursive(List<int> list, int count = 0)
        {
            if (list.Count == 0)
                return count;
            
            list.RemoveAt(0);
            
            return LengthOfListRecursive(list, ++count);
        }
        
        //4. Проверка, является ли строка палиндромом;
        public static bool IsPalindrome(string str)
        {
            string filteredString = Regex.Replace(str, "[^a-zA-Zа-яА-Я0-9]", "").ToLower();
            return IsPalindromeRecursive(filteredString, 0);
        }
        
        private static bool IsPalindromeRecursive(string str, int index)
        {
            int lastIndex = str.Length - 1 - index;

            if (index >= lastIndex)
                return true;
            
            if (str[index] != str[lastIndex])
                return false;

            return IsPalindromeRecursive(str, ++index);
        }
        
        public static bool IsPalindromeWithLinkedList(string str)
        {
            LinkedList<char> lettersAndDigits = new LinkedList<char>();
            FilterLowerLetterAndDigitsRecursive(str, lettersAndDigits, 0);
            return IsPalindromeRecursive(lettersAndDigits);
        }
        
        private static void FilterLowerLetterAndDigitsRecursive(string str, LinkedList<char> lettersAndDigits, int strIndex)
        {
            if (strIndex >= str.Length)
                return;

            if (char.IsLetterOrDigit(str[strIndex]))
                lettersAndDigits.AddLast(char.ToLower(str[strIndex]));
            
            FilterLowerLetterAndDigitsRecursive(str, lettersAndDigits, ++strIndex);
        }

        private static bool IsPalindromeRecursive(LinkedList<char> str)
        {
            if (str.Count <= 1)
                return true;

            if (str.First.Value != str.Last.Value)
                return false;
            
            str.RemoveFirst();
            str.RemoveLast();

            return IsPalindromeRecursive(str);
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
        
        private static void PrintOnlyEvenIndexesRecursive(List<int> list, int currentIndex, List<int> result)
        {
            const int EVEN_INDEX_STEP = 2;
            
            if (currentIndex >= list.Count)
                return;
            
            result.Add(list[currentIndex]);
            
            PrintOnlyEvenIndexesRecursive(list, currentIndex + EVEN_INDEX_STEP, result);
        }
        
        //7. нахождение второго максимального числа в списке;
        public static T FindSecondMax<T>(List<T> list) where T : IComparable
        {
            T max = default;
            T secondMax = default;
            
            if (list[0].CompareTo(list[1]) > 0)
            {
                max = list[0];
                secondMax = list[1];
            }
            else
            {
                max = list[1];
                secondMax = list[0];
            }
            
            const int START_INDEX = 2;
            
            return FindSecondMaxRecursive(list, START_INDEX, max, secondMax);
        }
        
        private static T FindSecondMaxRecursive<T>(List<T> list, int currentIndex, T max, T secondMax) where T : IComparable
        {
            if (currentIndex >= list.Count)
                return secondMax;
            
            T currentNumber = list[currentIndex];

            if (currentNumber.CompareTo(max) > 0)
            {
                secondMax = max;
                max = currentNumber;
            }
            else if (currentNumber.CompareTo(secondMax) > 0)
            {
                secondMax = currentNumber;
            }
                
            return FindSecondMaxRecursive(list, ++currentIndex, max, secondMax);
        }
        
        //8. поиск всех файлов в заданном каталоге, включая файлы, расположенные в подкаталогах произвольной вложенности.
        public static List<FileInfo> FindAllFiles(string path)
        {
            List<FileInfo> foundFiles = new List<FileInfo>();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FindAllFilesRecursive(new DirectoryInfo[] {directoryInfo}, 0, foundFiles);

            return foundFiles;
        }
        
        private static void FindAllFilesRecursive(DirectoryInfo[] directoryInfos, int index, List<FileInfo> foundFiles)
        {
            if (index >= directoryInfos.Length)
                return;

            DirectoryInfo directoryInfo = directoryInfos[index];
            
            foundFiles.AddRange(directoryInfo.GetFiles());

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            
            if (subDirectories.Length > 0)
                FindAllFilesRecursive(subDirectories, 0, foundFiles);
            
            FindAllFilesRecursive(directoryInfos, index + 1, foundFiles);
        }
        
        //8. поиск всех файлов в заданном каталоге, включая файлы, расположенные в подкаталогах произвольной вложенности.
        public static void FindAllFilesRecursive(string[] path, int index, List<string> foundFiles)
        {
            if (index >= path.Length)
                return;
            
            string directoryPath = path[index];
            
            foundFiles.AddRange(Directory.GetFiles(directoryPath));

            string[] subDirectories = Directory.GetDirectories(directoryPath);
            
            if (subDirectories.Length > 0)
                FindAllFilesRecursive(subDirectories, 0, foundFiles);
            
            FindAllFilesRecursive(path, index + 1, foundFiles);
        }
        
        //Генерация всех корректных сбалансированных комбинаций круглых скобок (параметр -- количество открывающих скобок).
        public static string[] GenerateBalancedBrackets(int countOpeningBrackets)
        {
            StringBuilder initialCombination = new StringBuilder("(");
            List<StringBuilder> combinations = new List<StringBuilder>() {initialCombination};
            GenerateBalancedBracketsRecursive(initialCombination, combinations, countOpeningBrackets - 1, countOpeningBrackets);
            return combinations.Select(sb => sb.ToString()).ToArray();
        }

        private static void GenerateBalancedBracketsRecursive(StringBuilder combination, List<StringBuilder> combinations, int countOpeningBrackets, int countClosingBrackets)
        {
            if (countOpeningBrackets == 0 && countClosingBrackets == 0)
                return;
            
            if (countOpeningBrackets > 0 && countOpeningBrackets < countClosingBrackets)
            {
                StringBuilder newCombination = new StringBuilder(combination.ToString());
                combination.Append('(');
                GenerateBalancedBracketsRecursive(combination, combinations, countOpeningBrackets - 1, countClosingBrackets);
                
                newCombination.Append(")");
                combinations.Add(newCombination);
                GenerateBalancedBracketsRecursive(newCombination, combinations, countOpeningBrackets, countClosingBrackets - 1);
            }
            else if (countOpeningBrackets > 0 && countOpeningBrackets == countClosingBrackets)
            {
                combination.Append("(");
                GenerateBalancedBracketsRecursive(combination, combinations, countOpeningBrackets - 1, countClosingBrackets);
            }
            else
            {
                combination.Append(")");
                GenerateBalancedBracketsRecursive(combination, combinations, countOpeningBrackets, countClosingBrackets - 1);
            }
        }
    }
}