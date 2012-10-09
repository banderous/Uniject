using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tests {
    class FakeMath : Testable.IMaths {

        private bool alwaysTrue;
        public FakeMath(bool alwaysTrue) {
            this.alwaysTrue = alwaysTrue;
        }

        public bool trueOneInN(int n) {
            return alwaysTrue;
        }

        public float randomNormalised() {
            return (float) new System.Random().NextDouble();
        }

        public float randomNormalisedNeg1to1() {
            return 0.25f;
        }

        public Quaternion LookRotation(Vector3 dir, Vector3 up) {
            return Quaternion.identity;
        }

        private bool toggle;
        public int randZeroToNMinusOne(int n) {
            if (alwaysTrue) {
                return n - 1;
            }

            return new System.Random().Next(n);
        }
    }
}
