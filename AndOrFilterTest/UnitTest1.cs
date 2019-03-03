using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Filter.AndOrFilter;
using AndOrFilterTest.Class;
using System.Linq;

namespace AndOrFilterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string FILTER_STRING = "田中|次&郎";
            Console.WriteLine($"検索文字列：{FILTER_STRING}");

            var users = new Users();
            var andor = new AndOrFilter<User>(users.Data, (x, y) => x.FirstName == y || x.LastName == y, FILTER_STRING);
            andor.Filter();
            foreach (var item in andor.Result)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
