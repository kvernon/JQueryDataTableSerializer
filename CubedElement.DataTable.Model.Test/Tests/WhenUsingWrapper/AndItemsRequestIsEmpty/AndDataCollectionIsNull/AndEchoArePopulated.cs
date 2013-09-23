using System;
using System.Globalization;
using CubedElement.DataTable.Contracts;
using CubedElement.DataTable.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace CubedElement.DataTable.Test.Tests.WhenUsingWrapper.AndItemsRequestIsEmpty.AndDataCollectionIsNull
{
    [TestFixture]
    public class AndEchoArePopulated
    {
        private DataTableWrapper<IDataTableSerializer> _wrapper;

        private IDataTableRequestCollection _mockRequestData;
        
        private readonly Random _random;

        private int _expectedEchoValue;

        public AndEchoArePopulated()
        {
            _random = new Random();
        }

        [SetUp]
        public void SetUp()
        {
            _expectedEchoValue = _random.Next(1, int.MaxValue);
            
            _mockRequestData = MockRepository.GenerateMock<IDataTableRequestCollection>();
            _mockRequestData.Stub(x => x.Echo).Return(_expectedEchoValue.ToString(CultureInfo.InvariantCulture));
            
            _wrapper = new DataTableWrapper<IDataTableSerializer>(_mockRequestData, null);
        }

        [TearDown]
        public void TearDown()
        {
            _mockRequestData = null;
            _wrapper = null;
            _expectedEchoValue = -999999999;
        }

        [Test]
        public void EchoShouldMatchNumeric()
        {
            Assert.AreEqual(_expectedEchoValue, _wrapper.Echo);
        }
    }
}