using System;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class StateMachine : MonoBehaviour
{
    private IState CurrentState;
    private IState PreviousState;

    private InputManagerPlayer inputManager;
    private PlayerMovement playerMovement;
    public List<Transition> transitions = new List<Transition>();

    private void Awake() {
        SetDefalutState();
    }
    void Start()
    {
        WalkState walkState = new WalkState(playerMovement, inputManager, this);
        IddleState iddleState = new IddleState(playerMovement, this, inputManager);
        JumpState jumpState = new JumpState(playerMovement);
        SprintState sprintState = new SprintState(playerMovement);

        AddTransition(iddleState, walkState,() => playerMovement.GetIsMoving);

        AddTransition(walkState, jumpState, () => inputManager.GetJumpInput());
        AddTransition(walkState, sprintState, () => inputManager.GetSprintInput());

        AddTransition(jumpState, walkState, () => playerMovement.GetIsMoving);
        AddTransition(jumpState, iddleState, () => !playerMovement.GetIsMoving);

        AddTransition(sprintState, walkState, () =>!inputManager.GetSprintInput());
        AddTransition(sprintState, iddleState, () => !playerMovement.GetIsMoving);

        SetState(iddleState);
    }

    void Update()
    {
        Transition transition = GetTransition();
        if (transition != null) {
            SetState(transition.To);
        }
        CurrentState?.Execute();

        Debug.Log(CurrentState);
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
