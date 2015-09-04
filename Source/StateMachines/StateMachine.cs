using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entropy.Core;
using AgentInside.Api;

namespace AgentInside.StateMachines
{
    public class StateMachine : IComponent, IStateMachine
    {
        public Entity Owner { get; set; }

        public IState CurrentState { get; set; }
        public IState PreviousState { get; set; }
        public IState GlobalState { get; set; }

        public void ChangeState(IState newState)
        {
            if (newState == null) throw new ArgumentNullException();

            PreviousState = CurrentState;
            PreviousState.Exit(Owner);
            CurrentState = newState;
            newState.Enter(Owner);
        }

        public bool IsInState(Type stateType)
        {
            return CurrentState.GetType() == stateType;
        }
    }
}
