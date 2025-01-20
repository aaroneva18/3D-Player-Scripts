using UnityEngine;

public class WalkState : IState
{
    private PlayerMovement movement;
    private InputManager inputManager;
    private StateMachine stateMachine;

    public WalkState(PlayerMovement p_movement, InputManager p_inputManager, StateMachine p_stateMachine) {
        movement = p_movement;
        inputManager = p_inputManager;
        stateMachine = p_stateMachine;
    }

    public void Enter() {
        Debug.Log("Walk state enter");
        movement.SetPlayable(true);
        movement.SetCurrentSpeed(7f);   
    }

    public void Execute(){
    }

    public void FixedExecute() {
        movement.Move();
    }

    public void Exit() {
        Debug.Log("Walk state exit");
    }



}
