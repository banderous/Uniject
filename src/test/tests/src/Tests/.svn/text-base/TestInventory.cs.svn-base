using System;
using NUnit.Framework;
using Ninject;
using Game;

namespace Tests {
    public class TestInventory : BaseInjectedTest {

        [Test]
        public void testPistol() {
            UnityInventoryEntry entry = kernel.Get<UnityInventoryDatabase>().get(Game.InventoryItem.M1911);
            Assert.AreEqual(0, entry.researchCostInZombucks);
            Assert.IsTrue(entry.immediatelyAvailable);
            Assert.IsTrue(entry.noPurchaseNecessary);
            Assert.AreEqual(new WeaponParameter[] { WeaponParameter.DAMAGE,
                WeaponParameter.ROF,
                WeaponParameter.ACCURACY }, entry.weaponParameters);
        }

        [Test]
        public void testRpgTurret() {
            UnityInventoryEntry entry = kernel.Get<UnityInventoryDatabase>().get(Game.InventoryItem.RPG_TURRET);
            Assert.AreEqual(1000, entry.researchCostInZombucks);
            Assert.IsFalse(entry.immediatelyAvailable);
            Assert.IsFalse(entry.noPurchaseNecessary);
            Assert.AreEqual(new WeaponParameter[] { WeaponParameter.DAMAGE }, entry.weaponParameters);
        }

        [Test]
        public void sanityTestAllInventory() {
            UnityInventoryDatabase db = kernel.Get<UnityInventoryDatabase>();
            foreach (InventoryItem item in Enum.GetValues(typeof(InventoryItem))) {
                UnityInventoryEntry entry = db.get(item);
                validate(entry.displayName);
                validate(entry.displayDescription);
                if (!entry.immediatelyAvailable && !entry.noPurchaseNecessary) {
                    Assert.AreNotEqual(0, entry.researchCostInZombucks);
                }
            }
        }

        [Test]
        public void testAllConsumables() {
            UnityInventoryDatabase db = kernel.Get<UnityInventoryDatabase>();
            foreach (ConsumableType consumable in Enum.GetValues(typeof(ConsumableType))) {
                ConsumableDetails details = db.getConsumable(consumable);
                Assert.Greater(details.cost, 0);
                Assert.Greater(details.quantity, 0);
                Assert.Less(details.quantity, details.maxCapacity);
                Assert.Less(details.quantity, 100);
                Assert.Less(details.maxCapacity, 500);
            }
        }

        [Test]
        public void testARAmmo() {
            ConsumableDetails details = kernel.Get<UnityInventoryDatabase>().getConsumable(ConsumableType.ASSAULT_RIFLE_AMMO);
            Assert.AreEqual(125, details.cost);
            Assert.AreEqual(20, details.quantity);
            Assert.AreEqual(60, details.maxCapacity);
            Assert.IsFalse(details.infinite);
        }

        private void validate(string field) {
            Assert.IsFalse(field.ToLower().Contains("todo"));
        }
    }
}

