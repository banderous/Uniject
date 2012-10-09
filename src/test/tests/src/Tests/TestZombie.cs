using System;
using Ninject;
using NUnit.Framework;
using Game;
using UnityEngine;
using Testable;
using Tests;

namespace LS3Test {
    [TestFixture(true)]
    [TestFixture(false)]
    public class TestZombie : BaseInjectedTest {

        private bool param;
        public TestZombie(bool b) {
            this.param = b;
        }

        protected override Ninject.Modules.NinjectModule getModule() {
            return new TestModule(param);
        }

        [Test]
        public void testInstantiate () {
            Assert.AreNotEqual(0, getZombie().body.drag);
        }

        [Test]
        public void testZombieAttacksAlive () {
            MockDamageable mock = new MockDamageable ();
            mock.type = EntityType.ALIVE;
            ((MockPhysics)kernel.Get<IPhysics> ()).addObjectInLayer(mock, "LIVING");

            Zombie z = getZombie();
            z.Update ();
            Assert.AreEqual (ZombieState.LUNGING, z.getState ());
        }

        [Test]
        public void testZombieKillableWhenAttacking () {
            MockDamageable mock = new MockDamageable ();
            mock.type = EntityType.ALIVE;
            ((MockPhysics)kernel.Get<IPhysics> ()).addObjectInLayer(mock, "LIVING");

            Zombie z = getZombie();
            z.Update ();
            Assert.AreEqual (ZombieState.LUNGING, z.getState ());
            z.kineticDamage (Vector3.zero, Vector3.zero, Vector3.zero, 100000);
            z.Update ();
            Assert.AreEqual (ZombieState.GIBBING, z.getState ());
        }

        [Test]
        public void testZombieDoesDamage () {
            MockDamageable mock = new MockDamageable ();
            mock.type = EntityType.ALIVE;
            ((MockPhysics)kernel.Get<IPhysics> ()).addObjectInLayer(mock, "LIVING");

            getZombie();

            Assert.AreEqual (0, mock.damageDone);

            step(100);

            Assert.AreNotEqual (0, mock.damageDone);
        }

        [Test]
        public void testZombieBodyConstraints () {
            Zombie zombie = getZombie();
            RigidbodyConstraints expected = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            Assert.AreEqual (expected, zombie.Actuator.Body.constraints);
        }

        [Test]
        public void testZombieHasCollider () {
            Zombie zombie = getZombie();
            Assert.IsNotNull(zombie.Obj.getComponent<ISphereCollider>());
        }

        [Test]
        public void testZombieGibbed () {
            Zombie z = getZombie();
            z.kineticDamage (Vector3.zero, Vector3.zero, Vector3.zero, 1000);
            z.Update ();
            Assert.AreEqual (ZombieState.GIBBING, z.getState ());
            z.Update();
            assertDead(z);
            Assert.IsTrue(((FakeDecalManager) z.decals).spawnedCloud);
            Assert.IsTrue(((FakeDecalManager) z.decals).spawnedGibs);
        }

        [Test]
        public void testZombieKilled() {
            Zombie z = getZombie();
            assertReadyToRoll(z);
            z.kineticDamage (Vector3.zero, Vector3.zero, Vector3.zero, 10);
            z.Update ();
            Assert.AreEqual (ZombieState.DYING, z.getState ());
            assertDead(z);
            Assert.IsTrue(z.Obj.active);
            kernel.Get<TestUpdatableManager>().step(100);
            Assert.IsTrue(((FakeDecalManager) z.decals).spawnedTrail);
            Assert.IsFalse(z.Obj.active);
        }

        [Test]
        public void testZombieRecycled() {
            Zombie z = getZombie();
            gib(z);
            z.initialise(5, 1, 1);
            assertReadyToRoll(z);
            gib(z);
            assertDead(z);
        }

        private Zombie getZombie() {
            Zombie zombie = kernel.Get<Zombie>();
            zombie.initialise(5, 1, 1);
            assertReadyToRoll(zombie);
            return zombie;
        }

        private void gib(Zombie z) {
            z.kineticDamage(Vector3.zero, Vector3.zero, Vector3.one, 1000);
            z.Update();
            z.Update();
            Assert.AreEqual(ZombieState.GONE, z.getState());
        }

        private void assertReadyToRoll (Zombie z) {
            Assert.IsTrue(z.Actuator.Body.enabled);
            Assert.AreEqual(z.Actuator.Body, z.body);
            Assert.IsTrue(z.collider.enabled);
            Assert.IsTrue(z.finder.Enabled);

            Assert.IsTrue(z.health > 0);
            Assert.AreEqual(ZombieState.SHUFFLING, z.getState());
            Assert.AreNotEqual(Vector3.zero, z.sprite.sprite.Offset);
            Assert.IsTrue(z.Obj.active);
        }

        private void assertDead(Zombie z) {
            Assert.IsFalse(z.Obj.getComponent<IRigidBody>().enabled);
            Assert.IsFalse(z.collider.enabled);
            Assert.IsFalse(z.body.enabled);

            FakeNavmeshAgent finder = (FakeNavmeshAgent) z.Obj.getComponent<INavmeshAgent>();
            Assert.IsFalse(finder.Enabled);

            Assert.IsTrue(new Vector3(0, 1, 0) == z.sprite.sprite.Offset || new Vector3(0, 1.5f, 0) == z.sprite.sprite.Offset);
        }
    }
}
