using System;

namespace Testable {
    public abstract class Scoping {

        /*
         * Ninject scoping function; traverse the activation context hierarchy to the root, or a type 
         * that has a GameObjectBoundary attribute.
         */
        public static object GameObjectBoundaryScoper(Ninject.Activation.IContext context) {
            if (context.Request.Target != null) {
                
                if (context.Request.Target.Type.IsDefined(typeof(GameObjectBoundary), true)) {
                    return context;
                }
            }
            
            if (context.Request.ParentContext != null) {
                return GameObjectBoundaryScoper (context.Request.ParentContext);
            }
            
            return context;
        }
    }
}

