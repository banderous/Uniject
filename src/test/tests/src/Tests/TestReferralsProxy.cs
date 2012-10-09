using System;
using Game;
using NUnit.Framework;
using Ninject;
using System.Threading;

namespace Tests {
    public class TestReferralsProxy : BaseInjectedTest {

        [Test]
        public void testRegistrationOnFirstUse() {
            ReferralsProxy proxy = kernel.Get<ReferralsProxy>();
            proxy.waitForPoll();
            Assert.IsTrue(proxy.available);
            string code = proxy.getMyReferralCode();
            Assert.AreEqual(6, code.Length);
        }

        [Test]
        public void testRegistrationOccursOnce() {
            ReferralsProxy proxy = kernel.Get<ReferralsProxy>();
            proxy.poll();
            proxy.waitForPoll();
            string registration = proxy.getMyReferralCode();

            ReferralsProxy proxy2 = new ReferralsProxy(proxy.adapter, proxy.prefs);
            Assert.AreEqual(registration, proxy2.getMyReferralCode());
        }

        [Test]
        public void testUnavailableIfUnableToRegister() {
            getAdapter().registrationCode = null;
            Assert.IsFalse(kernel.Get<ReferralsProxy>().available);
        }

        [Test]
        public void testRegistrationCompletesIfAdapterRecovers() {
            getAdapter().registrationCode = null;
            ReferralsProxy proxy = kernel.Get<ReferralsProxy>();

            Thread.Sleep(1000); // Yes yes, I know.
            getAdapter().registrationCode = MockReferralsAdapter.defaultRegistrationCode;
            proxy.poll();
            proxy.waitForPoll();
            Assert.IsTrue(proxy.available);
        }

        [Test]
        public void testAvailableIfOfflineButAlreadyRegistered() {
            ReferralsProxy proxy = kernel.Get<ReferralsProxy>();
            proxy.waitForPoll();
            proxy.poll();
            getAdapter().registrationCode = null;

            Assert.IsTrue(new ReferralsProxy(proxy.adapter, proxy.prefs).available);
        }

        [Test]
        public void testEnteringReferralOnline() {
            kernel.Get<ReferralsProxy>().enterCode("123456");
        }

        [Test]
        public void testReferralEnteredOfflineEventuallySubmitted() {
            getAdapter().enterCodeResult = ReferralsAdapterResponse.UNAVAILABLE;

            ReferralsProxy proxy = kernel.Get<ReferralsProxy>();
            Assert.IsTrue(proxy.canEnterReferralCode());
            proxy.enterCode("123456");

            Assert.IsFalse(proxy.canEnterReferralCode());

            getAdapter().enterCodeResult = ReferralsAdapterResponse.OK;
            proxy.poll();
            Assert.IsFalse(proxy.canEnterReferralCode());
        }

        [Test]
        public void testInvalidReferralCodeAllowsResubmission() {
            getAdapter().enterCodeResult = ReferralsAdapterResponse.FAIL;

            ReferralsProxy proxy = kernel.Get<ReferralsProxy>();
            proxy.enterCode("123456");
            proxy.poll();


            Assert.IsTrue(proxy.canEnterReferralCode());
        }
        /*
         * Run against the live service.
         * */

        [Test]
        public void testAdapter() {
            Console.Error.WriteLine(int.Parse(kernel.Get<ReferralsHttpAdapter>().register()));
        }

        [Test]
        public void testMakeReferral() {
            ReferralsProxy proxy = getRealProxy(kernel);
            proxy.waitForPoll();
            Assert.IsTrue(proxy.available);

            ReferralsProxy proxy2 = getRealProxy(createNewKernel());
            proxy2.waitForPoll();
            Assert.IsTrue(proxy2.available);

            proxy.enterCode(proxy2.getMyReferralCode());
            proxy.waitForPoll();


            proxy2.poll();
            proxy2.waitForPoll();
            Assert.AreEqual(1, proxy2.checkAndResetReferralCount());
            Assert.AreEqual(0, proxy2.checkAndResetReferralCount());
        }

        private static ReferralsProxy getRealProxy(IKernel kernel) {
            return new ReferralsProxy(kernel.Get<ReferralsHttpAdapter>(), kernel.Get<IUserPrefs>());
        }

        private MockReferralsAdapter getAdapter() {
            return (MockReferralsAdapter) kernel.Get<IReferralsAdapter>();
        }
    }
}

