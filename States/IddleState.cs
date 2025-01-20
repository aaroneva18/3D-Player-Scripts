using UnityEngine;

public class IddleState : IState
{
    private PlayerMovement playerMovement;
    private StateMachine stateMachine;
    private InputManagerPlayer inputManager;

    public IddleState(PlayerMovement p_playerMovement, StateMachine p_stateMachine, InputManagerPlayer p_inputManager) {
        playerMovement = p_playerMovement;
        stateMachine = p_stateMachine;
        inputManager = p_inputManager;
    }

    public void Enter() {
        Debug.Log("Enter iddle state");
        playerMovement.SetPlayable(true);
        playerMovement.SetCurrentSpeed(0);
    }

    public void Execute() {
       
    }
    public void FixedExecute() {
        
    }

    public void Exit() {
        Debug.Log("Exit iddle state");
    }


}
