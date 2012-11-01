using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Ninject;
using Uniject.Impl;

namespace Tests {

    public class BaseInjectedTest {

        protected IKernel kernel;

        protected object sceneScope;
        private TestUpdatableManager mgr;

        [SetUp]
        public void setup() {
            kernel = createNewKernel();
            sceneScope = new object();
            mgr = kernel.Get<TestUpdatableManager>();
        }

        protected void step() {
            step(1);
        }

        protected void step(int frames) {
            mgr.step(frames);
        }

        protected int objectCount {
            get {
                return mgr.Count;
            }
        }

        protected IKernel createNewKernel() {
            mockInput = new Moq.Mock<Uniject.IInput>();
            return new StandardKernel (new UnityModule(), new TestModule(mockInput.Object), new LateBoundModule());
        }

        protected Moq.Mock<Uniject.IInput> mockInput;

        protected MockUtil getUtilInstance() {
            return (MockUtil) kernel.Get<Uniject.IUtil>();
        }

        private object getScope(Ninject.Activation.IContext context) {
            return sceneScope;
        }
    }
}
