using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Game;
using UnityEngine;
using System.Net;
using System.IO;

namespace LS3Test {
    [TestFixture()]
    public class TestMyMath {

        [Test]
        public void TestRange() {
            LSAssert.AreEqual<int>(-1, MyMath.limitRange(-1, 2, -3));
            LSAssert.AreEqual<int>(2, MyMath.limitRange(-1, 2, 3));
        }

        [Test]
        public void testVec3() {
            Assert.AreEqual(100, Vector3.Distance(Vector3.zero, new Vector3(100, 0, 0)));
        }

        [Test]
        public void testZeroPathLength() {
            Assert.AreEqual(0, MyMath.getSquaredLength(new Vector3[] { }));
        }

        [Test]
        public void testInvalidSinglePointPathLength() {
            Assert.AreEqual(0, MyMath.getSquaredLength(new Vector3[] {Vector3.one }));
        }

        [Test]
        public void testSingleSegmentPathLength() {
            Assert.AreEqual(1, MyMath.getSquaredLength(new Vector3[] {Vector3.zero, new Vector3(1, 0, 0)}));
        }

        [Test]
        public void testTwoSegmentPathLength() {
            Assert.AreEqual(2, MyMath.getSquaredLength(new Vector3[] { Vector3.zero, new Vector3(1, 0, 0), Vector3.zero }));
        }

        [Test]
        public void testTwoSegmentPathLengthB() {
            Assert.AreEqual(5, MyMath.getSquaredLength(new Vector3[] { Vector3.zero, new Vector3(1, 0, 0), new Vector3(3, 0, 0) }));
        }

        [Test]
        public void testBar() {
            WebClient client = new WebClient();
            string message = new StreamReader(client.OpenRead("http://www.google.co.uk")).ReadToEnd();
            Console.Error.WriteLine(message);

        }
    }
}
