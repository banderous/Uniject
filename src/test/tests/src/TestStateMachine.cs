using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Game;

namespace LS3Test {

    enum State {
        OPEN,
        CLOSED,
    }

    public enum Condition {
        CAN_OPEN,
        CAN_CLOSE,
    }

    [TestFixture]
    public class TestStateMachine : IValidator<Condition> {

        private bool response;

        [Test]
        public void TestNoStateTransition() {
            StateMachine<State, Condition> machine = buildStateMachine();
            response = false;
            machine.Update();

            LSAssert.AreEqual<State>(State.OPEN, machine.getState());
        }

        [Test]
        public void TestStateTransition() {
            StateMachine<State, Condition> machine = buildStateMachine();
            response = true;
            machine.Update();

            LSAssert.AreEqual<State>(State.CLOSED, machine.getState());
        }

        public bool validate(Condition c) {
            return response;
        }

        private StateMachine<State, Condition> buildStateMachine() {
            StateMachine<State, Condition> machine = new StateMachine<State, Condition>(this, State.OPEN);
            machine.AddTransition(State.OPEN, State.CLOSED, Condition.CAN_CLOSE);
            machine.AddTransition(State.CLOSED, State.OPEN, Condition.CAN_OPEN);
            return machine;
        }
    }
}
