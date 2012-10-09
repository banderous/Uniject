using System;
using UnityEngine;

namespace Testable {
    public interface ISphereCollider {
        float radius { get; set; }
        bool enabled { get; set; }
        Vector3 center { get; set; }
    }
}

