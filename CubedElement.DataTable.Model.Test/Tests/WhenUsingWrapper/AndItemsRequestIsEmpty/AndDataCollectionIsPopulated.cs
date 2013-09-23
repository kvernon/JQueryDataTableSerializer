using System;
using System.Collections.Generic;
using CubedElement.DataTable.Contracts;
using CubedElement.DataTable.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace CubedElement.DataTable.Test.Tests.WhenUsingWrapper.AndItemsRequestIsEmpty
{
    [TestFixture]
    public class AndDataCollectionIsPopulated
    {
        private DataTableWrapper<IDataTableSerializer> _wrapper;

        private IDataTableSerializer _mockItem;

        private IList<string> _columnNames;

        private object[] _expectedValuesArray;

        [SetUp]
        public void SetUp()
        {
            _columnNames = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            _expectedValuesArray = new object[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            
            _mockItem = MockRepository.GenerateMock<IDataTableSerializer>();
            _mockItem.Stub(x => x.ColumnNames()).Return(_columnNames); // property name
            _mockItem.Stub(x => x.ToObjectArray()).Return(_expectedValuesArray); // properties value

            _wrapper = new DataTableWrapper<IDataTableSerializer>(null, new List<IDataTableSerializer>{ _mockItem });
        }

        [TearDown]
        public void TearDown()
        {
            _mockItem = null;
            _columnNames = null;
            _expectedValuesArray = null;
            _wrapper = null;
        }

        [Test]
        public void EchoShouldBeNegOne()
        {
            Assert.AreEqual(-1, _wrapper.Echo);
        }

        [Test]
        public void ColumnsShouldBePopulated()
        {
            var expected = string.Empty;

            for (var index = 0; index < _columnNames.Count; index++)
            {
                var columnName = _columnNames[index];
                expected += columnName + (index == _columnNames.Count -1 ? string.Empty : ",");
            }

            Assert.AreEqual(expected, _wrapper.Columns);
        }

        [Test]
        public void DataShouldBePopulatedAndWrappedInAnObjectArray()
        {
            var expectedReturnedArray = new object[]{_expectedValuesArray};
            Assert.AreEqual(expectedReturnedArray, _wrapper.Data);
        }

        [Test]
        public void TotalDisplayRecordsShouldBeZero()
        {
            Assert.AreEqual(0, _wrapper.TotalDisplayRecords);
        }

        [Test]
        public void TotalDisplayShouldBeZero()
        {
            Assert.AreEqual(0, _wrapper.TotalRecords);
        }
    }
}