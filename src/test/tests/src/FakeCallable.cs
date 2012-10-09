using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests {
    class FakeCallable<T> : Game.ICallable<T> {
        public T param = default(T);
        public void call(T param) {
            this.param = param;
        }
    }
}
