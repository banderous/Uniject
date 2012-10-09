using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Game;
using Ninject;

namespace Tests {
    [TestFixture]
    public class TestZombucksAccount : BaseInjectedTest {

        [Test]
        public void testCredit() {
            ZombucksAccount account = kernel.Get<ZombucksAccount>();
            LSAssert.AreEqual<int>(0, account.Balance);
            account.Credit(1);
            LSAssert.AreEqual<int>(1, account.Balance);
        }

        [Test]
        public void testCanDebit() {
            ZombucksAccount account = kernel.Get<ZombucksAccount>();
            account.Credit(1);
            Assert.IsTrue(account.CanDebit(1));
            LSAssert.AreEqual<int>(1, account.Balance);
        }

        [Test]
        public void testDebit() {
            ZombucksAccount account = kernel.Get<ZombucksAccount>();
            account.Credit(1);
            Assert.IsTrue(account.Debit(1));
            LSAssert.AreEqual<int>(0, account.Balance);
        }

        [Test]
        public void testFailedDebitNoFunds() {
            ZombucksAccount account = kernel.Get<ZombucksAccount>();
            Assert.IsFalse(account.Debit(1));
            LSAssert.AreEqual<int>(0, account.Balance);
        }

        [Test]
        public void testFailedDebitInsufficientFunds() {
            ZombucksAccount account = kernel.Get<ZombucksAccount>();
            account.Credit(1);
            Assert.IsFalse(account.Debit(2));
            LSAssert.AreEqual<int>(1, account.Balance);
        }
    }
}
