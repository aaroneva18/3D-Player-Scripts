using UnityEngine;

public class IddleState : IState
{
    private Movement movement;

    public IddleState(Movement p_movement ) {
        movement = p_movement;
    }

    public void Enter() {
        movement.SetPlayable(true);
        movement.SetCurrentSpeed(0);
    }

    public void Execute() {
       
    }
    public void FixedExecute() {
        
    }

    public void Exit() {
    }


}
