using CubedElement.DataTable.Contracts;
using CubedElement.DataTable.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace CubedElement.DataTable.Test.Tests.WhenUsingWrapper.AndItemsRequestIsEmpty.AndDataCollectionIsNull
{
    [TestFixture]
    public class AndDataPropertiesPlusEchoAreNull
    {
        private DataTableWrapper<IDataTableSerializer> _wrapper;

        private IDataTableRequestCollection _mockRequestData;

        [SetUp]
        public void SetUp()
        {
            _mockRequestData = MockRepository.GenerateMock<IDataTableRequestCollection>();
            _mockRequestData.Stub(x => x.Echo).Return(null);
            _mockRequestData.Stub(x => x.SerializeAsDataContract()).Return(false);

            _wrapper = new DataTableWrapper<IDataTableSerializer>(_mockRequestData, null);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRequestData = null;
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