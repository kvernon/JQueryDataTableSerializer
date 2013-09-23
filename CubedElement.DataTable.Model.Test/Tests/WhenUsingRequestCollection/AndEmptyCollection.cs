using System.Collections.Generic;
using NUnit.Framework;

namespace CubedElement.DataTable.Test.Tests.WhenUsingRequestCollection
{
    [TestFixture]
    public class AndEmptyCollection : BaseNothingCollection
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            Collection = new Dictionary<string, string>();
        }
    }
}