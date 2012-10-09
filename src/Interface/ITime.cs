using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testable {
  public interface ITime {
    float DeltaTime {
      get;
    }

    float realtimeSinceStartup { get; }
  }
}
