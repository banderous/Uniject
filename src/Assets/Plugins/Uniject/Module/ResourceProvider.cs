using System;

namespace Testable {
    public class ResourceProvider<T> : Ninject.Activation.Provider<T> where T : UnityEngine.Object {

        private IResourceLoader loader;
        public ResourceProvider(IResourceLoader loader) {
            this.loader = loader;
        }

        protected override T CreateInstance(Ninject.Activation.IContext context) {
            object[] attributes = context.Request.Target.GetCustomAttributes(typeof(Resource), false);
            if (attributes == null || attributes.Length != 1) {
                throw new ArgumentException("Injected resources must have Resource attributes");
            }
            Resource resource = (Resource) attributes[0];
            return loader.loadResource<T>(resource.Path);
        }
    }
}

