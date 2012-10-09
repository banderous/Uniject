using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests {
    class FakeDeployableItem : Game.IDeployableItem {

        public bool updated;
        public bool deployable;
        public bool used;
        
        public bool canDeploy() {
            return deployable;
        }

        public FakeDeployableItem() {
        }

        public FakeDeployableItem(bool deployable) {
            this.deployable = deployable;
        }

        public void onDeploy() {
        }

        public void onUndeploy() {
        }


        public Game.DeployableType getDeployableType() {
            return Game.DeployableType.HAND;
        }

        bool Game.IDeployableItem.Update(UnityEngine.Vector3 pointOfUse, UnityEngine.Vector3 directionOfUse, bool used) {
            updated = true;
            this.used = used;
            return true;
        }


        public Game.Weapon getWeapon() {
            return Game.Weapon.M1911;
        }


        public bool canDrop() {
            return false;
        }

        public void onDrop() {
        }


        Game.Consumable Game.IDeployableItem.getAmmo() {
            return new Game.Consumable(1);
        }
    }
}
