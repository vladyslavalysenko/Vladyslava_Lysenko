using NUnit.Framework;
using System.Collections.Generic;

namespace Task1
{
    public class Tests
    {
        public List<int> GetIntegersFromList(List<object> oldList)
        {
            var filteredList = new List<int>();
            foreach (var i in oldList)
            {
                if (i.GetType() == typeof(int))
                {
                    filteredList.Add((int)i);
                }
            }
            return filteredList;
        }

        [Test]
        public void Test1()
        {
            List<int> res = GetIntegersFromList(new List<object>() { 'a', 'b' });
            Assert.That(res, Is.EqualTo(new List<int>() { }));
        }
        [Test]
        public void Test2()
        {
            List<int> res = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', 0, 15 });
            Assert.That(res, Is.EqualTo(new List<int>() { 1, 2, 0, 15 }));
        }
    }
}
