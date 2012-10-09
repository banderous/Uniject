using System;
using Ninject;
using System.Linq;
using NUnit.Framework;
using Game;

namespace Tests {
    public class TestWeaponConfiguration : BaseInjectedTest {

        [Test]
        public void testUMP() {
            GunConfigurationManager mgr = kernel.Get<GunConfigurationManager>();
            BulletFiringGunDetails details = mgr.get(Game.Weapon.UMP);

            Assert.IsTrue(details.automatic);
            Assert.AreEqual(50, details.startAmmo);
            Assert.AreEqual(800, details.cost);
            Assert.AreEqual(ConsumableType.UMP_AMMO, details.consumable);
            Assert.AreEqual(Weapon.UMP, details.weapon);
        }

        [Test]
        public void testM1911() {
            GunConfigurationManager mgr = kernel.Get<GunConfigurationManager>();
            BulletFiringGunDetails details = mgr.get(Game.Weapon.M1911);

            Assert.IsFalse(details.automatic);
            Assert.AreEqual(20, details.startAmmo);
            Assert.AreEqual(400, details.cost);
            Assert.AreEqual(ConsumableType.M1911_AMMO, details.consumable);
            Assert.AreEqual(Weapon.M1911, details.weapon);
        }

        [Test]
        public void testUpgradingPistol() {
            float baseDamage = kernel.Get<GunConfigurationManager>().get(Weapon.M1911).getDamage();
            kernel.Get<ZombucksAccount>().Credit(1000);
            Assert.IsTrue(kernel.Get<ResearchLab>().upgrade(InventoryItem.M1911, WeaponParameter.DAMAGE));
            Assert.Greater(kernel.Get<GunConfigurationManager>().get(Weapon.M1911).getDamage(), baseDamage);
        }

        [Test]
        public void testNumRays() {
            GunConfigurationManager mgr = kernel.Get<GunConfigurationManager>();
            Assert.AreNotEqual(mgr.get(Weapon.M1911).numRays, mgr.get(Weapon.SHOTGUN).numRays);
        }

        [Test]
        public void sanityTestAllWeapons() {
            GunConfigurationManager mgr = kernel.Get<GunConfigurationManager>();
            foreach (Weapon weapon in Enum.GetValues(typeof(Weapon))) {
                if (weapon == Weapon._DOES_NOT_EXIST) {
                    continue;
                }
                BulletFiringGunDetails details = mgr.get(weapon);
                Assert.Greater(details.numRays, 0);
                assertAscending(details.damageLevels);
                assertDescending(details.delaysBetweenShotsInSeconds);
                assertDescending(details.accuracyConesInDegrees);

                assertUnique(details.damageLevels);
                assertUnique(details.accuracyConesInDegrees);
                assertUnique(details.delaysBetweenShotsInSeconds);
            }
        }

        private void assertUnique(float[] values) {
            Assert.AreEqual(values.Length, values.Distinct().ToArray().Length);
        }

        private void assertDescending(float[] values) {
            float[] sorted = (float[])values.Clone();
            Array.Sort(sorted);
            Array.Reverse(sorted);

            Assert.AreEqual(sorted, values);
        }

        private void assertAscending(float[] values) {
            float[] sorted = (float[]) values.Clone();
            Array.Sort(sorted);
            Assert.AreEqual(sorted, values);
        }
    }
}

