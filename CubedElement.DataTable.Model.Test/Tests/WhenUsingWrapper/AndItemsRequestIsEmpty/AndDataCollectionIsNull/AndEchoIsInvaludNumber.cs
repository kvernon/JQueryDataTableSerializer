using System;
using System.Collections.Generic;
using System.Globalization;
using CubedElement.DataTable.Contracts;
using CubedElement.DataTable.Model;
using NUnit.Framework;
using Rhino.Mocks;

namespace CubedElement.DataTable.Test.Tests.WhenUsingWrapper.AndItemsRequestIsEmpty.AndDataCollectionIsNull
{
    [TestFixture]
    public class AndEchoIsInvaludNumber
    {
        private DataTableWrapper<IDataTableSerializer> _wrapper;

        private IDataTableRequestCollection _mockRequestData;
        
        [SetUp]
        public void SetUp()
        {
            _mockRequestData = MockRepository.GenerateMock<IDataTableRequestCollection>();
            _mockRequestData.Stub(x => x.Echo).Return(Guid.NewGuid().ToString());
            
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
    }
}