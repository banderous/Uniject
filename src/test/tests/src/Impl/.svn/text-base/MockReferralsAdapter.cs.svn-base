using System;
using Game;
using Ninject;

namespace Tests {
    public class MockReferralsAdapter : IReferralsAdapter {
        public const string defaultRegistrationCode = "ABC123";
        public string registrationCode = defaultRegistrationCode;
        public string register() {
            return registrationCode;
        }

        public MockReferralsAdapter([Named("referralsServiceUrl")] string referralsUrl) {
        }

        public ReferralsAdapterResponse enterCodeResult;
        public ReferralsAdapterResponse submitReferal(string myCode, string theirCode) {
            return enterCodeResult;
        }

        int referralCount;
        public int pollForReferals(string id) {
            int result = referralCount;
            referralCount = 0;
            return result;
        }
    }
}

