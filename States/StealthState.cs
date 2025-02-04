using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthState : IState {

    private PlayerMovement playerMovement;
    private Animator animator;


    public StealthState(PlayerMovement p_playerMovement, Animator p_animator) {
        playerMovement = p_playerMovement;
        animator = p_animator;
    }
    public void Enter() {
        playerMovement.SetCurrentSpeed(2);
        //animator.Play("Stealth");
    }

    public void Execute() {
        
    }
    public void FixedExecute() {
        
    }

    public void Exit() {
        
    }

}
