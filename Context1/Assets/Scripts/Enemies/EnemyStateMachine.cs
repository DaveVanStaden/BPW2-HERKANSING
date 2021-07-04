using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public Dictionary<System.Type, BaseState> stateDictionary = new Dictionary<System.Type, BaseState>();
    public BaseState currentState;

    public EnemyStateMachine(System.Type startState, params BaseState[] states)
    {
        foreach(BaseState state in states)
        {
            state.Initialize(this);
            stateDictionary.Add(state.GetType(), state);
        }
        SwitchState(startState);
    }
    private void Awake()
    {
    }
    private void Update()
    {
        OnUpdate();
    }
    public void OnUpdate()
    {
        currentState?.OnUpdate();
    }

    public void SwitchState(System.Type newStateType)
    {
        currentState?.OnExit();
        currentState = stateDictionary[newStateType];
        currentState?.OnEnter();
    }
}
