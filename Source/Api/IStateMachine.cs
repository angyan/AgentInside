using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentInside.Api
{
    public interface IStateMachine
    {
        // http://www.ai-junkie.com/architecture/state_driven/tut_state3.html
        // ----------------
        // Public interface
        // ----------------

        // Methods
        void ChangeState(IState newState);
        bool IsInState(Type stateType);

        // Properties
        IState CurrentState { get; set; }
        IState PreviousState { get; set; }
        IState GlobalState { get; set; }

        //Events

        // -----------------
        // Private interface
        // -----------------

        // Methods

        // Properties

        //Events
    }
}
