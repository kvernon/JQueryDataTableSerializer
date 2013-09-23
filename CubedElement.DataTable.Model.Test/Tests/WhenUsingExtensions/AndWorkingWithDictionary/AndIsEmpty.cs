using System.Collections.Generic;
using CubedElement.DataTable.Contracts.Extensions;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingExtensions.AndWorkingWithDictionary
{
    [TestFixture]
    public class AndIsEmpty
    {
        [Test]
        public void ItShouldBeTrue()
        {
            IDictionary<string, bool> blah = new Dictionary<string, bool>();
            Assert.IsTrue(blah.IsNullOrEmpty());
        }
    }
}