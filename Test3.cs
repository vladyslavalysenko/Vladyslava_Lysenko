using NUnit.Framework;
using System.Collections.Generic;

namespace Task3
{
    public class Tests
    {
        public int SumOfDigits(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }
        public int NSumOfDigits(int n)
        {
            while(n > 10)
            {
                n = SumOfDigits(n);
            }
            return n;
        }

        [Test]
        public void Test1()
        {
            int n = 123;
            int sum= NSumOfDigits(n);
            Assert.That(sum, Is.EqualTo(6)); 
        }
        [Test]
        public void Test2()
        {
            int n = 0;
            int sum = NSumOfDigits(n);
            Assert.That(sum, Is.EqualTo(0));
        }
    }
}