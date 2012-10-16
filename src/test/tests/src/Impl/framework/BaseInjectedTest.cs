using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Ninject;

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
            return new StandardKernel (new UnityModule(), getModule());
        }

        protected virtual Ninject.Modules.NinjectModule getModule() {
            return new TestModule();
        }

        protected MockUtil getUtilInstance() {
            return (MockUtil) kernel.Get<Testable.IUtil>();
        }

        private object getScope(Ninject.Activation.IContext context) {
            return sceneScope;
        }
    }
}
