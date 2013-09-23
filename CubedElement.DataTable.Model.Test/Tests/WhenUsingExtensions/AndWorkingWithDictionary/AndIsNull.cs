using System.Collections.Generic;
using CubedElement.DataTable.Contracts.Extensions;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingExtensions.AndWorkingWithDictionary
{
    [TestFixture]
    public class AndIsNull
    {
        [Test]
        public void ItShouldBeTrue()
        {
            IDictionary<string, bool> blah = null;
            Assert.IsTrue(blah.IsNullOrEmpty());
        }
    }
}