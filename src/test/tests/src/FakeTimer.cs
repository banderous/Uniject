using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests {
  class FakeTimer : Testable.ITime {
    
        public float DeltaTime { get; set; }
        public FakeTimer() {
            DeltaTime = 1.0f;
        }

        private float time;
        public float realtimeSinceStartup {
            get {
                time += DeltaTime;
                return time;
            }
            set { time = value; }
        }
  }
}
