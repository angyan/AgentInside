using Entropy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentInside.Api
{
    public interface IState
    {
        // ----------------
        // Public interface
        // ----------------

        // Methods
        void Enter(Entity entity);
        void Execute(Entity entity);
        void Exit(Entity entity);

        // Properties

        //Events

        // -----------------
        // Private interface
        // -----------------

        // Methods

        // Properties

        //Events
    }
}
