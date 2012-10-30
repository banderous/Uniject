using Ninject;
using System;
using System.Collections.Generic;
using Uniject;
using Uniject.Impl;
using UnityEngine;

[ExecuteInEditMode]
public class InjectionRoot : MonoBehaviour {

    public string typeToInstantiate;

    [HideInInspector]
    [SerializeField]
    private List<GameObject> objects = new List<GameObject>();

    [HideInInspector]
    [SerializeField]
    private string createdType;

    private bool created = false;
    public void Update() {
        if (!created) {
            Create();
        } else {
            if (Application.isPlaying) {
                this.gameObject.active = false;
            }
            if (createdType != typeToInstantiate) {
                Destroy();
                Create();
            }
        }
    }

    private void Create() {
        if (!created) {
            createdType = typeToInstantiate;
            Type type = Type.GetType(typeToInstantiate);
            if (null == type) {
                return;
            }
            GameObjectProvider provider = UnityInjector.get().Get<Uniject.Impl.GameObjectProvider>();
            provider.output = (s) => objects.Add(s);
            provider.input = () => {
                GameObject result = null;
                if (objects.Count > 0) {
                    result = objects[0];
                    objects.RemoveAt(0);
                }
                return result;
            };
            object o = UnityInjector.get().Get(Type.GetType(typeToInstantiate));
            provider.output = null;
            provider.input = null;

            if (o is TestableComponent) {
                TestableComponent tco = o as TestableComponent;
                tco.Obj.transform.Position = transform.position;
                tco.Obj.transform.Parent = new UnityTransform (this.gameObject);
                tco.Obj.name = typeToInstantiate;
            }

            created = true;
        }
    }

    private void Destroy() {
        if (created) {
            foreach (GameObject o in objects) {
                GameObject.DestroyImmediate(o);
            }

            objects.Clear();
            created = false;
        }
    }
}
