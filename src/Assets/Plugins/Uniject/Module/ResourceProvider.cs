using System;

namespace Testable {
    public class ResourceProvider<T> : Ninject.Activation.Provider<T> where T : UnityEngine.Object {

        private IResourceLoader loader;
        public ResourceProvider(IResourceLoader loader) {
            this.loader = loader;
        }

        protected override T CreateInstance(Ninject.Activation.IContext context) {
            Resource resource = Scoping.getResourcePath(context);
            if (resource == null) {
                throw new ArgumentException("Injected resources must have Resource attributes");
            }

            return loader.loadResource<T>(resource.Path);
        }
    }
}

