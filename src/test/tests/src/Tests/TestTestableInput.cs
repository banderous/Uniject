using Moq;
using Ninject;
using NUnit.Framework;
using System;
using Testable;
using UnityEngine;

namespace Tests {
    public class TestTestableInput : BaseInjectedTest {

        private TestableInput scene;

        [SetUp]
        public void Setup() {
            scene = kernel.Get<TestableInput>();
        }

        [Test]
        public void testNoMovement() {
            Mock<IRigidBody> mockBody = Mock.Get(scene.sphere.body);
            step();
            mockBody.Verify(mock => mock.AddForce(It.IsAny<Vector3>()), Times.Never());
        }

        [Test]
        public void testMovementToRight() {
            mockInput.Setup(mock => mock.GetAxis("Horizontal")).Returns(1);

            Mock<IRigidBody> mockBody = Mock.Get(scene.sphere.body);
            step();
            mockBody.Verify(mock => mock.AddForce(It.Is<Vector3>(v => v.x > 0)), Times.Exactly(1));
        }
    }
}

