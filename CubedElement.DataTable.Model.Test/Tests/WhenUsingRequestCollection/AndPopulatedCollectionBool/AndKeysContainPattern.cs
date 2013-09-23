using System;
using System.Collections.Generic;
using CubedElement.DataTable.Model;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingRequestCollection.AndPopulatedCollectionBool
{
    [TestFixture]
    public class AndKeysContainPattern
    {
        private readonly Random _random;
        
        private bool _defaultValue;

        private IDictionary<string, bool> _collection;

        private string _pattern;

        public AndKeysContainPattern()
        {
            _random = new Random();
        }

        [SetUp]
        public void SetUp()
        {
            _pattern = string.Format("{0}_", Guid.NewGuid());

            _collection = new Dictionary<string, bool>();

            for (var i = 0; i < _random.Next(1, 7); i++)
            {
                _collection.Add(KeyFormat(_pattern, i), _random.Next(0, 1) == 1);
            }

            _defaultValue = _random.Next(0, 1) == 1;

        }

        private static string KeyFormat(string pattern, int idx)
        {
            return string.Format("{0}{1}", pattern, idx);
        }

        [TearDown]
        public void TearDown()
        {
            _defaultValue = false;
            _collection = null;
            _pattern = null;
        }

        [Test]
        public void ItShouldFindMatch()
        {
            var index = _random.Next(0, _collection.Count);

            var expected = _collection[KeyFormat(_pattern, index)];

            Assert.AreEqual(expected, DataTableRequestCollection.GetValue(_collection, _pattern, index, _defaultValue), string.Format("you are looking for {0} at {1} which is {2}", _pattern, index, expected));
        }
    }
}