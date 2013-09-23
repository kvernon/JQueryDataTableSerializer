using CubedElement.DataTable.Model.Constants;
using NUnit.Framework;


namespace CubedElement.DataTable.Test.Tests.WhenUsingConstants.AndDataItemCollectionNames
{
    [TestFixture]
    public class AndValidatingNames
    {
        [Test]
        public void MdataPropShouldMatch()
        {
            Assert.AreEqual(DataItemCollectionNames.MdataProp, "mDataProp_");
        }

        [Test]
        public void SSearchShouldMatch()
        {
            Assert.AreEqual(DataItemCollectionNames.SSearch, "sSearch_");
        }

        [Test]
        public void SSortColShouldMatch()
        {
            Assert.AreEqual(DataItemCollectionNames.SSortCol, "iSortCol_0");
        }
    }
}