using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthState : IState {

    private PlayerMovement playerMovement;

    public StealthState(PlayerMovement p_playerMovement) {
        playerMovement = p_playerMovement;
    }
    public void Enter() {
        playerMovement.SetCurrentSpeed(3);
    }

    public void Execute() {
        
    }
    public void FixedExecute() {
        
    }

    public void Exit() {
        
    }

}
