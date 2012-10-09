using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests {
    class FakeDroppable : Game.IDroppableItem {
        public bool droppable;
        public bool canDrop() {
            return droppable;
        }

        public FakeDroppable(bool droppable) {
            this.droppable = droppable;
        }

        public Game.DroppableItem getItem() {
            return Game.DroppableItem.CLAYMORE;
        }

        public void onDrop() {
        }


        public int getAmmo() {
            if (droppable) {
                return 1;
            }
            return 0;
        }
    }
}
