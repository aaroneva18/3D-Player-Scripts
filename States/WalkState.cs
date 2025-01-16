using UnityEngine;

public class WalkState : State
{
    private PlayerMovement movement;

    public WalkState(PlayerMovement p_movement) {
        movement = p_movement;
    }

    public void Enter() {
        Debug.Log("Walk state enter");
    }

    public void Execute() {
    }
    public void FixedExecute() {
        movement.Move();
        
    }

    public void Exit() {
        Debug.Log("Walk state exit");
    }



}
