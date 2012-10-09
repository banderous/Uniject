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

        [SetUp]
        public void setup() {
            kernel = createNewKernel();
            sceneScope = new object();
        }

        protected void step(int frames) {
            kernel.Get<TestUpdatableManager>().step(frames);
        }

        protected IKernel createNewKernel() {
            return new StandardKernel (getModule(), new Game.GameModule(getScope));
        }

        protected virtual Ninject.Modules.NinjectModule getModule() {
            return new TestModule(false);
        }

        protected MockUtil getUtilInstance() {
            return (MockUtil) kernel.Get<Testable.IUtil>();
        }

        private object getScope(Ninject.Activation.IContext context) {
            return sceneScope;
        }
    }
}
