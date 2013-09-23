using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingRequestCollection
{
    [TestFixture]
    public class AndNoCollection : BaseNothingCollection
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            Collection = null;
        }
    }
}