﻿using System;
using System.Collections.Generic;
using CubedElement.DataTable.Model;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingRequestCollection.AndPopulatedCollectionString
{
    [TestFixture]
    public class AndKeysDoNotContainPattern
    {
        private readonly Random _random;
        
        private string _defaultValue;

        private IDictionary<string, string> _collection;

        private string _pattern;

        public AndKeysDoNotContainPattern()
        {
            _random = new Random();
        }

        [SetUp]
        public void SetUp()
        {
            _pattern = string.Format("{0}_", Guid.NewGuid());

            _collection = new Dictionary<string, string>();

            for (var i = 0; i < _random.Next(0, 7); i++)
            {
                _collection.Add(KeyFormat(Guid.NewGuid().ToString("N"), i), Guid.NewGuid().ToString());
            }

            var useNull = _random.Next(0, 1) == 1;

            _defaultValue = useNull ? null : Guid.NewGuid().ToString();

        }

        private static string KeyFormat(string pattern, int idx)
        {
            return string.Format("{0}{1}", pattern, idx);
        }

        [TearDown]
        public void TearDown()
        {
            _defaultValue = null;
            _collection = null;
            _pattern = null;
        }

        [Test]
        public void ItShouldNotFindMatch()
        {
            var index = _random.Next(0, _collection.Count);

            Assert.AreEqual(_defaultValue, DataTableRequestCollection.GetValue(_collection, _pattern, index, _defaultValue));
        }
    }
}