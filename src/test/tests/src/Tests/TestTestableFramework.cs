using System;
using NUnit.Framework;
using Ninject;
using Testable;

namespace Tests {
    [TestFixture()]
    public class TestTestableFramework : BaseInjectedTest {

        [Testable.GameObjectBoundary]
        public class MockComponent : Testable.TestableComponent {
            public MockComponent(TestableGameObject obj) : base(obj) {
            }

            public int updateCount { get; private set; }
            
            public override void Update() {
                updateCount++;
            }
        }

        [Testable.GameObjectBoundary]
        public class HasGameObjectBoundaryAsParameter : Testable.TestableComponent {
            public MockComponent nested { get; private set; }
            public HasGameObjectBoundaryAsParameter(TestableGameObject obj, MockComponent nested) : base(obj) {
                this.nested = nested;
            }
        }

        [Test()]
        public void TestTestableComponentIsUpdated() {
            MockComponent component = kernel.Get<MockComponent>();

            Assert.AreEqual(0, component.updateCount);
            step(1);
            Assert.AreEqual(1, component.updateCount);
        }

        [Test]
        public void testNestedTopLevelGameObjectsGetDifferentGameObjects() {
            HasGameObjectBoundaryAsParameter foo = kernel.Get<HasGameObjectBoundaryAsParameter>();
            Assert.AreNotSame(foo.Obj, foo.nested.Obj);
        }

        [Test]
        public void testResources() {
            IResourceLoader loader = kernel.Get<IResourceLoader>();
            Assert.AreEqual("Hello World", loader.loadDoc("test").Element("element").Value);
        }

        [Test]
        public void testLayerMasksInterpreted() {
            ILayerMask layerMask = kernel.Get<ILayerMask>();
            Assert.AreEqual(0, layerMask.NameToLayer("Default"));
        }
    }
}


