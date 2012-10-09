using Ninject;
using System;
using Testable;
using UnityEngine;

public class InjectionRoot : MonoBehaviour {

    public void Start() {
        TestableExample example = UnityInjector.get().Get<TestableExample>();
        example.Obj.name = "Example";
    }
}
