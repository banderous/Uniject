using System;

namespace Uniject {
    public abstract class Scoping {

        /*
         * Ninject scoping function; traverse the activation context hierarchy to the root, or a type 
         * that has a GameObjectBoundary attribute.
         */
        public static object GameObjectBoundaryScoper(Ninject.Activation.IContext context) {
            if (context.Request.Target != null) {
                if (context.Request.Target.IsDefined(typeof(GameObjectBoundary), true) || context.Request.Target.Type.IsDefined(typeof(GameObjectBoundary), true)) {
                    return context.Request.Target;
                }
            }
            
            if (context.Request.ParentContext != null) {
                return GameObjectBoundaryScoper (context.Request.ParentContext);
            }
            
            return context;
        }

        public static Resource getResourcePath(Ninject.Activation.IContext context) {
            if (context.Request.Target != null && context.Request.Target.IsDefined(typeof(Resource), false)) {
                return (Resource) context.Request.Target.GetCustomAttributes(typeof(Resource), false)[0];
            }
            
            if (context.Request.ParentContext != null) {
                return getResourcePath(context.Request.ParentContext);
            }

            return null;
        }
    }
}

