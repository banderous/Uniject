using System;
using Testable;
using UnityEngine;

namespace Tests {
    public class FakePackedSprite : TestableComponent, IPackedSprite {


        public FakePackedSprite(TestableGameObject obj) : base(obj) {
            animations = new UVAnimation[10];
            for (int t = 0; t < animations.Length; t++) {
                animations[t] = buildFakeUV();
            }
        }

        public void Hide(bool hide) {
        }

        private static UVAnimation buildFakeUV() {
            UVAnimation result = new UVAnimation ();
            result.BuildUVAnim(Vector2.zero, Vector2.one, 5, 6, 30);
            return result;
        }

        private UVAnimation[] animations;

        public UVAnimation GetAnim(string name) {
            return animations[0];
        }

        public UVAnimation[] Animations {
            get {
                return animations;
            }
        }

        public Vector3 Offset { get; set; }

        private int curAnimIndex;

        public int CurAnimIndex {
            get {
                return curAnimIndex;
            }
        }

        private bool animating;

        public bool IsAnimating() {
            return animating;
        }

        public UVAnimation GetCurAnim() {
            return animations[curAnimIndex];
        }

        public void PlayAnim(int index) {
            this.curAnimIndex = index;
            this.animations[index].Reset();
            animating = true;
        }

        public void PlayAnimInReverse(int index) {
            this.curAnimIndex = index;
            animations[index].PlayInReverse();
            animating = true;
        }

        public void StopAnim() {
            animating = false;
        }

        public override void Update() {
            if (animating) {
                GetCurAnim().SetCurrentFrame(GetCurAnim().GetCurPosition() + 1);
                if (GetCurAnim().GetCurPosition() >= GetCurAnim().GetFrameCount()) {
                    animating = false;
                }
            }
        }
    }
}

