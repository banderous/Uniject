using Ninject;
using System;
using Testable;

/// <summary>
/// Denotes a parameter should be instantiated as a Unity prefab.
/// </summary>
[System.AttributeUsage(System.AttributeTargets.Parameter)]
public class PrefabAttribute : GameObjectBoundary {
    public string Path { get; private set; }
    public PrefabAttribute(string path) {
        this.Path = path;
    }
}

[System.AttributeUsage(System.AttributeTargets.Parameter)]
public class Resource : System.Attribute {
    public string Path { get; private set; }
    public Resource(string path) {
        this.Path = path;
    }
}

/// <summary>
/// A <c>Provider</c> that instantiates Unity prefabs wrapped as <c>TestableGameObject</c>.
/// </summary>
public class PrefabProvider : Ninject.Activation.Provider<TestableGameObject> {
    
    private IResourceLoader loader;
    public PrefabProvider(IResourceLoader loader) {
        this.loader = loader;
    }
    
    protected override TestableGameObject CreateInstance(Ninject.Activation.IContext context) {
        PrefabAttribute attrib = (PrefabAttribute) context.Request.Target.GetCustomAttributes(typeof(PrefabAttribute), false)[0];
        return loader.instantiate(attrib.Path);
    }
}
