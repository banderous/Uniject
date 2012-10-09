using System;
using UnityEngine;

namespace Tests {
    public class FakeDecalManager : Game.IDecalManager {
        public bool spawnedCloud, spawnedTrail;
        public void spawnBloodCloud(Vector3 position, Vector3 up, int count) { 
            spawnedCloud = true;
        }

        public bool spawnedGibs;
        public void spawnGibs(Vector3 location, Vector3 impulseDirection) {
            spawnedGibs = true;
        }

        public bool exploded;
        public void spawnExplosion(Vector3 location, float maxRange, float damage) {
            exploded = true;
        }

        public void spawnBloodBulletTrail(Vector3 location, Vector3 incidentDirection) {
            spawnedTrail = true;
        }
    }
}

