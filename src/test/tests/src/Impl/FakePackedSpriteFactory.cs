using System;
using Game;
using Testable;
using Ninject.Activation;

namespace Tests {
  public class FakePackedSpriteFactory : Game.IPackedSpriteFactory {

    public IPackedSprite create(TestableGameObject parent, SpriteType t) {
      return new FakePackedSprite(parent);
    }
  }
}

