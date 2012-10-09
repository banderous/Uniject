using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using Tests;
using Testable;
using Moq;

namespace Tests {
    class TestModule : Ninject.Modules.NinjectModule {

        public override void Load () {
            Bind<ILayerMask> ().To<MockLayerMask> ();
            Bind<Testable.ITime> ().To<MockTime> ().InSingletonScope();

            Bind<ILogger>().To<TestLogger>();

            Bind<IAudioListener>().To<FakeAudioListener>();

            Bind<Testable.IRigidBody> ().To<FakeRigidBody> ().InScope(Scoping.GameObjectBoundaryScoper);
            Bind<Testable.INavmeshAgent> ().To<FakeNavmeshAgent> ().InScope(Scoping.GameObjectBoundaryScoper);
            Bind<ISphereCollider> ().To<FakeSphereCollider> ().InScope (Scoping.GameObjectBoundaryScoper);
            Bind<IAudioSource>().To<FakeAudioSource>().InScope(Scoping.GameObjectBoundaryScoper);

            Bind<Testable.IUtil>().To<MockUtil>().InSingletonScope();
            Bind<TestUpdatableManager>().ToSelf().InSingletonScope();

            Bind<IResourceLoader>().To<MockResourceLoader>().InSingletonScope();


            Bind<TestableGameObject>().To<FakeGameObject>().InScope(Scoping.GameObjectBoundaryScoper);
            Bind<ITransform>().To<FakeGameObject.FakeTransform>();
        }
    }
}
