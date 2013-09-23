using System.Collections.Generic;
using CubedElement.DataTable.Contracts;
using CubedElement.DataTable.Model;
using CubedElement.DataTable.Test.Helpers;
using NUnit.Framework;
using Rhino.Mocks;

namespace CubedElement.DataTable.Test.Tests.WhenUsingWrapper.AndItemsRequestPopulated.AndDataCollectionPopulated
{
    [TestFixture]
    public class AndDataPropertiesEmpty
    {
        private DataTableWrapper<IDataTableSerializer> _wrapper;

        private IDataTableRequestCollection _mockRequestData;

        private IList<IDataTableSerializer> _dataTableSerializers;

        [SetUp]
        public void SetUp()
        {
            _mockRequestData = MockRepository.GenerateMock<IDataTableRequestCollection>();
            _mockRequestData.Stub(x => x.SerializeAsDataContract()).Return(false);

            _dataTableSerializers = DataCollection.GenerateCollection();

            _wrapper = new DataTableWrapper<IDataTableSerializer>(_mockRequestData, _dataTableSerializers);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRequestData = null;
            _wrapper = null;
        }

        [Test]
        public void ColumnsShouldBeEmpty()
        {
            var expected = string.Empty;

            for (var index = 0; index < _dataTableSerializers[0].ColumnNames().Count; index++)
            {
                var columnName = _dataTableSerializers[0].ColumnNames()[index];
                expected += columnName + (index == _dataTableSerializers[0].ColumnNames().Count - 1 ? string.Empty : ",");
            }

            Assert.AreEqual(expected, _wrapper.Columns);
        }

        [Test]
        public void DataShouldBePopulated()
        {
            Assert.AreEqual(_dataTableSerializers.Count, _wrapper.Data.Length);
        }
    }
}