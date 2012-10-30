using System;
using UnityEngine;

namespace Uniject.Impl {

    /// <summary>
    /// Provider for UnityEngine.GameObject.
    /// We need this because we provide a binding for System.string,
    /// which causes Ninject to try to use the constructor that takes a string.
    /// </summary>
    public class GameObjectProvider : Ninject.Activation.Provider<GameObject> {

        public Action<GameObject> output;
        public Func<GameObject> input;

        protected override GameObject CreateInstance(Ninject.Activation.IContext context) {
            GameObject o = null;
            if (null != input) {
                o = input();
            }
            if (null == o) {
                o = new GameObject ();
            }

            if (null != output) {
                output(o);
            }
            return o;
        }
    }
}
