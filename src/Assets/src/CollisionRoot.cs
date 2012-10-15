using Ninject;
using UnityEngine;
using System.Collections;
using Testable;

public class CollisionRoot : MonoBehaviour {

    [GameObjectBoundary]
    public class Microphone : TestableComponent {
        public IAudioListener Mic { get; private set; }
        public Microphone(TestableGameObject parent, IAudioListener listener) : base(parent) {
            this.Mic = listener;
            parent.name = "Mic";
        }
    }
    
    void Start () {
        Bot bot = UnityInjector.get().Get<Bot>();
        bot.Obj.name = "Red";

        Microphone mic = UnityInjector.get().Get<Microphone>();
        mic.Obj.transform.Parent = bot.Obj.transform;
	}
}
