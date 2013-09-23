using CubedElement.DataTable.Contracts;
using CubedElement.DataTable.Model;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingWrapper.AndItemsRequestIsNull
{
    [TestFixture]
    public class AndDataCollectionIsNull
    {
        private DataTableWrapper<IDataTableSerializer> _wrapper;

        [SetUp]
        public void SetUp()
        {
            _wrapper = new DataTableWrapper<IDataTableSerializer>(null, null);
        }

        [TearDown]
        public void TearDown()
        {
            _wrapper = null;
        }

        [Test]
        public void EchoShouldBeNegOne()
        {
            Assert.AreEqual(-1, _wrapper.Echo);
        }

        [Test]
        public void ColumnsShouldBeEmpty()
        {
            Assert.AreEqual(string.Empty, _wrapper.Columns);
        }

        [Test]
        public void DataShouldBeEmpty()
        {
            Assert.AreEqual(new object[0], _wrapper.Data);
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