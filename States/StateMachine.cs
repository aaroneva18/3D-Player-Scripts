using System;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    private IState CurrentState;
    private IState PreviousState;

    protected InputManagerPlayer inputManager;
    protected PlayerMovement playerMovement;
    protected List<Transition> transitions = new List<Transition>();

    private void Awake() {
        SetDefalutState();
    }

    void Update()
    {
        Transition transition = GetTransition();
        if (transition != null) {
            SetState(transition.To);
        }
        CurrentState?.Execute();

        //Debug.Log(CurrentState);
    }

    void FixedUpdate() {
        
        CurrentState?.FixedExecute();
    }

    public IState GetCurrentState { get { return CurrentState; } }
    public IState GetPreviuosState { get { return PreviousState; } }

    public void AddTransition(IState from , IState to, Func<bool> Condition) {
        transitions.Add(new Transition(from, to, Condition));
    }

    public void SetState(IState newState) {

        CurrentState?.Exit();
        PreviousState = CurrentState;
        CurrentState = newState;
         
        if (transitions == null) { transitions = new List<Transition>(0); }

        CurrentState.Enter();
    }

    private Transition GetTransition() {
        foreach (Transition transition in transitions) {
            if (transition.From == CurrentState && transition.Condition()) {
                return transition;
            }
        }
        return null;
    }

    private void SetDefalutState() {
        try {
            inputManager = GetComponent<InputManagerPlayer>();
            playerMovement = GetComponent<PlayerMovement>();
        } catch {
            Debug.LogError("Error setting SetDefaultState");
        }
    }

}

public class Transition {
    public IState From { get; }
    public IState To { get; }
    public Func<bool> Condition { get; }

    public Transition(IState from, IState to, Func<bool> condition) {
        From = from;
        To = to;
        Condition = condition;
    }
}
