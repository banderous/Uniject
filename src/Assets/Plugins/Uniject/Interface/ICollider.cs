using System;

namespace Testable {
    public interface ICollider {
        bool enabled { get; set; }
        IPhysicMaterial material { get; set; }
    }
}

