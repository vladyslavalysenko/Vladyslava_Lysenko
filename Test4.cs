using NUnit.Framework;

namespace Task4
{
    public class Tests
    {
        public int getPairsCount(int[] arr, int sum)
        {
            int count = 0; 
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if ((arr[i] + arr[j]) == sum)
                        count++;
            return count;
        }

        [Test]
        public void Test1()
        {
            int[] arr = { 1, 3, 6, 2, 2, 0, 4, 5 };
            int c = getPairsCount(arr, 5);
            Assert.That(c, Is.EqualTo(4));
        }
        [Test]
        public void Test2()
        {
            int[] arr = { 1, 5, 7, -1, 5 };
            int c = getPairsCount(arr, 6);
            Assert.That(c, Is.EqualTo(3));
        }
    }
}