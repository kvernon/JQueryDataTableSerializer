using System;
using System.Collections.Generic;
using CubedElement.DataTable.Model;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingRequestCollection
{
    public class BaseNothingCollection
    {
        private readonly Random _random;
        
        private string _expected;

        protected IDictionary<string, string> Collection;

        public BaseNothingCollection()
        {
            _random = new Random();
        }

        public virtual void SetUp()
        {
            var useNull = _random.Next(0, 1) == 1;

            _expected = useNull ? null : Guid.NewGuid().ToString();
        }

        [TearDown]
        public void TearDown()
        {
            _expected = null;
            Collection = null;
        }

        [Test]
        public void AndNoPatternItShouldBeMatch()
        {
            Assert.AreEqual(_expected, DataTableRequestCollection.GetValue(Collection, null, -1, _expected));
        }
        
        [Test]
        public void AndPatternItShouldBeMatch()
        {
            Assert.AreEqual(_expected, DataTableRequestCollection.GetValue(Collection, Guid.NewGuid().ToString(), -1, _expected));
        }
    }
}