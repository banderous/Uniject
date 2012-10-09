using System;
using NUnit.Framework;
using Game;
using Ninject;

namespace Tests {
    public class TestConfigManager : BaseInjectedTest {

        [Test]
        public void testUsesLocalFiles() {
            ConfigManager mgr = kernel.Get<ConfigManager>();
            mgr.loadDoc("config/levels");
        }

        [Test]
        public void testFetchesLatestFiles() {
            ConfigManager mgr = kernel.Get<ConfigManager>();
            Assert.IsFalse(mgr.lastCacheHit);
            mgr.waitForSync();
            mgr.loadDoc("config/levels");
            Assert.IsTrue(mgr.lastCacheHit);
        }
    }
}
