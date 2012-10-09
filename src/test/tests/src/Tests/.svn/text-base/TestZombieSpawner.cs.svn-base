using System;
using NUnit.Framework;
using Ninject;
using Testable;
using LS3Test;
using UnityEngine;
using Game;

namespace Tests {
    [TestFixture]
    public class TestZombieSpawner : BaseInjectedTest {

        public class FakeSpawner : Game.ISpawner {
            public Vector3 point { get; set; }

            public int useCount { get; private set; }
            public Vector3 getSpawnPoint() {
                useCount++;
                return point;
            }

            public int layer { get; set; }
        }

        [Test]
        public void testCreation() {
            mockKernel();
            UnityZombieSpawner spawner = kernel.Get<UnityZombieSpawner>();
            spawner.spawn(1, 1, 1, 0);
            spawner.Update();
        }

        [Test]
        public void testOutOfZombies() {
            mockKernel();
            UnityZombieSpawner spawner = kernel.Get<UnityZombieSpawner>();
            for (int t = 0; t < ZombiePool.maxConcurrentZombies; t++) {
                Assert.IsTrue(spawner.spawn(1, 1, 1, 0));
            }
            Assert.IsFalse(spawner.spawn(1, 1, 1, 0));
        }

        [Test]
        public void testZombiesRecycled() {
            mockKernel();
            UnityZombieSpawner spawner = kernel.Get<UnityZombieSpawner>();
            for (int t = 0; t < ZombiePool.maxConcurrentZombies; t++) {
                spawner.spawn(1, 1, 1, 0);
            }

            spawner.zombiePool.spawned.ForEach(zombie => zombie.kineticDamage(Vector3.zero, Vector3.zero, Vector3.zero, 999));
            spawner.zombiePool.spawned.ForEach(zombie => zombie.Update());
            spawner.zombiePool.spawned.ForEach(zombie => zombie.Update());

            kernel.Get<TestUpdatableManager>().step(1);
            Assert.AreEqual(ZombiePool.maxConcurrentZombies, spawner.zombiePool.numAvailableToSpawn());
        }

        private void mockKernel() {
            MockUtil util = (MockUtil)kernel.Get<IUtil>();
            util.result = new object[] { new FakeSpawner { point = Vector3.zero, layer = 0 }  };
        }
    }
}

