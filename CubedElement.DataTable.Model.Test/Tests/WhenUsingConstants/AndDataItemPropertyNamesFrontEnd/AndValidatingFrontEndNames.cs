using CubedElement.DataTable.Model.Constants;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingConstants.AndDataItemPropertyNamesFrontEnd
{
    [TestFixture]
    public class AndValidatingFrontEndNames
    {
        [Test]
        public void ArrayDataShouldMatch()
        {
            Assert.AreEqual(DataItemPropertyNamesFrontEnd.ArrayData, "aaData");
        }
        
        [Test]
        public void ColumnsShouldMatch()
        {
            Assert.AreEqual(DataItemPropertyNamesFrontEnd.Columns, "sColumns");
        }

        [Test]
        public void EchoShouldMatch()
        {
            Assert.AreEqual(DataItemPropertyNamesFrontEnd.Echo, "sEcho");
        }
        
        [Test]
        public void TotalDisplayRecordsShouldMatch()
        {
            Assert.AreEqual(DataItemPropertyNamesFrontEnd.TotalDisplayRecords, "iTotalDisplayRecords");
        }
        
        [Test]
        public void TotalRecordsShouldMatch()
        {
            Assert.AreEqual(DataItemPropertyNamesFrontEnd.TotalRecords, "iTotalRecords");
        }

        [Test]
        public void DataTableSerializerShouldMatch()
        {
            Assert.AreEqual(DataItemPropertyNamesFrontEnd.DataTableWrapper, "dataTableSerializer");
        }
    }
}