using System;
using System.Collections.Generic;
using System.IO;
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
            Assert.That(RecursionTasks.SumOfDigitsRecursive(number), Is.EqualTo(expected));
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
            Assert.That(RecursionTasks.IsPalindrome(str), Is.EqualTo(expected));
        }
        
        [TestCase("А роза упала на лапу Азора.", true)]
        [TestCase("A man, a plan, a canal, Panama!", true)]
        [TestCase("Сегодня отличная погода.", false)]
        [TestCase("The sun is shining brightly.", false)]
        public void IsPalindromeRecursiveWithLinkedListTest(string str, bool expected)
        {
            Assert.That(RecursionTasks.IsPalindromeWithLinkedList(str), Is.EqualTo(expected));
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
        [TestCase(new int[] {2, 1}, 1)]
        public void FindSecondMaxTest(int[] dataForList, int expected)
        {
            Assert.That(RecursionTasks.FindSecondMax(dataForList.ToList()), Is.EqualTo(expected));
        }

        [Test]
        public void FindAllFilesTest()
        {
            string testRootDirectory = Path.Combine(Path.GetTempPath(), "FileSearchTest");
            
            List<string> expectedFiles = CreateTestDirectoryStructure(testRootDirectory)
                .Select(fi => fi.Name)
                .OrderBy(name => name)
                .ToList();
            List<string> actualFiles = RecursionTasks.FindAllFiles(testRootDirectory)
                .Select(fi => fi.Name)
                .OrderBy(name => name)
                .ToList();
            
            Assert.That(actualFiles, Is.EquivalentTo(expectedFiles));
            
            Directory.Delete(testRootDirectory, true);
        }
        
        [Test]
        public void FindAllFilesRecursiveTest()
        {
            string testRootDirectory = Path.Combine(Path.GetTempPath(), "FileSearchTest");
            
            List<string> expectedFiles = CreateTestDirectoryStructure(testRootDirectory)
                .Select(fi => Path.Combine(fi.DirectoryName, fi.Name))
                .OrderBy(name => name)
                .ToList();

            List<string> actualFiles = RecursionTasks.FindAllFilesRecursive(testRootDirectory)
                .OrderBy(name => name)
                .ToList();
            
            Assert.That(actualFiles, Is.EquivalentTo(expectedFiles));
            
            Directory.Delete(testRootDirectory, true);
        }

        [TestCase(2, new string[] {"()()", "(())"})]
        [TestCase(3, new string[] {"((()))", "(()())", "(())()", "()(())", "()()()"})]
        public void GenerateBalancedBrackets(int count, string[] expected)
        {
            Assert.That(RecursionTasks.GenerateBalancedBrackets(count), Is.EquivalentTo(expected));
        }

        private List<FileInfo> CreateTestDirectoryStructure(string rootDirectory)
        {
            List<FileInfo> result = new List<FileInfo>();
            Directory.CreateDirectory(rootDirectory);

            // Уровень 1 
            result.Add(CreateTestTxtFile(rootDirectory, "root_file_1"));
            result.Add(CreateTestTxtFile(rootDirectory, "root_file_2"));
            
            string level1Dir1 = Path.Combine(rootDirectory, "Level1_Dir1");
            string level1Dir2 = Path.Combine(rootDirectory, "Level1_Dir2");
            Directory.CreateDirectory(level1Dir1);
            Directory.CreateDirectory(level1Dir2);

            // Уровень 2
            result.Add(CreateTestTxtFile(level1Dir1, "root_file_3"));
            result.Add(CreateTestTxtFile(level1Dir1, "root_file_4"));
            
            result.Add(CreateTestTxtFile(level1Dir2, "root_file_5"));
            result.Add(CreateTestTxtFile(level1Dir2, "root_file_6"));
            
            string level2Dir1 = Path.Combine(level1Dir1, "Level2_Dir1");
            string level2Dir2 = Path.Combine(level1Dir1, "Level2_Dir2");
            Directory.CreateDirectory(level2Dir1);
            Directory.CreateDirectory(level2Dir2);
            
            string level2Dir3 = Path.Combine(level1Dir2, "Level2_Dir3");
            string level2Dir4 = Path.Combine(level1Dir2, "Level2_Dir4");
            Directory.CreateDirectory(level2Dir3);
            Directory.CreateDirectory(level2Dir4);
            
            result.Add(CreateTestTxtFile(level2Dir1, "root_file_7"));
            result.Add(CreateTestTxtFile(level2Dir2, "root_file_8"));
            
            result.Add(CreateTestTxtFile(level2Dir3, "root_file_9"));
            result.Add(CreateTestTxtFile(level2Dir4, "root_file_10"));

            return result;
        }

        private FileInfo CreateTestTxtFile(string directory, string fileName)
        {
            string filePath = Path.Combine(directory, $"{fileName}.txt");
            File.WriteAllText(filePath, "");

            return new FileInfo(filePath);
        }
    }
}