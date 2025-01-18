using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState CurrentState;
    private IState PreviousState;
    private IState NextState;

    private InputManagerPlayer inputManager;

    private void Awake() {
        SetDefalutState();
    }
    void Start()
    {
        
    }

    void Update()
    {
        

    }

    void FixedUpdate() {
        
        CurrentState.FixedExecute();
    }

    public IState GetCurrentState { get { return CurrentState; } }

    //TODO
    public void Transition(IState from, IState to, Func<bool> condition) {
    }

    public void SetCurrentState(IState newState) {
        if (CurrentState != null) { CurrentState.Exit(); }
        PreviousState = CurrentState;
        CurrentState = newState;

        CurrentState.Enter();
    }

    private void SetDefalutState() {
        try {
            inputManager = GetComponent<InputManagerPlayer>();
        } catch {
            Debug.LogError("Error setting SetDefaultState");
        }
    }

}
