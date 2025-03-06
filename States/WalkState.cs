using UnityEngine;

public class WalkState : IState
{
    private Movement movement;

    public WalkState(Movement p_movement) {
        movement = p_movement;
    }

    public void Enter() {
        movement.SetPlayable(true);
        movement.SetCurrentSpeed(7f);   
    }

    public void Execute(){

    }

    public void FixedExecute() {
        movement.Move();
    }

    public void Exit() {
    }



}
