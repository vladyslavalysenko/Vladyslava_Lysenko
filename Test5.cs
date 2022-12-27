using Microsoft.VisualBasic;
using NUnit.Framework;
using System;
using System.Linq;

namespace Task5
{
    public class Tests
    {
        public string Meeting(string s)
        {
            return s
                    .ToUpperInvariant()
                    .Split(';')
                    .Select(n => n.Split(':'))
                    .OrderBy(n => n[1]).ThenBy(n => n[0])
                    .Select(n => $"({n[1]}, {n[0]})")
                    .Aggregate((a, b) => $"{a}{b}");
        }

        [Test]
        public void Test1()
        {
            string s = "Fired:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            string m = Meeting(s);
            Assert.That(m, Is.EqualTo("(CORWILL, ALFRED)(CORWILL, FIRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"));
        }
        [Test]
        public void Test2()
        {
            string s = "Victoria:Thorensen;Ann:Arno;Alexis:Wahl;Emily:Stan;Anna:STAN;Jacob:Korn;Sophia:Gates;Amber:Kern";
            string m = Meeting(s);
            Assert.That(m, Is.EqualTo("(ARNO, ANN)(GATES, SOPHIA)(KERN, AMBER)(KORN, JACOB)(STAN, ANNA)(STAN, EMILY)(THORENSEN, VICTORIA)(WAHL, ALEXIS)"));
        }
    }
}