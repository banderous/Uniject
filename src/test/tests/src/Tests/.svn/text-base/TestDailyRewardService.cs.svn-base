using System;
using System.Linq;
using Ninject;
using NUnit.Framework;
using Game;

namespace Tests {

    public class TestDailyRewardService : BaseInjectedTest {

        [Test]
        public void testDayOne() {
            getUtilInstance().currentTime = new DateTime(1990, 1, 1);
            DailyRewardService svc = kernel.Get<DailyRewardService>();

            Assert.AreEqual(DailyRewardProgress.DAY_0, svc.getCurrentDay());
            Assert.AreEqual(svc.config.dailyRewardExponentBase, svc.account.Balance);
        }

        [Test]
        public void testRewardNotDuplicated() {
            getUtilInstance().currentTime = new DateTime(2000, 1, 1);
            DailyRewardService svc = kernel.Get<DailyRewardService>();
            svc.getCurrentDay();
            getUtilInstance().currentTime = getUtilInstance().currentTime.AddHours(23);
            Assert.AreEqual(DailyRewardProgress.DAY_0, svc.getCurrentDay());
            Assert.AreEqual(svc.config.dailyRewardExponentBase, svc.account.Balance);
        }

        [Test]
        public void testDayOneToDayTwo() {
            getUtilInstance().currentTime = new DateTime(1984, 2, 29, 23, 59, 59);

            DailyRewardService svc = kernel.Get<DailyRewardService>();
            svc.getCurrentDay();

            getUtilInstance().currentTime = getUtilInstance().currentTime.AddSeconds(2);
            Assert.AreEqual(DailyRewardProgress.DAY_1, svc.getCurrentDay());
            Assert.AreEqual(svc.config.dailyRewardExponentBase + svc.config.dailyRewardExponentBase * 2, svc.account.Balance);
        }

        [Test]
        public void testDayTwoMissed() {
            getUtilInstance().currentTime = new DateTime(2020, 1, 1, 23, 59, 59);
            DailyRewardService svc = kernel.Get<DailyRewardService>();
            svc.getCurrentDay();

            getUtilInstance().currentTime = getUtilInstance().currentTime.AddHours(24).AddSeconds(2);
            Assert.AreEqual(DailyRewardProgress.DAY_0, svc.getCurrentDay());
            Assert.AreEqual(svc.config.dailyRewardExponentBase * 2, svc.account.Balance);
        }

        [Test]
        public void testBackInTime() {
            getUtilInstance().currentTime = new DateTime(2200, 1, 1);

            DailyRewardService svc = kernel.Get<DailyRewardService>();
            svc.getCurrentDay();

            advanceClock(-24);

            svc.account.Debit(svc.account.Balance);
            svc.getCurrentDay();
            Assert.AreEqual(0, svc.account.Balance);
        }

        [Test]
        public void testDayOneToFourToOne() {
            getUtilInstance().currentTime = new DateTime (2100, 1, 1);

            DailyRewardService svc = kernel.Get<DailyRewardService>();

            for (int t = 0; t < 4; t++) {
                advanceClock(24);
                svc.getCurrentDay();
                svc.getCurrentDay();
            }

            Assert.AreEqual(DailyRewardProgress.DAY_3_OR_GREATER, svc.getCurrentDay());

            int expectedResult = (int) (from x in new int[] { 0, 1, 2, 3 }
            select Math.Pow(2, x) * svc.config.dailyRewardExponentBase).Sum();

            Assert.AreEqual(expectedResult, svc.account.Balance);

            svc.account.Debit(svc.account.Balance);
            advanceClock(24);
            svc.getCurrentDay();
            Assert.AreEqual(Math.Pow(2, 3) * svc.config.dailyRewardExponentBase, svc.account.Balance);
        }

        private void advanceClock(int hours) {
            getUtilInstance().currentTime = getUtilInstance().currentTime.AddHours(hours);
        }
    }
}
