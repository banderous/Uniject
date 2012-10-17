using System;
using Ninject.Modules;
using Ninject.Activation;
using UnityEngine;
using Testable;

public class UnityModule : NinjectModule {
    
    public override void Load() {
        Bind<GameObject>().To<GameObject>().InScope(Scoping.GameObjectBoundaryScoper);
        Bind<TestableGameObject>().To<UnityGameObject>().InScope(Scoping.GameObjectBoundaryScoper);
        Bind<IAudioSource>().To <UnityAudioSource>();
        Bind<ILogger>().To<UnityLogger>();
        Bind<IRigidBody>().To<UnityRigidBody>().InScope(Scoping.GameObjectBoundaryScoper);
        Bind<INavmeshAgent>().To<UnityNavmeshAgent>().InScope(Scoping.GameObjectBoundaryScoper);
        Bind<ISphereCollider>().To<UnitySphereCollider>().InScope(Scoping.GameObjectBoundaryScoper);
        Bind<IBoxCollider>().To<UnityBoxCollider>().InScope(Scoping.GameObjectBoundaryScoper);
        
        Bind<IMaths>().To<UnityMath>().InSingletonScope();
        Bind<ITime>().To<UnityTime>().InSingletonScope();
        Bind<ILayerMask>().To<UnityLayerMask>().InSingletonScope();
        Bind<Testable.IResourceLoader>().To<UnityResourceLoader>().InSingletonScope();
        
        Bind<IAudioListener>().To<UnityAudioListener>();
        Bind<ITransform>().To<UnityTransform>().InScope(Scoping.GameObjectBoundaryScoper);
        Bind<ILight>().To<UnityLight>().InScope(Scoping.GameObjectBoundaryScoper);

        // Resource bindings.
        Bind<TestableGameObject>().ToProvider<PrefabProvider>().WhenTargetHas(typeof(Resource));
        Bind<AudioClip>().ToProvider<ResourceProvider<AudioClip>>().WhenTargetHas(typeof(Resource));
        Bind<PhysicMaterial>().ToProvider<ResourceProvider<PhysicMaterial>>();
        Bind<IPhysicMaterial>().To<UnityPhysicsMaterial>();
    }
}
