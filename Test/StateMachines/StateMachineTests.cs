﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entropy;
using Entropy.Core;
using AgentInside.StateMachines;
using AgentInside.Api;
using Moq;
using Test.SupportingClasses;

namespace Tests.AI.StateMachines
{
    [TestClass]
    public class StateMachineTests
    {
        private StateMachine _stateMachine;
        //private World _world;
        private Entity _entity;

        [TestInitialize]
        public void Initialize()
        {
            _stateMachine = new StateMachine();

            //_world = new World();
            //_entity = _world.CreateEntity();
            _entity = new Entity();
        }

        [TestMethod]
        public void StateMachine_IsAnEntropyComponent()
        {
            StateMachine stateMachine = new StateMachine();

            Assert.IsInstanceOfType(stateMachine, typeof(IComponent));
        }

        [TestMethod]
        public void DefaultConstructor_InitializesAllPropertiesSuccessfully()
        {
            StateMachine stateMachine = new StateMachine();

            Assert.IsNull(stateMachine.CurrentState);
            Assert.IsNull(stateMachine.PreviousState);
            Assert.IsNull(stateMachine.GlobalState);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ChangeState_NewStateIsNull_ThrowsAnException()
        {
            _stateMachine.ChangeState(null);
        }

        [TestMethod]
        public void ChangeState_GivenANewState_CorrectlyCallsTheExitAndEnterMethodOfTheStatesAndSavesTheCurrentStateToPreviousState()
        {
            Mock<IState> currentStateMock = new Mock<IState>();
            Mock<IState> newStateMock = new Mock<IState>();

            _stateMachine.CurrentState = currentStateMock.Object;

            _stateMachine.ChangeState(newStateMock.Object);

            currentStateMock.Verify(cs => cs.Exit(_stateMachine.Owner));
            newStateMock.Verify(ns => ns.Enter(_stateMachine.Owner));
            Assert.AreEqual(currentStateMock.Object, _stateMachine.PreviousState);
            Assert.AreEqual(newStateMock.Object, _stateMachine.CurrentState);
        }

        [TestMethod]
        public void IsInState_CorrectlyDeterminesIfTheStateMachineIsInAParticularState()
        {
            _stateMachine.CurrentState = new StateType1();

            Assert.IsTrue(_stateMachine.IsInState(typeof(StateType1)));
            Assert.IsFalse(_stateMachine.IsInState(typeof(StateType2)));
        }
    }
}
