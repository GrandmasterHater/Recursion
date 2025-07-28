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
            Assert.That(RecursionTasks.RecursivePower(number, power), Is.EqualTo(expected));
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
            Assert.That(RecursionTasks.LengthOfListRecursive(array.ToList()), Is.EqualTo(expectedCount));
        }
        
        [TestCase("А роза упала на лапу Азора.", true)]
        [TestCase("A man, a plan, a canal, Panama!", true)]
        [TestCase("Сегодня отличная погода.", false)]
        [TestCase("The sun is shining brightly.", false)]
        public void IsPalindromeRecursiveTest(string str, bool expected)
        {
            Assert.That(RecursionTasks.IsPalindromeRecursive(str), Is.EqualTo(expected));
        }
    }
}