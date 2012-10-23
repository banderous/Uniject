using System;
using Uniject.Configuration;

namespace Uniject.Impl {

    /// <summary>
    /// Provides XML backed primitive types including string, float and double.
    /// </summary>
    public class XMLConfigProvider<T> : Ninject.Activation.Provider<T> {

        private XMLConfigManager manager;

        public XMLConfigProvider(XMLConfigManager manager) {
            this.manager = manager;
        }

        protected override T CreateInstance(Ninject.Activation.IContext context) {
            XMLConfigValue value = Scoping.getContextAttribute<XMLConfigValue>(context);
            if (value == null) {
                UnityEngine.Debug.Log(typeof(T));
                UnityEngine.Debug.Log(context.Binding.Target);
                throw new ArgumentException("Injected value types must have XMLConfigValue attributes");
            }
            
            return manager.getValue<T>(value.file, value.xpath);
        }
    }
}

