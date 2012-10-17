using System;
using UnityEngine;

namespace Testable {
    public interface IBoxCollider : ICollider {
        Vector3 center { get; set; }
        Vector3 size { get; set; }
    }
}

