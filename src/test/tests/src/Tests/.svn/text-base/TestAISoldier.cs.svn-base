using System;
using Game;
using Ninject;
using UnityEngine;
using NUnit.Framework;
using Testable;

namespace Tests {
    public class TestAISoldier : BaseInjectedTest {

        [Test]
        public void testInstantiate() {
            kernel.Get<AISoldier>();
            step(1);
        }

        [Test]
        public void testKillingZombie() {
            mockKernel();
            UnityZombieSpawner spawner = kernel.Get<UnityZombieSpawner>();
            spawner.spawn(1, 1, 1, 0);

            Zombie zombie = spawner.zombiePool.spawned[0];

            MockPhysics physics = (MockPhysics) kernel.Get<IPhysics>();
            physics.addObjectInLayer(zombie, "UNDEAD");

            AISoldier soldier = kernel.Get<AISoldier>();
            soldier.soldier.locker.HandleInGamePurchase(Weapon.MP5);

            step(1000);
            step(1);
            Assert.AreEqual(AIState.IDLE, soldier.stateMachine.getState());
            Assert.AreEqual(SoldierState.STANDING, soldier.soldier.getState());
            Assert.AreEqual(AIState.IDLE, soldier.stateMachine.getState());
            Assert.IsFalse(zombie.alive());
        }

        [Test]
        public void testShootsWithinRange() {
            mockKernel();
            UnityZombieSpawner spawner = kernel.Get<UnityZombieSpawner>();
            spawner.spawn(1, 1, 1, 0);

            Zombie zombie = spawner.zombiePool.spawned[0];
            zombie.Obj.transform.Position = new Vector3(AISoldier.TARGETING_DISTANCE - 1, 0, 0);

            MockPhysics physics = (MockPhysics) kernel.Get<IPhysics>();
            physics.addObjectInLayer(zombie, "UNDEAD");

            AISoldier soldier = kernel.Get<AISoldier>();
            soldier.soldier.locker.HandleInGamePurchase(Weapon.MP5);

            step(1000);
            Assert.IsFalse(zombie.alive());
            Assert.AreEqual(SoldierState.STANDING, soldier.soldier.getState());
            Assert.AreEqual(AIState.IDLE, soldier.stateMachine.getState());
        }

        [Test]
        public void testFollowsPlayer() {
            AISoldier soldier = kernel.Get<AISoldier>();

            step(1);
            Assert.AreEqual(SoldierState.STANDING, soldier.soldier.getState());

            Vector3 offset = new Vector3(AISoldier.PLAYER_FOLLOW_DISTANCE + 1, 0, 0);
            soldier.Obj.transform.Translate(offset);
            step(2);

            Assert.AreEqual(SoldierState.RUNNING, soldier.soldier.getState());

            soldier.Obj.transform.Translate(-offset);
            step(2);
            Assert.AreEqual(SoldierState.STANDING, soldier.soldier.getState());
        }

        [Test]
        public void sanityTestRanges() {
            Assert.Less(AISoldier.TARGETING_DISTANCE, AISoldier.TARGETING_DISTANCE_WHEN_DEPLOYED);
        }

        public class FakeSpawner : Game.ISpawner {
            public Vector3 point { get; set; }

            public int useCount { get; private set; }
            public Vector3 getSpawnPoint() {
                useCount++;
                return point;
            }

            public int layer { get; set; }
        }

        private void mockKernel() {
            MockUtil util = (MockUtil)kernel.Get<IUtil>();
            util.result = new object[] { new FakeSpawner { point = Vector3.zero, layer = 0 }  };
        }
    }
}

