using System;
using Game;
using NUnit.Framework;
using Ninject;

namespace Tests {
    public class TestUserInfo : BaseInjectedTest {

        [Test]
        public void testIsSingleton() {
            Assert.AreEqual(kernel.Get<UserInfo>(), kernel.Get<UserInfo>());
        }

        [Test]
        public void testExistingUsersInGroupZero() {
            IUserPrefs prefs = kernel.Get<IUserPrefs>();
            prefs.SetBool(UserInfo.firstBootKey, false);

            UserInfo info = kernel.Get<UserInfo>();
            Assert.AreEqual(UserInfo.ABGroup.G_0, info.Group);

            Assert.AreEqual(UserInfo.ABGroup.G_0, new UserInfo(info.prefs, kernel.Get<Testable.IMaths>(), kernel.Get<Testable.IUtil>()).Group);
        }

        [Test]
        public void testFirstBoot() {
            UserInfo info = kernel.Get<UserInfo>();
            Assert.IsTrue(info.FirstBoot);
        }

        [Test]
        public void testSecondBoot() {
            UserInfo info = kernel.Get<UserInfo>();
            info = new UserInfo(info.prefs, kernel.Get<Testable.IMaths>(), kernel.Get<Testable.IUtil>());
            Assert.IsFalse(info.FirstBoot);
        }
    }
}

