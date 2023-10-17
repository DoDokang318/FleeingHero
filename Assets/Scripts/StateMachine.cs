using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    protected IState currentState;
    public void ChangeStates(IState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState?.Enter();
    }
}
