using System;
using NUnit.Framework;
using Ninject;
using Testable;
using System.Linq;
using System.Xml.XPath;
using System.Xml.Linq;
using Game;
using UnityEngine;

namespace Tests {
    public class TestOrchestrator : BaseInjectedTest {

        [Test]
        public void testScopedToLevel() {
            Orchestrator a = kernel.Get<Orchestrator>();
            Orchestrator b = kernel.Get<Orchestrator>();

            Assert.AreSame(a, b);
            sceneScope = new object();

            Orchestrator c = kernel.Get<Orchestrator>();
            Assert.AreNotSame(a, c);
        }

        [Test]
        public void testDifficultyLoadingBronze() {

            LevelDifficulty difficulty = kernel.Get<Game.DifficultyManager>().loadLevel("level1", Difficulty.BRONZE);

            Assert.AreEqual(4, difficulty.numberOfRounds);
            Assert.AreEqual(6, difficulty.RoundInterval);
            Assert.AreEqual(1.5, difficulty.MaxZombieSpawnDelay);
            Assert.AreEqual(0.75, difficulty.MinZombieSpawnDelay);
            Assert.AreEqual(500, difficulty.startingFunds);
            Assert.AreEqual(new int[] { 8, 7, 6, 5 }, difficulty.numberOfZombiesPerRound);
            Assert.AreEqual(new float[] { 2, 2, 1, 3 }, difficulty.zombieHealthPerRound);
            Assert.AreEqual(new float[] { 1.5f, 2, 2.2f, 2.5f }, difficulty.zombieSpeedPerRound);
        }

        [Test]
        public void testDifficultyLoadingGold() {

            LevelDifficulty difficulty = kernel.Get<Game.DifficultyManager>().loadLevel("level1", Difficulty.GOLD);

            Assert.AreEqual(1, difficulty.numberOfRounds);
            Assert.AreEqual(2, difficulty.RoundInterval);
            Assert.AreEqual(1.5, difficulty.MaxZombieSpawnDelay);
            Assert.AreEqual(0.75, difficulty.MinZombieSpawnDelay);
            Assert.AreEqual(2500, difficulty.startingFunds);
            Assert.AreEqual(new int[] { 50 }, difficulty.numberOfZombiesPerRound);
            Assert.AreEqual(new float[] { 3 }, difficulty.zombieHealthPerRound);
            Assert.AreEqual(new float[] { 6 }, difficulty.zombieSpeedPerRound);
        }

        [Test]
        public void testEndless() {
            MockUtil util = (MockUtil)kernel.Get<IUtil>();
            util.result = new object[] { new TestZombieSpawner.FakeSpawner { point = Vector3.zero, layer = 0 }  };

            DifficultyManager manager = kernel.Get<DifficultyManager>();
            LevelDifficulty difficulty = manager.loadLevel("endless1", Difficulty.BRONZE);

            Orchestrator orchestrator = kernel.Get<Orchestrator>();
            orchestrator.Initialise(difficulty);

            step(100);

        }

        [Test]
        public void testAllLevels() {
            int levelCount = 6;
            var difficulties = new Difficulty[] { Difficulty.BRONZE, Difficulty.SILVER, Difficulty.GOLD };
            DifficultyManager manager = kernel.Get<DifficultyManager>();
            for (int t = 1; t <= levelCount; t++) {
                string level = string.Format("level{0}", t);
                foreach (var difficulty in difficulties) {
                    LevelDifficulty diff = manager.loadLevel(level, difficulty);
                    Assert.IsTrue(diff.numberOfRounds >= 1 && diff.numberOfRounds <= 8);
                    Assert.IsTrue(diff.RoundInterval > 0);
                    Assert.IsTrue(diff.startingFunds >= 500);
                }
            }
        }

        [Test]
        public void testOrchestrator([Values(1)] int levelNumber,
                                     [Values(Difficulty.BRONZE, Difficulty.SILVER, Difficulty.GOLD)] Difficulty difficulty) {
            MockUtil util = (MockUtil)kernel.Get<IUtil>();
            util.result = new object[] { new TestZombieSpawner.FakeSpawner { point = Vector3.zero, layer = 0 }  };

            LevelDifficulty level = kernel.Get<DifficultyManager>().loadLevel(string.Format("level{0}", levelNumber), difficulty);
            int expectedTotal = level.numberOfZombiesPerRound.Sum();
            Orchestrator orchestrator = kernel.Get<Orchestrator>();
            orchestrator.Initialise(level);

            TestUpdatableManager mgr = kernel.Get<TestUpdatableManager>();
            for (int t = 0; t < 900; t++) {
                mgr.step(1);
                orchestrator.zombieSpawner.zombiePool.spawned.ForEach(z => z.instaGib());
            }

            Assert.AreEqual(expectedTotal, orchestrator.zombieSpawner.zombiePool.totalEverSpawned);
        }
    }
}

