using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintState : IState {

    private PlayerMovement playerMovement;


    public SprintState(PlayerMovement p_playerMovement) {
        playerMovement = p_playerMovement;
    }

    public void Enter() {
        Debug.Log("Enter sprint state");
        playerMovement.SetPlayable(true);
        playerMovement.SetCurrentSpeed(8);

    }

    public void Execute() {
        throw new System.NotImplementedException();
    }

    public void Exit() {
        throw new System.NotImplementedException();
    }

    public void FixedExecute() {
        throw new System.NotImplementedException();
    }
}
