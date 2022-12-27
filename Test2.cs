using NUnit.Framework;
using System;

namespace Task2
{
    public class Tests
    {
        public static char findFirstNonRepetitiveChar(string input)
        {
            char c = '0';
            for (int i = 0; i < input.Length; i++)
            {
                bool isDistinct = true;
                for (int j = 0; j < input.Length; j++)
                {
                    if ((input[i] == input[j] && i != j) || (Char.ToUpper(input[i]) == Char.ToUpper(input[j]) && i != j))
                    {
                        isDistinct = false;
                        break;
                    }
                }
                if (isDistinct)
                {
                    c = input[i];
                    break;
                }
            }
            return c;
        }

        [Test]
        public void Test1()
        {
            string str = "stress";
            char c = findFirstNonRepetitiveChar(str);
            Assert.That(c, Is.EqualTo('t'));
        }

        [Test]
        public void Test2()
        {
            string str = "aacmcnual";
            char c = findFirstNonRepetitiveChar(str);
            Assert.That(c, Is.EqualTo('m'));
        }
    }
}