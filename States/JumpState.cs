using UnityEngine;

public class JumpState : IState {

    private PlayerMovement playerMovement;
    

    public JumpState(PlayerMovement p_playerMovement) {
        playerMovement = p_playerMovement;
    }

    public void Enter() {
        Debug.Log("Jumping");
    }

    public void Execute() {
        throw new System.NotImplementedException();
    }


    public void FixedExecute() {
        throw new System.NotImplementedException();
    }
    public void Exit() {
        throw new System.NotImplementedException();
    }
}
