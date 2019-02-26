using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Battleship
{
    [TestFixture()]
    public class PositionTest
    {
        [Test()]
        public void TestGetMiddlePositions()
        {
            IList<int> result = new List<int>();
            result = Position.GetMiddlePositions(1, 1, 4, 1);

            Assert.AreEqual(result.Count, 2);

        }
    }
}
