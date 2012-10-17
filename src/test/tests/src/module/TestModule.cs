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
            Rebind<ILayerMask>().To<MockLayerMask>();
            Rebind<Testable.ITime> ().To<MockTime> ().InSingletonScope();
            Rebind<ILogger>().To<TestLogger>();
            Rebind<IAudioListener>().To<FakeAudioListener>();
            Rebind<Testable.INavmeshAgent> ().To<FakeNavmeshAgent> ().InScope(Scoping.GameObjectBoundaryScoper);
            Rebind<Testable.IRigidBody> ().To<FakeRigidBody> ().InScope(Scoping.GameObjectBoundaryScoper);
            Rebind<ISphereCollider> ().ToProvider<MockProvider<ISphereCollider>> ().InScope (Scoping.GameObjectBoundaryScoper);
            Rebind<IBoxCollider> ().ToProvider<MockProvider<IBoxCollider>> ().InScope (Scoping.GameObjectBoundaryScoper);
            Rebind<ILight> ().ToProvider<MockProvider<ILight>> ().InScope (Scoping.GameObjectBoundaryScoper);

            Rebind<IAudioSource>().To<FakeAudioSource>().InScope(Scoping.GameObjectBoundaryScoper);
            Rebind<Testable.IUtil>().To<MockUtil>().InSingletonScope();
            Rebind<IResourceLoader>().To<MockResourceLoader>().InSingletonScope();
            Rebind<TestableGameObject>().To<FakeGameObject>().InScope(Scoping.GameObjectBoundaryScoper);
            Rebind<ITransform>().To<FakeGameObject.FakeTransform>().InScope(Scoping.GameObjectBoundaryScoper);

            Bind<TestUpdatableManager>().ToSelf().InSingletonScope();

            Bind<TestableGameObject>().ToProvider<PrefabProvider>().WhenTargetHas(typeof(Resource));
            Rebind<IPhysicMaterial>().ToProvider<MockProvider<IPhysicMaterial>>();
        }
    }
}
