using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests {
    class FakeTrigger : Game.ITrigger {
        public bool result = false;
        public bool triggered() {
            return result;
        }
    }
}
