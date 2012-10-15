using System;
using System.Collections.Generic;
using Testable;

namespace Tests {
    /*
     * keeps track of all our game objects for the scope of a test, so they can all be updated.
     */
    public class TestUpdatableManager {
        public void step(int numUpdates) {
            foreach (TestableGameObject o in toAdd) {
                objects.Add(o);
            }
            toAdd.Clear();
            for (int t = 0; t < numUpdates; t++) {
                foreach (TestableGameObject obj in objects) {
                    obj.Update();
                }
            }
        }

        public int Count {
            get { return objects.Count; }
        }

        private HashSet<TestableGameObject> objects = new HashSet<TestableGameObject>();
        private HashSet<TestableGameObject> toAdd = new HashSet<TestableGameObject>();
        public void RegisterGameobject(TestableGameObject obj) {
            if (objects.Contains(obj) || toAdd.Contains(obj)) {
                throw new ArgumentException("Duplicate game object");
            }
            toAdd.Add(obj);
        }
    }
}

