using System;
using UnityEngine;

namespace Testable {
    public interface IUtil {
        T[] getAnyComponentsOfType<T>() where T : class;
        string loadedLevelName();
        RuntimePlatform Platform { get; }
        string persistentDataPath { get; }
        DateTime currentTime { get; }
    }
}

