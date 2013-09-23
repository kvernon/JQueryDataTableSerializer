using System;
using System.Collections.Generic;
using CubedElement.DataTable.Contracts.Extensions;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingExtensions.AndWorkingWithDictionary
{
    [TestFixture]
    public class AndIsPopulated
    {
        [Test]
        public void ItShouldBeFalse()
        {
            IDictionary<string, bool> blah = new Dictionary<string, bool>();
            blah.Add(Guid.NewGuid().ToString(), true);
            Assert.IsFalse(blah.IsNullOrEmpty());
        }
    }
}