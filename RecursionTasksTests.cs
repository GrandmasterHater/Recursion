using System.Linq;
using NUnit.Framework;

namespace Recursion
{
    [TestFixture]
    public class RecursionTasksTests
    {
        [TestCase(2L, 3U, 8L)]
        [TestCase(3L, 3U, 27L)]
        public void RecursivePowerTest(long number, uint power, long expected)
        {
            Assert.That(RecursionTasks.Power(number, power), Is.EqualTo(expected));
        }
        
        [TestCase(123, 6)]
        [TestCase(777, 21)]
        public void SumOfDigitsTest(long number, long expected)
        {
            Assert.That(RecursionTasks.SumOfDigits(number), Is.EqualTo(expected));
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 9)]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 10)]
        public void LengthOfListRecursiveTest(int[] array, int expectedCount)
        {
            Assert.That(RecursionTasks.LengthOfList(array.ToList()), Is.EqualTo(expectedCount));
        }
        
        [TestCase("А роза упала на лапу Азора.", true)]
        [TestCase("A man, a plan, a canal, Panama!", true)]
        [TestCase("Сегодня отличная погода.", false)]
        [TestCase("The sun is shining brightly.", false)]
        public void IsPalindromeRecursiveTest(string str, bool expected)
        {
            Assert.That(RecursionTasks.IsPalindrome(str), Is.EqualTo(expected));
        }
        
        [TestCase(new int[] {1, 2, 3, 4, 5, 6}, new int[] {2, 4, 6})]
        [TestCase(new int[] {2, 4, 6, 8, 10, 12}, new int[] {2, 4, 6, 8, 10, 12})]
        [TestCase(new int[] {1, 3, 5, 7, 9}, new int[] {})]
        public void PrintOnlyEvenNumbersRecursiveTest(int[] dataForList, int[] expected)
        {
            Assert.That(RecursionTasks.PrintOnlyEvenNumbers(dataForList.ToList()), Is.EqualTo(expected.ToList()));
        }
        
        [TestCase(new int[] {1, 2, 3, 4, 5, 6}, new int[] {1, 3, 5})]
        [TestCase(new int[] {2, 4, 6, 8, 10, 12}, new int[] {2, 6, 10})]
        public void PrintOnlyEvenIndexesRecursiveTest(int[] dataForList, int[] expected)
        {
            Assert.That(RecursionTasks.PrintOnlyEvenIndexes(dataForList.ToList()), Is.EqualTo(expected.ToList()));
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6}, 5)]
        [TestCase(new int[] {3, 2, 7, 4, 5, 10}, 7)]
        [TestCase(new int[] {8, 8, 7, 5, 3, 1}, 8)]
        [TestCase(new int[] {1, 3, 5, 7, 8, 8}, 8)]
        [TestCase(new int[] {1, 2}, 1)]
        [TestCase(new int[] {2,1}, 1)]
        public void FindSecondMaxTest(int[] dataForList, int expected)
        {
            Assert.That(RecursionTasks.FindSecondMax(dataForList.ToList()), Is.EqualTo(expected));
        }
    }
}