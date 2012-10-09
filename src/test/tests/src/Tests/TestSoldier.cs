using System;
using NUnit.Framework;
using Game;
using Ninject;
using UnityEngine;

namespace Tests {
  [TestFixture]
  public class TestSoldier : BaseInjectedTest {

        [Test]
        public void testInstantiate() {
            Soldier soldier = kernel.Get<Soldier>();
            step(1);
            Assert.AreEqual(3, soldier.Health); 
        }

        [Test]
        public void testUpgradingHealth() {
            kernel.Get<ZombucksAccount>().Credit(1000);
            Assert.IsTrue(kernel.Get<ResearchLab>().upgrade(InventoryItem.BODY_ARMOUR, WeaponParameter.STRENGTH));
            Assert.Less(3, kernel.Get<Soldier>().Health);
        }

        [Test]
        public void testWithPistol() {
            Soldier soldier = kernel.Get<Soldier>();
            TestUpdatableManager mgr = kernel.Get<TestUpdatableManager>();
            step(1);
            Assert.AreEqual(1, mgr.objectCount());

            foreach (Weapon weapon in Enum.GetValues(typeof(Weapon))) {
                if (weapon != Weapon._DOES_NOT_EXIST) {
                    Assert.IsTrue(soldier.locker.HandleInGamePurchase(weapon));
                }
            }
            Assert.AreEqual(1, mgr.objectCount());
        }

        [Test]
        public void testDroppables([Values(InventoryItem.CLAYMORE,
                                           InventoryItem.EXPLOSIVE_MINE,
                                           InventoryItem.MACHINE_GUN_TURRET,
                                           InventoryItem.SHOTGUN_TURRET,
                                           InventoryItem.RPG_TURRET)] InventoryItem droppable) {

            simulateDrop(droppable);
        }

        [Test]
        public void testRPG() {
            Player player = kernel.Get<Player>();
            player.CreditFunds(10000);
            player.InventoryItemTapped(InventoryItem.RPG.ToString());
            step(1);
            player.soldier.drawOrFireWeapon();
            stepToSoldierState(player.soldier, SoldierState.WEAPON_DRAWN);
            player.soldier.drawOrFireWeapon();
            step(1);
        }

        [Test]
        public void testDeath() {
            Soldier soldier = kernel.Get<Soldier>();
            soldier.kineticDamage(Vector3.zero, Vector3.zero, Vector3.zero, 1000);

            step(10);
        }

        private void simulateDrop(InventoryItem item) {
            Player player = kernel.Get<Player>();
            player.CreditFunds(99999);
            player.InventoryItemTapped(item.ToString());
            step(1);
            player.soldier.drawOrFireWeapon();
            step(1);
            Assert.AreEqual(SoldierState.ITEM_DROP_BENDING, player.soldier.getState());
            stepToSoldierState(player.soldier, SoldierState.STANDING);
        }

        private void stepToSoldierState(Soldier soldier, SoldierState state) {
            int count = 0;
            while (soldier.getState() != state) {
                step(1);
                if (count++ > 80) {
                    throw new Exception();
                }
            }
        }
  }
}

